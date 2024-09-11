using System;
using GitCommands;
using GitExtensions.Extensibility.Git;
using GitUI;
using GitUIPluginInterfaces;

namespace GitExtensions.GerritPlugin
{
    public class FormGerritBase : GitExtensionsForm
    {
        protected GerritSettings Settings { get; private set; }
        protected readonly IGitUICommands UiCommands;
        protected IGitModule Module => UiCommands.Module;

        private FormGerritBase()
            : this(null)
        {
        }

        protected FormGerritBase(IGitUICommands uiCommands)
            : base(true)
        {
            UiCommands = uiCommands;
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
