namespace MonkeyPaste.Common.Plugin {
    public interface MpISupportDeferredParameterCommand {
        MpPluginDeferredParameterCommandResponseFormat RequestParameterCommand(MpPluginDeferredParameterCommandRequestFormat req);
    }
}
