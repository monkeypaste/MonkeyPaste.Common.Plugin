using System.Threading.Tasks;

namespace MonkeyPaste.Common.Plugin {
    public interface MpIAnalyzeComponentAsync : MpIPluginComponentBase {
        /// <summary>
        /// Provides analysis for content from MonkeyPaste
        /// </summary>
        /// <param name="request">Content and settings for this analysis using the parameters (items) defined in the plugins component definition. </param>
        /// <returns>The result of the analysis</returns>
        Task<MpAnalyzerPluginResponseFormat> AnalyzeAsync(MpAnalyzerPluginRequestFormat request);
    }
    public interface MpIAnalyzeComponent : MpIPluginComponentBase {
        /// <summary>
        /// Provides analysis for content from MonkeyPaste
        /// </summary>
        /// <param name="request">Content and settings for this analysis using the parameters (items) defined in the plugins component definition.</param>
        /// <returns>The result of the analysis</returns>
        MpAnalyzerPluginResponseFormat Analyze(MpAnalyzerPluginRequestFormat request);
    }
}
