namespace GitExtensions.GerritPlugin
{
    partial class FormGitReview
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
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Panel panel2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGitReview));
            Save = new System.Windows.Forms.Button();
            lnkGitReviewHelp = new System.Windows.Forms.LinkLabel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            _NO_TRANSLATE_GitReviewEdit = new GitUI.Editor.FileViewer();
            label1 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Save);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 480);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(241, 39);
            panel1.TabIndex = 5;
            // 
            // Save
            // 
            Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            Save.Location = new System.Drawing.Point(78, 11);
            Save.Name = "Save";
            Save.Size = new System.Drawing.Size(160, 25);
            Save.TabIndex = 1;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += SaveClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(lnkGitReviewHelp);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 458);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(241, 22);
            panel2.TabIndex = 7;
            // 
            // lnkGitReviewHelp
            // 
            lnkGitReviewHelp.AutoSize = true;
            lnkGitReviewHelp.Dock = System.Windows.Forms.DockStyle.Right;
            lnkGitReviewHelp.Location = new System.Drawing.Point(125, 0);
            lnkGitReviewHelp.Name = "lnkGitReviewHelp";
            lnkGitReviewHelp.Size = new System.Drawing.Size(116, 15);
            lnkGitReviewHelp.TabIndex = 6;
            lnkGitReviewHelp.TabStop = true;
            lnkGitReviewHelp.Text = ".gitreview file format";
            lnkGitReviewHelp.LinkClicked += lnkGitReviewPatterns_LinkClicked;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(_NO_TRANSLATE_GitReviewEdit);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Menu;
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new System.Drawing.Size(634, 519);
            splitContainer1.SplitterDistance = 389;
            splitContainer1.TabIndex = 0;
            // 
            // _NO_TRANSLATE_GitReviewEdit
            // 
            _NO_TRANSLATE_GitReviewEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            _NO_TRANSLATE_GitReviewEdit.EnableAutomaticContinuousScroll = false;
            _NO_TRANSLATE_GitReviewEdit.IsReadOnly = false;
            _NO_TRANSLATE_GitReviewEdit.Location = new System.Drawing.Point(0, 0);
            _NO_TRANSLATE_GitReviewEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            _NO_TRANSLATE_GitReviewEdit.Name = "_NO_TRANSLATE_GitReviewEdit";
            _NO_TRANSLATE_GitReviewEdit.Size = new System.Drawing.Size(389, 519);
            _NO_TRANSLATE_GitReviewEdit.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.Menu;
            label1.Dock = System.Windows.Forms.DockStyle.Top;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(6);
            label1.Size = new System.Drawing.Size(185, 192);
            label1.TabIndex = 4;
            label1.Text = resources.GetString("label1.Text");
            // 
            // FormGitReview
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(634, 519);
            Controls.Add(splitContainer1);
            Name = "FormGitReview";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Edit .gitreview";
            FormClosing += FormGitReviewFormClosing;
            Load += FormGitIgnoreLoad;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private GitUI.Editor.FileViewer _NO_TRANSLATE_GitReviewEdit;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.LinkLabel lnkGitReviewHelp;
        private System.Windows.Forms.Label label1;
    }
}