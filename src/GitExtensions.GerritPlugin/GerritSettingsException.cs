using System;

namespace GitExtensions.GerritPlugin
{
    internal class GerritSettingsException : Exception
    {
        public GerritSettingsException(string message)
            : base(message)
        {
        }
    }
}
