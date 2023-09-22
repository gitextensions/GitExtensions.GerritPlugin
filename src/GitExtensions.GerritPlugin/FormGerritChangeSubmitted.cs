using System.Windows.Forms;
using GitCommands;
using GitUI;

namespace GitExtensions.GerritPlugin
{
    public partial class FormGerritChangeSubmitted : GitExtensionsForm
    {
        public FormGerritChangeSubmitted()
        {
            InitializeComponent();
            InitializeComplete();
        }

        public static void ShowSubmitted(IWin32Window owner, string change)
        {
            var form = new FormGerritChangeSubmitted();

            form._NO_TRANSLATE_TargetLabel.Text = change;
            form._NO_TRANSLATE_TargetLabel.Click += (s, e) => OsShellUtil.OpenUrlInDefaultBrowser(change);

            form.ShowDialog(owner);
        }
    }
}
