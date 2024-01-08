namespace MonkeyPaste.Common.Plugin {
    public class MpPluginInputFormat {
        public bool text { get; set; } = false;
        public bool image { get; set; } = false;
        public bool file { get; set; } = false;
        public string pattern { get; set; }
    }

}
