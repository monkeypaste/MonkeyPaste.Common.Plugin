namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// The extended runtime subclass of <see cref="MpManifestFormat"/> containing
    /// </summary>
    public class MpPluginFormat : MpManifestFormat {
        public MpAnalyzerComponent analyzer { get; set; }
        public MpClipboardComponent oleHandler { get; set; }
        public MpContactFetcherFormat contactFetcher { get; set; }
    }
}
