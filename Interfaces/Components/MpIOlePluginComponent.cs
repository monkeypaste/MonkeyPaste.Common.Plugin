using System.Threading.Tasks;

namespace MonkeyPaste.Common.Plugin {
    public interface MpIOlePluginComponent : MpIPluginComponentBase {
    }
    public interface MpIOleReaderComponent : MpIOlePluginComponent {
        Task<MpOlePluginResponse> ProcessOleReadRequestAsync(MpOlePluginRequest request);
    }

    public interface MpIOleWriterComponent : MpIOlePluginComponent {
        Task<MpOlePluginResponse> ProcessOleWriteRequestAsync(MpOlePluginRequest request);
    }
}
