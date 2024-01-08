using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    public class MpPluginDeferredParameterValueResponseFormat : MpPluginResponseFormatBase {
        public List<MpPluginParameterValueFormat> Values { get; set; }
    }
}
