using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    public class MpContactFetcherFormat : MpPresetParamaterHostBase {
        public string source { get; set; }
    }
    public class MpPluginContactFetchRequestFormat : MpPluginRequestFormatBase { }
    public class MpPluginContactFetchResponseFormat : MpPluginResponseFormatBase {
        public IEnumerable<MpIContact> Contacts { get; set; }
    }
}
