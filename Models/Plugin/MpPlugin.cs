namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// The extended runtime subclass of <see cref="MpManifest"/> containing
    /// </summary>
    public class MpPlugin : MpManifest {
        public MpAnalyzerComponent analyzer { get; set; } = null;
        public MpClipboardComponent oleHandler { get; set; }
        public MpContactFetcherFormat contactFetcher { get; set; }
    }
}
