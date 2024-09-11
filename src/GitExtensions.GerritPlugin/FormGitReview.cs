using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using GitCommands;
using GitExtensions.Extensibility.Git;
using GitUI;
using GitUIPluginInterfaces;
using JetBrains.Annotations;
using ResourceManager;

namespace GitExtensions.GerritPlugin
{
    public sealed partial class FormGitReview : GitExtensionsForm, IGitUICommandsSource
    {
        private readonly TranslationString _gitreviewOnlyInWorkingDirSupported = new(
            ".gitreview is only supported when there is a working directory.");
        private readonly TranslationString _gitreviewOnlyInWorkingDirSupportedCaption = new("No working directory");

        private readonly TranslationString _cannotAccessGitreview = new(
            "Failed to save .gitreview." + Environment.NewLine + "Check if file is accessible.");
        private readonly TranslationString _cannotAccessGitreviewCaption = new("Failed to save .gitreview");

        private readonly TranslationString _saveFileQuestion = new("Save changes to .gitreview?");
        private readonly TranslationString _saveFileQuestionCaption = new("Save changes?");

        private readonly TranslationString _description = new(@"Example configuration

[gerrit]
host=review.example.com
port=29418
project=department/project.git
defaultbranch=master
defaultremote=review
defaultrebase=0");

        private string _originalGitReviewFileContent = string.Empty;
        private IGitModule Module => UICommands.Module;
        private string GitreviewPath => Path.Combine(Module.WorkingDir, ".gitreview");

        [CanBeNull] public event EventHandler<GitUICommandsChangedEventArgs> UICommandsChanged;

        private IGitUICommands _uiCommands;
        public IGitUICommands UICommands
        {
            get => _uiCommands;
            set
            {
                var oldCommands = _uiCommands;
                _uiCommands = value;
                UICommandsChanged?.Invoke(this, new GitUICommandsChangedEventArgs(oldCommands));
            }
        }

        public FormGitReview(IGitUICommands uiCommands)
            : base(true)
        {
            InitializeComponent();
            label1.Text = _description.Text;
            InitializeComplete();

            UICommands = (GitUICommands)uiCommands;
            if (UICommands != null)
            {
                _NO_TRANSLATE_GitReviewEdit.TextLoaded += GitReviewFileLoaded;
                LoadGitReview();
            }
        }

        private void LoadGitReview()
        {
            try
            {
                if (File.Exists(GitreviewPath))
                {
                    ThreadHelper.JoinableTaskFactory.Run(async () =>
                    {
                        await this.SwitchToMainThreadAsync();
                        await _NO_TRANSLATE_GitReviewEdit.ViewFileAsync(GitreviewPath);
                    });
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void SaveClick(object sender, EventArgs e)
        {
            SaveGitReview();
            Close();
        }

        private bool SaveGitReview()
        {
            if (!HasUnsavedChanges())
            {
                return false;
            }

            try
            {
                FileInfoExtensions
                    .MakeFileTemporaryWritable(
                        GitreviewPath,
                        x =>
                        {
                            var fileContent = _NO_TRANSLATE_GitReviewEdit.GetText();
                            if (!fileContent.EndsWith(Environment.NewLine))
                            {
                                fileContent += Environment.NewLine;
                            }

                            File.WriteAllBytes(x, GitModule.SystemEncoding.GetBytes(fileContent));
                            _originalGitReviewFileContent = fileContent;
                        });
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, _cannotAccessGitreview.Text + Environment.NewLine + ex.Message,
                    _cannotAccessGitreviewCaption.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void FormGitReviewFormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasUnsavedChanges())
            {
                switch (MessageBox.Show(
                    this,
                    _saveFileQuestion.Text,
                    _saveFileQuestionCaption.Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        if (!SaveGitReview())
                        {
                            e.Cancel = true;
                        }

                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void FormGitIgnoreLoad(object sender, EventArgs e)
        {
            if (!Module.IsBareRepository())
            {
                return;
            }

            MessageBox.Show(
                this,
                _gitreviewOnlyInWorkingDirSupported.Text,
                _gitreviewOnlyInWorkingDirSupportedCaption.Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            Close();
        }

        private bool HasUnsavedChanges()
        {
            return _originalGitReviewFileContent != _NO_TRANSLATE_GitReviewEdit.GetText();
        }

        private void GitReviewFileLoaded(object sender, EventArgs e)
        {
            _originalGitReviewFileContent = _NO_TRANSLATE_GitReviewEdit.GetText();
        }

        private void lnkGitReviewPatterns_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OsShellUtil.OpenUrlInDefaultBrowser("https://docs.opendev.org/opendev/git-review/latest/installation.html#gitreview-file-format");
        }
    }
}
