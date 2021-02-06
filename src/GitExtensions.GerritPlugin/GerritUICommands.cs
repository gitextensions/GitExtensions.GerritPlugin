using GitCommands;
using GitUI;
using GitUIPluginInterfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GitExtensions.GerritPlugin
{
    public sealed class GerritUICommands : GerritUICommandsBase, IGerritUICommands
    {
        private readonly GitUICommands gitUICommands;

        public GerritUICommands(GitUICommands gitUICommands)
        {
            this.gitUICommands = gitUICommands;
        }

        public IGitModule GitModule => gitUICommands.GitModule;

        public ILockableNotifier RepoChangedNotifier => gitUICommands.RepoChangedNotifier;

        public void AddCommitTemplate(string key, Func<string> addingText, Image icon)
            => gitUICommands.AddCommitTemplate(key, addingText, icon);

        public IGitRemoteCommand CreateRemoteCommand()
            => gitUICommands.CreateRemoteCommand();

        public void RemoveCommitTemplate(string key)
            => gitUICommands.RemoveCommitTemplate(key);

        public void StartBatchFileProcessDialog(string batchFile)
            => gitUICommands.StartBatchFileProcessDialog(batchFile);

        public void StartCommandLineProcessDialog(IWin32Window owner, string command, ArgumentString arguments)
            => gitUICommands.StartCommandLineProcessDialog(owner, command, arguments);

        public bool StartCommandLineProcessDialog(IWin32Window owner, IGitCommand command)
            => StartCommandLineProcessDialog(owner, command);

        public bool StartRemotesDialog(IWin32Window owner, string preselectRemote = null, string preselectLocal = null)
            => gitUICommands.StartRemotesDialog(owner, preselectRemote, preselectLocal);

        public bool StartSettingsDialog(Type pageType)
            => gitUICommands.StartSettingsDialog(pageType);

        public bool StartSettingsDialog(IGitPlugin gitPlugin)
            => StartSettingsDialog(gitPlugin);
    }
}
