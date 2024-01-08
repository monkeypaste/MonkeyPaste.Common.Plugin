using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    public abstract class MpPluginComponentBase { }
    public abstract class MpPresetParamaterHostBase : MpPluginComponentBase {

        public List<MpParameterFormat> parameters { get; set; } = null;
        public List<MpPresetFormat> presets { get; set; } = null;
    }
    public abstract class MpIOComponentBase : MpPresetParamaterHostBase {
        //public MpHttpTransactionFormatBase http { get; set; }
        public MpPluginInputFormat inputType { get; set; } = null;
        public MpPluginOutputFormat outputType { get; set; } = null;
    }
}
