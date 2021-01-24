using System;
using GitUI;
using GitUIPluginInterfaces;

namespace GitExtensions.GerritPlugin
{
    public class FormGerritBase : GitExtensionsForm
    {
        protected GerritSettings Settings { get; private set; }
        protected readonly IGerritUICommands UICommands;
        protected IGitModule Module => UICommands.GitModule;

        private FormGerritBase()
            : this(null)
        {
        }

        protected FormGerritBase(IGerritUICommands uiCommands)
            : base(true)
        {
            UICommands = uiCommands;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            Settings = GerritSettings.Load(Module);

            if (Settings == null)
            {
                Dispose();
                return;
            }

            base.OnLoad(e);
        }
    }
}
