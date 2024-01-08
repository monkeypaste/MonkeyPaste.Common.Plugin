namespace MonkeyPaste.Common.Plugin {
    public class MpPresetValueFormat  {
        public string paramId { get; set; } = string.Empty;
        public string value { get; set; } = string.Empty;
        public MpPresetValueFormat() { }
        public MpPresetValueFormat(string paramId, string value) {
            this.paramId = paramId;
            this.value = value;
        }
    }
}
