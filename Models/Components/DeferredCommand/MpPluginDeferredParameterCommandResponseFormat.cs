using System.Windows.Input;

namespace MonkeyPaste.Common.Plugin {
    public class MpPluginDeferredParameterCommandResponseFormat : MpPluginResponseFormatBase {
        public ICommand DeferredCommand { get; set; }
    }
}
