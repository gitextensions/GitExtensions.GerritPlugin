using System.Windows.Forms;
using GitUI;

namespace GitExtensions.GerritPlugin
{
    public partial class FormPluginInformation : GitExtensionsForm
    {
        public FormPluginInformation()
        {
            InitializeComponent();
            InitializeComplete();
        }

        private void _NO_TRANSLATE_TargetLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OsShellUtil.OpenUrlInDefaultBrowser("https://docs.opendev.org/opendev/git-review/latest/installation.html#gitreview-file-format");
        }
    }
}
