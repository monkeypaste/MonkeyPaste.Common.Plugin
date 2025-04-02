using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// A pre-defined preset allowing you to provided a unique name and/or icon for the preset and specific values for some or all plugin parameters. Any parameters not defined by the preset will use the parameters default value specified in the <see cref="MpParameterFormat"/>. Pre-defined presets cannot be deleted but <b>can</b> be reset back to its original state
    /// 
    /// </summary>
    public class MpPresetFormat {
        /// <summary>
        /// (required) RFC 4122 compliant 128-bit GUID (UUID) with only letters, numbers and hyphens
        /// </summary>
        public string guid { get; set; }
        /// <summary>
        /// This can be ignored and is only used when <b>no</b> pre-defined presets are created
        /// </summary>
        public bool isDefault { get; set; } = false;
        /// <summary>
        /// (optional) A custom icon for this preset that is a uri (relative or absolute) to an image file (png,jpg, jpeg or bmp). When left empty the containing plugin's icon will be used.<br/>
        /// <b>Note:</b> For best usability this should be an absolute uri
        /// </summary>
        public string iconUri { get; set; }
        /// <summary>
        /// (optional) A pre-defined label for this preset. If left empty one will be generated using the plugins name and a unique number to discern from other pre-defined presets.
        /// </summary>
        public string label { get; set; } = string.Empty;
        /// <summary>
        /// (optional) A short explaination of what specifically this preset provides
        /// </summary>
        public string description { get; set; } = string.Empty;
        /// <summary>
        /// A list of paramId's and the value for them. For multi-select parameters you can use a comma-separated string of the <b>values</b> that each have a cooresponding <see cref="MpParameterValueFormat.value"/> to link with it.
        /// </summary>
        public List<MpPresetValueFormat> values { get; set; } = new List<MpPresetValueFormat>();
    }
}
