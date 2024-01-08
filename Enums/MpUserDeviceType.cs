namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// The current users operating system
    /// </summary>
    public enum MpUserDeviceType {
        None = 0,
        Ios,
        Android,
        Windows,
        Wsl, //  gray area for this one and not sure how to actually detect it yet
        Mac,
        Linux,
        Browser,
        Unknown
    }


}
