namespace MonkeyPaste.Common {
    public interface MpIDocumentComponent {
        object Document { get; }
        bool IsInSameDocument(MpIDocumentComponent dtr);
    }
}
