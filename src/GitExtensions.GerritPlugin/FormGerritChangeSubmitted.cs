using System;
﻿using System.Windows.Forms;
using GitCommands;
using GitUI;
using GitUI.Properties;

namespace GitExtensions.GerritPlugin
{
    public partial class FormGerritChangeSubmitted : GitExtensionsForm
    {
        private string _changeUri;
        private Timer _btnCopyIconTimer;

        private FormGerritChangeSubmitted()
        {
            InitializeComponent();
            InitializeComplete();
        }

        private void Initialize(string changeUri)
        {
            _changeUri = changeUri;
            _NO_TRANSLATE_TargetLabel.Text = changeUri;

            _btnCopyIconTimer = new Timer
            {
                Enabled = false,
                Interval = 3 * 1000
            };
            _btnCopyIconTimer.Tick += OnRefreshCopyButtonIcon;
        }

        private void OnRefreshCopyButtonIcon(object sender, EventArgs e)
        {
            Invoke(() => btnCopy.Image = Images.CopyToClipboard);
        }

        public static void ShowSubmitted(IWin32Window owner, string changeUri)
        {
            if (owner == null || string.IsNullOrEmpty(changeUri))
            {
                return;
            }

            using var form = new FormGerritChangeSubmitted();
            form.Initialize(changeUri);
            form.ShowDialog(owner);
        }

        private void OnChangeLinkClicked(object sender, EventArgs e)
        {
            OsShellUtil.OpenUrlInDefaultBrowser(_changeUri);
        }

        private void OnCopyToClipboardClicked(object sender, EventArgs e)
        {
            _btnCopyIconTimer.Stop();

            Clipboard.SetText(_changeUri);
            btnCopy.Image = Images.BisectGood;

            _btnCopyIconTimer.Start();
        }
    }
}
