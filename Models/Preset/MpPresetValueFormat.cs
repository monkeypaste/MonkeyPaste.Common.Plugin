namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// A look-up object that sets the <see cref="MpParameterFormat.value"/> or <see cref="MpParameterFormat.values"/> to the specified <see cref="value"/> where <see cref="paramId"/> matches <see cref="MpParameterFormat.paramId"/>.
    /// </summary>
    public class MpPresetValueFormat {
        /// <summary>
        /// Needs to match with a cooresponding <see cref="MpParameterFormat.paramId"/>
        /// </summary>
        public string paramId { get; set; } = string.Empty;
        /// <summary>
        /// The value to be used by <see cref="MpParameterFormat.value"/>. For multi-select <see cref="MpParameterFormat.controlType"/>'s this <see cref="value"/> can be a comma-separated (csv) string of the <see cref="MpParameterValueFormat.value"/>'s defined for that particular parameter.
        /// </summary>
        public string value { get; set; } = string.Empty;
        public MpPresetValueFormat() { }
        public MpPresetValueFormat(string paramId, string value) {
            this.paramId = paramId;
            this.value = value;
        }
    }
}
