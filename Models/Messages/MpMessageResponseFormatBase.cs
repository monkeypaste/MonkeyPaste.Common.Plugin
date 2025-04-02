using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    public abstract class MpMessageResponseFormatBase : MpMessageFormatBase {
        public string errorMessage { get; set; }
        public string retryMessage { get; set; }

        public string otherMessage { get; set; }

        public Dictionary<object, string> invalidParams { get; set; } = new();
        public List<MpUserNotification> userNotifications { get; set; } = new();
        public Dictionary<string, object> dataObjectLookup { get; set; }

    }
}
