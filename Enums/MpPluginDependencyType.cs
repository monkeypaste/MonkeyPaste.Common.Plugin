namespace MonkeyPaste.Common.Plugin {
    public enum MpPluginDependencyType {
        None = 0,
        /// <summary>
        /// The string paramValue of <see cref="MpUserDeviceType"/>. The only supported type is <see cref="MpUserDeviceType.Windows"/>
        /// </summary>
        os,
        /// <summary>
        /// (unimplemented) When a plugin specifically interoperates with another application you could explicitly provide its <see cref="MpPluginDependency.name"/> as the full product name and the plugins minimum <see cref="MpPluginDependency.version"/>
        /// </summary>
        app,
        /// <summary>
        /// (unimplemented) Some library not packaged with your plugin that it depends on
        /// </summary>
        lib
    }

}
