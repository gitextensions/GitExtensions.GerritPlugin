using System.Collections.Generic;
using GitExtensions.PluginTemplate.Properties;
using GitUIPluginInterfaces;
using ResourceManager;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace GitExtensions.PluginTemplate
{
    /// <summary>
    /// A template for Git Extensions plugins.
    /// Find more documentation here: https://github.com/gitextensions/gitextensions.plugintemplate/wiki/GitPluginBase
    /// </summary>
    [Export(typeof(IGitPlugin))]
    public class Plugin : GitPluginBase
    {
        public Plugin()
        {
            // Set the name of the plugin, as it appears in Git Extensions' Plugins menu.
            SetNameAndDescription("Name of your plugin...");

            // Set the icon of the plugin, as it appears in Git Extensions' Plugins menu
            Icon = Resources.Icon;

            // Translate the plugin strings. Do not remove. Should be called in the constructor of the plugin.
            Translate();
        }


        /// <summary>
        /// Is called when the plugin is loaded. This happens every time when a repository is opened.
        /// </summary>
        public override void Register(IGitUICommands gitUiCommands)
        {
            // Put your initialization logic here
        }


        /// <summary>
        /// Is called when the plugin is unloaded. This happens every time when a repository is closed through one of the following events:
        ///   1. opening another repository
        ///   2. returning to Dashboard (Repository > Close (go to Dashboard))
        ///   3. closing Git Extensions
        /// </summary>
        public override void Unregister(IGitUICommands gitUiCommands)
        {
            // Put your cleaning logic here
        }

        ///// <summary>
        ///// This is where you define the plugin setting page displayed in Git Extensions settings and that allows the user to configure the plugin settings.
        ///// You should return a collection of ISetting instances that could be of types:
        /////   * `BoolSetting` to store a boolean (display a Checkbox control),
        /////   * `StringSetting` to store a string (display a TextBox control),
        /////   * `NumberSetting` to store a number (display a TextBox control),
        /////   * `ChoiceSetting` to propose choices and store a string (display a ComboBox control),
        /////   * `PasswordSetting` to store a password (display a password TextBox control),
        /////   * `CredentialsSetting` to store a login and a password (display a login and a password fields),
        ///// See an example: https://github.com/gitextensions/gitextensions/blob/master/Plugins/JiraCommitHintPlugin/JiraCommitHintPlugin.cs
        ///// </summary>
        //public override IEnumerable<ISetting> GetSettings()
        //{
        //    // Uncomment and fill if your plugin have settings that the user could configure
        //}

        /// <summary>
        /// Is called when the plugin's name is clicked in Git Extensions' Plugins menu.
        /// Must return `true` if the revision grid should be refreshed after the execution of the plugin. false, otherwise.
        /// Help: You could call args.GitUICommands.StartSettingsDialog(this); in this method to open the setting page of the plugin.
        /// </summary>
        /// <returns>
        /// Returns <see langword="true"/> if the revision grid should be refreshed after the execution of the plugin;
        /// otherwise <see langword="false"/>.
        /// </returns>
        public override bool Execute(GitUIEventArgs gitUIEventArgs)
        {
            // Put your action logic here
            MessageBox.Show(gitUIEventArgs.OwnerForm, "Hello from the Plugin Template.", "Git Extensions");
            return false;
        }
    }
}
