using System.Threading.Tasks;

namespace MonkeyPaste.Common.Plugin {
    public interface MpIFetchComponentBase : MpIPluginComponentBase { }

    public interface MpIContactFetcherComponent : MpIFetchComponentBase {
        MpPluginContactFetchResponseFormat Fetch(MpPluginContactFetchRequestFormat req);
    }

    public interface MpIContactFetcherComponentAsync : MpIFetchComponentBase {
        Task<MpPluginContactFetchResponseFormat> FetchAsync(MpPluginContactFetchRequestFormat req);
    }
    public interface MpIContact {
        object Source { get; }
        string SourceName { get; }
        string guid { get; }
        string FirstName { get; }
        string LastName { get; }
        string FullName { get; }
        string PhoneNumber { get; }
        string Address { get; }
        string Email { get; }
    }
}
