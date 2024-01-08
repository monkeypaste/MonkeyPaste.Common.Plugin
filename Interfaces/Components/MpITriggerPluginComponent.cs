using System.Threading.Tasks;

namespace MonkeyPaste.Common.Plugin {
    public interface MpIActionOutputNode : MpILabelText {
        MpIActionOutputNode Previous { get; }
        object Output { get; }
    }
    public interface MpIActionPluginComponent : MpIPluginComponentBase {
        Task PerformActionAsync(object arg);
        bool CanPerformAction(object arg);
        Task ValidateActionAsync();
        string ValidationText { get; }
    }
    public interface MpITriggerPluginComponent : MpIActionPluginComponent {
        void EnableTrigger();
        void DisableTrigger();

        bool? IsEnabled { get; }

    }
}
