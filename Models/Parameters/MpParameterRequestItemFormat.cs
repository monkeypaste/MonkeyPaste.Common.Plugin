namespace MonkeyPaste.Common.Plugin {
    public class MpParameterRequestItemFormat {
        public string paramId { get; set; }
        public string paramValue { get; set; } = string.Empty;
        public MpParameterRequestItemFormat() { }
        public MpParameterRequestItemFormat(string id, string val) {
            paramId = id;
            paramValue = val;
        }
    }
}
