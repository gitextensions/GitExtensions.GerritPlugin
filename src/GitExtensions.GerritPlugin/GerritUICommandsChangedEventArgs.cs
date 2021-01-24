using JetBrains.Annotations;
using System;

namespace GitExtensions.GerritPlugin
{
   public sealed class GerritUICommandsChangedEventArgs : EventArgs
    {
        public GerritUICommandsChangedEventArgs(IGerritUICommands oldCommands)
        {
            OldCommands = oldCommands;
        }

        [CanBeNull]
        public IGerritUICommands OldCommands { get; }
    }

    /// <summary>Provides <see cref="IGerritUICommands"/> and a change notification.</summary>
    public interface IGerritUICommandsSource
    {
        /// <summary>Raised after <see cref="UICommands"/> changes.</summary>
        event EventHandler<GerritUICommandsChangedEventArgs> UICommandsChanged;

        /// <summary>Gets the <see cref="IGerritUICommands"/> value.</summary>
        /// <exception cref="InvalidOperationException">Attempting to get a value when none has been set.</exception>
        [NotNull]
        IGerritUICommands UICommands { get; }
    }
}