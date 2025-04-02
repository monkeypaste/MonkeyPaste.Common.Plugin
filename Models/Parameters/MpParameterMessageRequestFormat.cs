using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    public class MpParameterMessageRequestFormat : MpMessageRequestFormatBase {

        public List<MpParameterRequestItemFormat> items { get; set; }
    }
}
