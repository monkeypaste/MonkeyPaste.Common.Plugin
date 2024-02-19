namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// The type of <see cref="MpMessageRequestFormatBase"/> request and <see cref="MpMessageResponseFormatBase"/> response this plugin is intended to handle.
    /// </summary>
    public enum MpPluginType {
        None = 0,
        /// <summary>
        /// Provides custom read and/or write support for any specified data format(s) during clipboard and drag-and-drop operations.
        /// </summary>
        Clipboard,
        /// <summary>
        /// Generates or annotates content given a set of established parameters that may include a single clip's content (in some particular format), meta-information about a clip along with a set of user-specified options based on parameters defined from <see cref="MpParameterFormat"/> items
        /// </summary>
        Analyzer,
        /// <summary>
        /// (Experimental) Fetches a set of key/paramValue pairs (currently as <see cref="MpIContact"/> objects) for use with the 'Contact' type text templates available from the 🏷️ text editor toolbar button
        /// </summary>
        Fetcher
    }


}
