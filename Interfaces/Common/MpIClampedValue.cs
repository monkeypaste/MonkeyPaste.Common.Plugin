namespace MonkeyPaste.Common.Plugin {
    public interface MpIClampedValue {
        double min { get; }
        double max { get; }
        double value { get; }
    }
}
