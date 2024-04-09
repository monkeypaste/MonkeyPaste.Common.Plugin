//using McMaster.NETCore.Plugins;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonkeyPaste.Common.Plugin {
    public interface MpIClipboard {
        Task ClearAsync();
        Task<object> GetDataAsync(string format);
        Task<string[]> GetFormatsAsync();
        Task SetDataObjectAsync(Dictionary<string, object> data);
    }
}