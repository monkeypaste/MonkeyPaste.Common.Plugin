using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// The base object to all 
    /// </summary>
    public abstract class MpPluginComponentBase { }
    public abstract class MpPresetParamaterHostBase : MpPluginComponentBase {

        public List<MpParameterFormat> parameters { get; set; } = [];
        public List<MpPresetFormat> presets { get; set; } = [];
    }
    public abstract class MpIOComponentBase : MpPresetParamaterHostBase {
        //public MpHttpTransactionFormatBase http { get; set; }
        public MpPluginInputFormat inputType { get; set; } = new();
        public MpPluginOutputFormat outputType { get; set; } = new();
    }
}
