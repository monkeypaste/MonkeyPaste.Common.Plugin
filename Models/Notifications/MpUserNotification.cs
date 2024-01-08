namespace MonkeyPaste.Common.Plugin {
    public class MpUserNotification : MpINotificationFormat {
        public MpPluginNotificationType NotificationType { get; set; }
        public int MaxShowTimeMs { get; set; } = 3_000; // < 0 means indefinite
        public string Title { get; set; }
        public object Body { get; set; }
        public string Detail { get; set; }
        public object IconSourceObj { get; set; }
    }
}