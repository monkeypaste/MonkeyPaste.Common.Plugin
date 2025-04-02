namespace MonkeyPaste.Common.Plugin {
    public class MpImageAnnotationNodeFormat :
        MpAnnotationNodeFormat,
        MpIRectangle {

        #region MpIRectangle Implementation
        public double left { get; set; }
        public double top { get; set; }
        public double right { get; set; }
        public double bottom { get; set; }
        #endregion

        public MpImageAnnotationNodeFormat() : base() { }

        public override string ToString() {
            return $"left: {left} top: {top} right: {right} bottom: {bottom}";
        }
        //public new List<MpImageAnnotationNodeFormat> children { get; set; }

    }

}
