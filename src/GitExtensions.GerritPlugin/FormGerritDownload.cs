using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitCommands;
using GitCommands.Git.Commands;
using GitExtUtils.GitUI;
using GitUI;
using GitUIPluginInterfaces;
using Newtonsoft.Json.Linq;
using ResourceManager;

namespace GitExtensions.GerritPlugin
{
    public partial class FormGerritDownload : FormGerritBase
    {
        private string _currentBranchRemote;

        #region Translation
        private readonly TranslationString _downloadGerritChangeCaption = new("Download Gerrit Change");

        private readonly TranslationString _downloadCaption = new("Download change {0}");

        private readonly TranslationString _error = new("Error");
        private readonly TranslationString _selectRemote = new("Please select a remote repository");
        private readonly TranslationString _selectChange = new("Please enter a change");
        private readonly TranslationString _cannotGetChangeDetails = new("Could not retrieve the change details");
        private readonly TranslationString _cannotGetPatchSetDetails = new("Could not retrieve the patchset details");
        private readonly TranslationString _changeHelp = new("Enter the Change-Id or the number from the Gerrit URL");
        private readonly TranslationString _patchSetHelp = new("Optionally enter the Patchset # to download (the latest by default)");
        #endregion

        public FormGerritDownload(IGitUICommands uiCommand)
            : base(uiCommand)
        {
            InitializeComponent();
            InitializeComplete();
        }

        protected ToolTip ToolTip => toolTip;

        private void DownloadClick(object sender, EventArgs e)
        {
            if (ThreadHelper.JoinableTaskFactory.Run(() => DownloadChangeAsync(this)))
            {
                Close();
            }
        }

        private async Task<bool> DownloadChangeAsync(IWin32Window owner)
        {
            await this.SwitchToMainThreadAsync();

            string change = _NO_TRANSLATE_Change.Text.Trim();

            if (string.IsNullOrEmpty(_NO_TRANSLATE_Remotes.Text))
            {
                MessageBox.Show(owner, _selectRemote.Text, _error.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(change))
            {
                MessageBox.Show(owner, _selectChange.Text, _error.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            GerritUtil.StartAgent(owner, Module, _NO_TRANSLATE_Remotes.Text);

            int? patchSet = null;
            if (int.TryParse(_NO_TRANSLATE_Patchset.Text.Trim(), out int inputtedPatchSet))
            {
                patchSet = inputtedPatchSet;
            }

            var reviewInfo = await LoadReviewInfoAsync(patchSet);
            await this.SwitchToMainThreadAsync();

            if (reviewInfo?["id"] == null)
            {
                MessageBox.Show(owner, _cannotGetChangeDetails.Text, _error.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // The user can enter both the Change-Id or the number. Here we
            // force the number to get prettier branches.

            JObject patchSetInfo = patchSet == null
                ? (JObject)reviewInfo["currentPatchSet"]
                : (JObject)((JArray)reviewInfo["patchSets"]).FirstOrDefault(q => (int)q["number"] == patchSet);
            if (patchSetInfo == null)
            {
                MessageBox.Show(owner, _cannotGetPatchSetDetails.Text, _error.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            change = (string)reviewInfo["number"];
            string topic = _NO_TRANSLATE_TopicBranch.Text.Trim();

            if (string.IsNullOrEmpty(topic))
            {
                var topicNode = (JValue)reviewInfo["topic"];
                topic = topicNode == null
                    ? change + "/" + (string)patchSetInfo["number"]
                    : (string)topicNode.Value;
            }

            var authorValue = (string)((JValue)reviewInfo["owner"]["name"]).Value;
            string author = Regex.Replace(authorValue.ToLowerInvariant(), "\\W+", "_");
            string branchName = "review/" + author + "/" + topic;
            var refSpec = (string)((JValue)patchSetInfo["ref"]).Value;

            var fetchCommand = UiCommands.CreateRemoteCommand();

            fetchCommand.CommandText = FetchCommand(_NO_TRANSLATE_Remotes.Text, refSpec);

            if (!RunCommand(fetchCommand, change))
            {
                return false;
            }

            var checkoutCommand = UiCommands.CreateRemoteCommand();

            checkoutCommand.CommandText = GitCommandHelpers.BranchCmd(branchName, "FETCH_HEAD", true);
            checkoutCommand.Completed += (_, e) =>
            {
                if (e.IsError && e.Command.CommandText != null && e.Command.CommandText.Contains("already exists"))
                {
                    // Recycle the current review branch.

                    var recycleCommand = UiCommands.CreateRemoteCommand();

                    recycleCommand.CommandText = "checkout " + branchName;

                    if (!RunCommand(recycleCommand, change))
                    {
                        return;
                    }

                    var resetCommand = UiCommands.CreateRemoteCommand();

                    resetCommand.CommandText = GitCommandHelpers.ResetCmd(ResetMode.Hard, "FETCH_HEAD");

                    if (!RunCommand(resetCommand, change))
                    {
                        return;
                    }

                    e = new GitRemoteCommandCompletedEventArgs(e.Command, false, e.Handled);
                }
            };

            return RunCommand(checkoutCommand, change);
        }

        private bool RunCommand(IGitRemoteCommand command, string change)
        {
            command.OwnerForm = this;
            command.Title = string.Format(_downloadCaption.Text, change);
            command.Remote = _NO_TRANSLATE_Remotes.Text;

            command.Execute();

            return !command.ErrorOccurred;
        }

        private static string FetchCommand(string remote, string remoteBranch)
        {
            remote = FixPath(remote);

            // Remove spaces...
            remoteBranch = remoteBranch?.Replace(" ", string.Empty);

            return "fetch --progress \"" + remote.Trim() + "\" " + remoteBranch;
        }

        private static string FixPath(string path)
        {
            path = path.Trim();
            return path.ToPosixPath();
        }

        private async Task<JObject> LoadReviewInfoAsync(int? patchSet = null)
        {
            var fetchUrl = GerritUtil.GetFetchUrl(Module, _currentBranchRemote);

            string projectName = fetchUrl.AbsolutePath.TrimStart('/');

            if (projectName.EndsWith(".git"))
            {
                projectName = projectName[..^4];
            }

            string change = await GerritUtil
                .RunGerritCommandAsync(
                    this,
                    Module,
                    $"gerrit query --format=JSON project:{projectName} {(patchSet == null ? "--current-patch-set" : "--patch-sets")} change:{_NO_TRANSLATE_Change.Text}",
                    fetchUrl,
                    _currentBranchRemote,
                    null)
                .ConfigureAwait(false);

            foreach (string line in change.Split('\n'))
            {
                try
                {
                    return JObject.Parse(line);
                }
                catch
                {
                    // Ignore exceptions.
                }
            }

            return null;
        }

        private void FormGerritDownloadLoad(object sender, EventArgs e)
        {
            _NO_TRANSLATE_Remotes.DataSource = Module.GetRemoteNames();

            _currentBranchRemote = Settings.DefaultRemote;

            var remotes = (IList<string>)_NO_TRANSLATE_Remotes.DataSource;
            int i = remotes.IndexOf(_currentBranchRemote);
            _NO_TRANSLATE_Remotes.SelectedIndex = i >= 0 ? i : 0;

            _NO_TRANSLATE_Change.Select();

            Text = string.Concat(_downloadGerritChangeCaption.Text, " (", Module.WorkingDir, ")");

            ToolTip.SetToolTip(_NO_TRANSLATE_ChangeHelp, _changeHelp.Text);
            ToolTip.SetToolTip(_NO_TRANSLATE_PatchsetHelp, _patchSetHelp.Text);
            _NO_TRANSLATE_ChangeHelp.Size = DpiUtil.Scale(_NO_TRANSLATE_ChangeHelp.Size);
            _NO_TRANSLATE_PatchsetHelp.Size = DpiUtil.Scale(_NO_TRANSLATE_PatchsetHelp.Size);
        }

        private void AddRemoteClick(object sender, EventArgs e)
        {
            UiCommands.StartRemotesDialog(this);
            _NO_TRANSLATE_Remotes.DataSource = Module.GetRemoteNames();
        }
    }
}