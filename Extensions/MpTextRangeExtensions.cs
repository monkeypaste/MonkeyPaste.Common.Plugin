

using MonkeyPaste.Common.Plugin;

namespace MonkeyPaste.Common {
    public static class MpTextRangeExtensions {


        public static bool IntersectsWith(this MpITextRange tr, MpITextRange otr) {
            if (tr == null) {
                return false;
            }
            if (tr is MpIDocumentComponent dc &&
                otr is MpIDocumentComponent odc &&
                !dc.IsInSameDocument(odc)) {
                return false;
            }

            int op_start_idx = tr.Offset;
            int op_end_idx = tr.Offset + tr.Length;

            int other_op_start_idx = otr.Offset;
            int other_op_end_idx = otr.Offset + otr.Length;

            if (other_op_start_idx >= op_start_idx && other_op_start_idx <= op_end_idx) {
                return true;
            }
            if (other_op_end_idx >= op_start_idx && other_op_end_idx <= op_end_idx) {
                return true;
            }
            return false;
        }

    }
}
