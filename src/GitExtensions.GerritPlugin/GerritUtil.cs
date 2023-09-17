using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitCommands;
using GitExtUtils;
using GitUI;
using GitUI.Infrastructure;
using GitUIPluginInterfaces;
using JetBrains.Annotations;

namespace GitExtensions.GerritPlugin
{
    internal static class GerritUtil
    {
        private static readonly ISshPathLocator SshPathLocatorInstance = new SshPathLocator();

        public static async Task<string> RunGerritCommandAsync(
            [NotNull] IWin32Window owner,
            [NotNull] IGitModule module,
            [NotNull] string command,
            [NotNull] string remote,
            byte[] stdIn)
        {
            var fetchUrl = GetFetchUrl(module, remote);

            return await RunGerritCommandAsync(owner, module, command, fetchUrl, remote, stdIn).ConfigureAwait(false);
        }

        public static bool HadNewChange(string commandPrompt, out string changeUri)
        {
            if (!commandPrompt.Split('\n').Any(line => line.Contains("New Changes") || line.EndsWith("[NEW]")))
            {
                changeUri = null;
                return false;
            }

            var changeUriRegex = new Regex(@"https?://[^ ]+/c/[^ ]+/\+/[0-9]+", RegexOptions.Multiline);
            var changeUriMatch = changeUriRegex.Match(commandPrompt);
            if (!changeUriMatch.Success)
            {
                changeUri = null;
                return false;
            }

            changeUri = changeUriMatch.Value;
            return true;
        }

        public static Uri GetFetchUrl(IGitModule module, string remote)
        {
            var args = new GitArgumentBuilder("remote")
            {
                "show",
                "-n",
                remote.QuoteNE()
            };

            string remotes = module.GitExecutable.GetOutput(args);

            string fetchUrlLine = remotes.Split('\n').Select(p => p.Trim()).First(p => p.StartsWith("Push"));

            return new Uri(fetchUrlLine.Split(new[] { ':' }, 2)[1].Trim());
        }

        public static async Task<string> RunGerritCommandAsync(
            [NotNull] IWin32Window owner,
            [NotNull] IGitModule module,
            [NotNull] string command,
            [NotNull] Uri fetchUrl,
            [NotNull] string remote,
            byte[] stdIn)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (fetchUrl == null)
            {
                throw new ArgumentNullException(nameof(fetchUrl));
            }

            if (remote == null)
            {
                throw new ArgumentNullException(nameof(remote));
            }

            StartAgent(owner, module, remote);

            var sshCmd = GitSshHelpers.IsPlink
                ? AppSettings.Plink
                : SshPathLocatorInstance.GetSshFromGitDir(AppSettings.GitBinDir);

            if (string.IsNullOrEmpty(sshCmd))
            {
                sshCmd = "ssh.exe";
            }

            string hostname = fetchUrl.Host;
            string username = fetchUrl.UserInfo;
            string portFlag = GitSshHelpers.IsPlink ? " -P " : " -p ";
            int port = fetchUrl.Port;

            if (port == -1 && fetchUrl.Scheme == "ssh")
            {
                port = 22;
            }

            var sb = new StringBuilder();

            sb.Append('"');

            if (!string.IsNullOrEmpty(username))
            {
                sb.Append(username);
                sb.Append('@');
            }

            sb.Append(hostname);
            sb.Append('"');
            sb.Append(portFlag);
            sb.Append(port);

            sb.Append(" \"");
            sb.Append(command);
            sb.Append('"');

            return await new Executable(sshCmd)
                .GetOutputAsync(sb.ToString(), stdIn)
                .ConfigureAwait(false);
        }

        public static void StartAgent([NotNull] IWin32Window owner, [NotNull] IGitModule module, [NotNull] string remote)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            if (remote == null)
            {
                throw new ArgumentNullException(nameof(remote));
            }

            if (GitSshHelpers.IsPlink)
            {
                PuttyHelpers.StartPageantIfConfigured(() => ((GitModule)module).GetPuttyKeyFileForRemote(remote));
            }
        }
    }
}
