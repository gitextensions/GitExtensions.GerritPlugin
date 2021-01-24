using GitUIPluginInterfaces;
using System;

namespace GitExtensions.GerritPlugin
{
    public interface IGerritUICommands : IGitUICommands
    {
        void StartRemotesDialog();
    }
}
