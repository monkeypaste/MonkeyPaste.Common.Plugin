using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MonkeyPaste.Common.Plugin {
    public class MpUserNotification : MpINotificationFormat {
        [JsonConverter(typeof(StringEnumConverter))]
        public MpPluginNotificationType NotificationType { get; set; }
        public int MaxShowTimeMs { get; set; } = 3_000; // < 0 means indefinite
        public string Title { get; set; }
        public object Body { get; set; }
        public string Detail { get; set; }
        public object IconSourceObj { get; set; }
    }
}