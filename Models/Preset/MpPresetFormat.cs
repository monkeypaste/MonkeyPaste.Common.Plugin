using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    public class MpPresetFormat {
        public string guid { get; set; }

        public bool isDefault { get; set; } = false;
        public string iconUri { get; set; }

        public string label { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;

        public List<MpPresetValueFormat> values { get; set; } = new List<MpPresetValueFormat>();
    }
}
