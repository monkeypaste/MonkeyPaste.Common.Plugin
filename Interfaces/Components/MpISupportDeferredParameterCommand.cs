namespace MonkeyPaste.Common.Plugin {
    public interface MpISupportDeferredParameterCommand {
        MpPluginParameterCommandResponseFormat RequestParameterCommand(MpDeferredParameterCommandRequestFormat req);
    }
}
