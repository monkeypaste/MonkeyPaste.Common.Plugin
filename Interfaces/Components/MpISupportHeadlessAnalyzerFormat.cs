using System.Threading.Tasks;

namespace MonkeyPaste.Common.Plugin {

    public interface MpIHeadlessComponentFormatBase : MpIPluginComponentBase { }
    /// <summary>
    /// Allows an analyzer's configuration to be determined at runtime
    /// </summary>
    public interface MpISupportHeadlessAnalyzerFormat : MpIHeadlessComponentFormatBase {
        MpAnalyzerComponent GetFormat(MpHeadlessComponentFormatRequest request);
    }
    public interface MpISupportHeadlessAnalyzerFormatAsync : MpIHeadlessComponentFormatBase {
        Task<MpAnalyzerComponent> GetFormatAsync(MpHeadlessComponentFormatRequest request);
    }
    /// <summary>
    /// Allows an clipboard handler's configuration to be determined at runtime
    /// </summary>
    public interface MpISupportHeadlessClipboardComponentFormat : MpIHeadlessComponentFormatBase {
        MpClipboardComponent GetFormats(MpHeadlessComponentFormatRequest request);
    }
}
