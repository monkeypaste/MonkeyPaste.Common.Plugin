using Newtonsoft.Json;

namespace MonkeyPaste.Common.Plugin {
    public abstract class MpTextAnnotationNodeFormat :
        MpAnnotationNodeFormat {
        [JsonIgnore]
        public abstract MpITextRange Range { get; }
    }

}
