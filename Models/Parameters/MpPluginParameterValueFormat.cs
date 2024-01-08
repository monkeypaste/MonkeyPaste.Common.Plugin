namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// A container for the string representation of a <see cref="MpParameterFormat"/>'s value 
    /// </summary>
    public class MpPluginParameterValueFormat {
        /// <summary>
        /// The string representation of the actual value
        /// </summary>
        public string value { get; set; } = string.Empty;
        /// <summary>
        /// The visual representation of this value. Not required and only relevant for some <see cref="MpParameterControlType"/>'s like multi-value, file choosers or button labels for example
        /// </summary>
        public string label { get; set; } = string.Empty;
        /// <summary>
        /// (Default is false) Only relevant for multi-value <see cref="MpParameterFormat"/>'s. Setting <see cref="isDefault"/> to true will mean that this <see cref="MpPluginParameterValueFormat"/> is <b>select by default</b>
        /// </summary>
        public bool isDefault { get; set; } = false;

        public MpPluginParameterValueFormat() { }
        public MpPluginParameterValueFormat(string val) : this(val, string.Empty, true) { }
        public MpPluginParameterValueFormat(string val, bool isDefault) : this(val, string.Empty, isDefault) { }
        public MpPluginParameterValueFormat(string val, string label) : this(val, label, false) { }
        public MpPluginParameterValueFormat(string val, string label, bool isDefault) {
            value = val;
            this.label = label;
            this.isDefault = isDefault;
        }
        public override string ToString() {
            return $"{label}: {value} {(isDefault ? "(Default)" : string.Empty)}";
        }
    }

}
