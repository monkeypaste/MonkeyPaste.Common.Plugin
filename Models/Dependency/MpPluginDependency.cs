namespace MonkeyPaste.Common.Plugin {
    public class MpPluginDependency {
        /// <summary>
        /// Determines how <see cref="name"/> and <see cref="version"/> are used for validation.
        /// </summary>
        public MpPluginDependencyType type { get; set; }
        /// <summary>
        /// The string paramValue of <see cref="MpUserDeviceType"/>. There's only support currrently for 'Windows' here
        /// </summary>
        public string name { get; set; }
        public string version { get; set; }
        public override string ToString() {
            return $"Type: {type} Name: {name} Version: {version}";
        }
    }


}
