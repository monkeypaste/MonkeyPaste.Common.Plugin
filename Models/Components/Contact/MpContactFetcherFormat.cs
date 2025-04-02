using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    public class MpContactFetcherFormat : MpPresetParamaterHostBase {
        public string source { get; set; }
    }
    public class MpPluginContactFetchRequestFormat : MpMessageRequestFormatBase { }
    public class MpPluginContactFetchResponseFormat : MpMessageResponseFormatBase {
        public IEnumerable<MpIContact> Contacts { get; set; }
    }
}
