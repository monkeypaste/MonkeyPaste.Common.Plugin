namespace MonkeyPaste.Common.Plugin {
    public class MpTextAnnotationNodeFormat :
        MpAnnotationNodeFormat,
        MpITextRange {

        #region MpITextRange Implementation
        public int Offset { get; set; }
        public int Length { get; set; }
        #endregion
    }

}
