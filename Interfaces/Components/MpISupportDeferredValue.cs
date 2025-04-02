using System.Threading.Tasks;

namespace MonkeyPaste.Common.Plugin {
    public interface MpISupportDeferredValueAsync : MpIPluginComponentBase {
        Task<MpDeferredParameterValueResponseFormat> RequestParameterValueAsync(MpDeferredParameterValueRequestFormat req);
    }

    public interface MpISupportDeferredValue : MpIPluginComponentBase {
        MpDeferredParameterValueResponseFormat RequestParameterValue(MpDeferredParameterValueRequestFormat req);
    }
}
