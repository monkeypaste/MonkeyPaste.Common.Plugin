using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    public class MpDeferredParameterValueResponseFormat : MpMessageResponseFormatBase {
        public List<MpParameterValueFormat> Values { get; set; }
    }
}
