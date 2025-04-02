namespace MonkeyPaste.Common.Plugin {
    public interface MpINotificationFormat {
        string Title { get; set; }
        object Body { get; set; }
        string Detail { get; set; }
        object IconSourceObj { get; set; }
    }
}