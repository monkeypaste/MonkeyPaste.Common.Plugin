using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    public class MpClipboardComponent : MpPluginComponentBase {
        public List<MpClipboardHandlerFormat> readers { get; set; } = new();
        public List<MpClipboardHandlerFormat> writers { get; set; } = new();
    }

    public class MpClipboardHandlerFormat : MpPresetParamaterHostBase, MpILabelText {
        [JsonIgnore]
        string MpILabelText.LabelText => displayName;

        public string iconUri { get; set; } = string.Empty;
        public string formatGuid { get; set; } = string.Empty;


        private string _displayName = string.Empty;
        public string displayName {
            get {
                if (string.IsNullOrEmpty(_displayName)) {
                    return formatName;
                }
                return _displayName;
            }
            set => _displayName = value;
        }

        public string formatName { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;
        public List<MpPluginDependency> dependencies { get; set; }

        public int sortOrderIdx { get; set; }
    }

    public class MpOlePluginRequest : MpParameterMessageRequestFormat {
        public bool isDnd { get; set; }
        //public IDataObject oleData { get; set; }
        public List<string> formats { get; set; }
        public bool ignoreParams { get; set; }
        public Dictionary<string, object> dataObjectLookup { get; set; }
    }
    public class MpOlePluginResponse : MpMessageResponseFormatBase {
        //public IDataObject oleData { get; set; }
    }
}
