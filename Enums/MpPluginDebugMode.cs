namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// The debug mode for this plugin
    /// </summary>
    public enum MpPluginDebugMode {
        /// <summary>
        /// The plugin is considered 'release'
        /// </summary>
        None = 0,
        /// <summary>
        /// Any symbol files for this plugin will be loaded once a debugger is attached
        /// </summary>
        Debug,
        DebugLocalInputOnly
    }


}
