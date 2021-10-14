using System.Windows.Forms;

namespace GitExtensions.GerritPlugin
{
    partial class FormGerritDownload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGerritDownload));
            this.Download = new System.Windows.Forms.Button();
            this.labelTopicBranch = new System.Windows.Forms.Label();
            this.AddRemote = new System.Windows.Forms.Button();
            this._NO_TRANSLATE_Remotes = new System.Windows.Forms.ComboBox();
            this._NO_TRANSLATE_TopicBranch = new System.Windows.Forms.TextBox();
            this.labelChange = new System.Windows.Forms.Label();
            this._NO_TRANSLATE_Change = new System.Windows.Forms.TextBox();
            this._NO_TRANSLATE_ChangeHelp = new System.Windows.Forms.PictureBox();
            this.labelRemote = new System.Windows.Forms.Label();
            this._NO_TRANSLATE_Patchset = new System.Windows.Forms.TextBox();
            this._NO_TRANSLATE_PatchsetHelp = new System.Windows.Forms.PictureBox();
            this.labelPatchset = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._NO_TRANSLATE_ChangeHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._NO_TRANSLATE_PatchsetHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // Download
            // 
            this.Download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Download.Image = global::GitExtensions.GerritPlugin.Properties.Resources.GerritDownload;
            this.Download.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Download.Location = new System.Drawing.Point(421, 126);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(101, 25);
            this.Download.TabIndex = 9;
            this.Download.Text = "&Download";
            this.Download.UseVisualStyleBackColor = true;
            this.Download.Click += new System.EventHandler(this.DownloadClick);
            // 
            // labelTopicBranch
            // 
            this.labelTopicBranch.AutoSize = true;
            this.labelTopicBranch.Location = new System.Drawing.Point(12, 102);
            this.labelTopicBranch.Name = "labelTopicBranch";
            this.labelTopicBranch.Size = new System.Drawing.Size(73, 13);
            this.labelTopicBranch.TabIndex = 7;
            this.labelTopicBranch.Text = "Topic branch:";
            // 
            // AddRemote
            // 
            this.AddRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddRemote.Location = new System.Drawing.Point(417, 17);
            this.AddRemote.Name = "AddRemote";
            this.AddRemote.Size = new System.Drawing.Size(105, 25);
            this.AddRemote.TabIndex = 2;
            this.AddRemote.Text = "Manage remotes";
            this.AddRemote.UseVisualStyleBackColor = true;
            this.AddRemote.Click += new System.EventHandler(this.AddRemoteClick);
            // 
            // _NO_TRANSLATE_Remotes
            // 
            this._NO_TRANSLATE_Remotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._NO_TRANSLATE_Remotes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._NO_TRANSLATE_Remotes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._NO_TRANSLATE_Remotes.FormattingEnabled = true;
            this._NO_TRANSLATE_Remotes.Location = new System.Drawing.Point(91, 20);
            this._NO_TRANSLATE_Remotes.Name = "_NO_TRANSLATE_Remotes";
            this._NO_TRANSLATE_Remotes.Size = new System.Drawing.Size(320, 21);
            this._NO_TRANSLATE_Remotes.TabIndex = 1;
            // 
            // _NO_TRANSLATE_TopicBranch
            // 
            this._NO_TRANSLATE_TopicBranch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._NO_TRANSLATE_TopicBranch.Location = new System.Drawing.Point(91, 99);
            this._NO_TRANSLATE_TopicBranch.Name = "_NO_TRANSLATE_TopicBranch";
            this._NO_TRANSLATE_TopicBranch.Size = new System.Drawing.Size(409, 20);
            this._NO_TRANSLATE_TopicBranch.TabIndex = 8;
            // 
            // labelChange
            // 
            this.labelChange.AutoSize = true;
            this.labelChange.Location = new System.Drawing.Point(12, 50);
            this.labelChange.Name = "labelChange";
            this.labelChange.Size = new System.Drawing.Size(47, 13);
            this.labelChange.TabIndex = 3;
            this.labelChange.Text = "Change:";
            // 
            // _NO_TRANSLATE_Change
            // 
            this._NO_TRANSLATE_Change.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._NO_TRANSLATE_Change.Location = new System.Drawing.Point(91, 47);
            this._NO_TRANSLATE_Change.Name = "_NO_TRANSLATE_Change";
            this._NO_TRANSLATE_Change.Size = new System.Drawing.Size(409, 20);
            this._NO_TRANSLATE_Change.TabIndex = 4;
            // 
            // _NO_TRANSLATE_ChangeHelp
            // 
            this._NO_TRANSLATE_ChangeHelp.Cursor = System.Windows.Forms.Cursors.Default;
            this._NO_TRANSLATE_ChangeHelp.Image = global::GitUI.Properties.Images.Information;
            this._NO_TRANSLATE_ChangeHelp.Location = new System.Drawing.Point(506, 47);
            this._NO_TRANSLATE_ChangeHelp.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this._NO_TRANSLATE_ChangeHelp.Name = "_NO_TRANSLATE_ChangeHelp";
            this._NO_TRANSLATE_ChangeHelp.Size = new System.Drawing.Size(16, 16);
            this._NO_TRANSLATE_ChangeHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._NO_TRANSLATE_ChangeHelp.TabIndex = 12;
            this._NO_TRANSLATE_ChangeHelp.TabStop = false;
            // 
            // labelRemote
            // 
            this.labelRemote.AutoSize = true;
            this.labelRemote.Location = new System.Drawing.Point(12, 23);
            this.labelRemote.Name = "labelRemote";
            this.labelRemote.Size = new System.Drawing.Size(47, 13);
            this.labelRemote.TabIndex = 0;
            this.labelRemote.Text = "Remote:";
            // 
            // _NO_TRANSLATE_Patchset
            // 
            this._NO_TRANSLATE_Patchset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._NO_TRANSLATE_Patchset.Location = new System.Drawing.Point(91, 73);
            this._NO_TRANSLATE_Patchset.Name = "_NO_TRANSLATE_Patchset";
            this._NO_TRANSLATE_Patchset.Size = new System.Drawing.Size(409, 20);
            this._NO_TRANSLATE_Patchset.TabIndex = 6;
            // 
            // _NO_TRANSLATE_PatchsetHelp
            // 
            this._NO_TRANSLATE_PatchsetHelp.Cursor = System.Windows.Forms.Cursors.Default;
            this._NO_TRANSLATE_PatchsetHelp.Image = global::GitUI.Properties.Images.Information;
            this._NO_TRANSLATE_PatchsetHelp.Location = new System.Drawing.Point(506, 73);
            this._NO_TRANSLATE_PatchsetHelp.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this._NO_TRANSLATE_PatchsetHelp.Name = "_NO_TRANSLATE_PatchsetHelp";
            this._NO_TRANSLATE_PatchsetHelp.Size = new System.Drawing.Size(16, 16);
            this._NO_TRANSLATE_PatchsetHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._NO_TRANSLATE_PatchsetHelp.TabIndex = 13;
            this._NO_TRANSLATE_PatchsetHelp.TabStop = false;
            // 
            // labelPatchset
            // 
            this.labelPatchset.AutoSize = true;
            this.labelPatchset.Location = new System.Drawing.Point(12, 76);
            this.labelPatchset.Name = "labelPatchset";
            this.labelPatchset.Size = new System.Drawing.Size(52, 13);
            this.labelPatchset.TabIndex = 5;
            this.labelPatchset.Text = "Patchset:";
            // 
            // FormGerritDownload
            // 
            this.AcceptButton = this.Download;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(534, 163);
            this.Controls.Add(this._NO_TRANSLATE_Patchset);
            this.Controls.Add(this._NO_TRANSLATE_PatchsetHelp);
            this.Controls.Add(this.labelPatchset);
            this.Controls.Add(this.labelRemote);
            this.Controls.Add(this._NO_TRANSLATE_Change);
            this.Controls.Add(this._NO_TRANSLATE_ChangeHelp);
            this.Controls.Add(this.AddRemote);
            this.Controls.Add(this._NO_TRANSLATE_TopicBranch);
            this.Controls.Add(this._NO_TRANSLATE_Remotes);
            this.Controls.Add(this.labelChange);
            this.Controls.Add(this.Download);
            this.Controls.Add(this.labelTopicBranch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGerritDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download Gerrit Change";
            this.Load += new System.EventHandler(this.FormGerritDownloadLoad);
            ((System.ComponentModel.ISupportInitialize)(this._NO_TRANSLATE_ChangeHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._NO_TRANSLATE_PatchsetHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Download;
        private System.Windows.Forms.Button AddRemote;
        private System.Windows.Forms.ComboBox _NO_TRANSLATE_Remotes;
        private System.Windows.Forms.Label labelTopicBranch;
        private System.Windows.Forms.TextBox _NO_TRANSLATE_TopicBranch;
        private System.Windows.Forms.Label labelChange;
        private System.Windows.Forms.TextBox _NO_TRANSLATE_Change;
        private System.Windows.Forms.PictureBox _NO_TRANSLATE_ChangeHelp;
        private System.Windows.Forms.Label labelRemote;
        private System.Windows.Forms.TextBox _NO_TRANSLATE_Patchset;
        private System.Windows.Forms.PictureBox _NO_TRANSLATE_PatchsetHelp;
        private System.Windows.Forms.Label labelPatchset;
        private ToolTip toolTip;
    }
}