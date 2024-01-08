using System.Threading.Tasks;

namespace MonkeyPaste.Common.Plugin {
    public interface MpISupportDeferredValueAsync : MpIPluginComponentBase {
        Task<MpPluginDeferredParameterValueResponseFormat> RequestParameterValueAsync(MpPluginDeferredParameterValueRequestFormat req);
    }

    public interface MpISupportDeferredValue : MpIPluginComponentBase {
        MpPluginDeferredParameterValueResponseFormat RequestParameterValue(MpPluginDeferredParameterValueRequestFormat req);
    }
}
