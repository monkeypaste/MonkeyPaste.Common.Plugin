using System.Windows.Input;

namespace MonkeyPaste.Common.Plugin {
    public class MpPluginParameterCommandResponseFormat : MpMessageResponseFormatBase {
        public ICommand DeferredCommand { get; set; }
    }
}
