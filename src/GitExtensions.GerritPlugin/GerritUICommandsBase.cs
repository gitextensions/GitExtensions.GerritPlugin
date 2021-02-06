using GitUIPluginInterfaces;
using System;

namespace GitExtensions.GerritPlugin
{
    public class GerritUICommandsBase
    {
        public event EventHandler<GitUIPostActionEventArgs> PostCommit;
        public event EventHandler<GitUIEventArgs> PostRepositoryChanged;
        public event EventHandler<GitUIPostActionEventArgs> PostSettings;
        public event EventHandler<GitUIPostActionEventArgs> PostUpdateSubmodules;
        public event EventHandler<GitUIEventArgs> PostBrowseInitialize;
        public event EventHandler<GitUIEventArgs> PostRegisterPlugin;
        public event EventHandler<GitUIEventArgs> PreCommit;
    }
}