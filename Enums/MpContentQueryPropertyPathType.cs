namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// Data about a particular clip, its source and usage information
    /// </summary>
    public enum MpContentQueryPropertyPathType {
        None = 0,
        /// <summary>
        /// The plain text representation of a clip. Images are a base64 encoded string. FileLists are each path separated by line breaks (based on environment)
        /// </summary>
        ClipText,
        /// <summary>
        /// Only meaningful for Text which is the actual HTML fragment of the clip. Result is the same as <see cref="ClipText"/> for Image or FileList. 
        /// </summary>
        RawClipData,
        /// <summary>
        /// The type of clip (Text,Image,FileList)
        /// </summary>
        ClipType,
        /// <summary>
        /// The title for a clip
        /// </summary>
        Title, //seperator
        /// <summary>
        /// A source process a clip was copied from <br/><br/>
        /// <b>Note: </b> This is generally reliable but not always accurate!
        /// </summary>
        SourceAppPath,
        /// <summary>
        /// The source application name a clip was copied from
        /// </summary>
        SourceAppName,
        /// <summary>
        /// A source web page a clip was copied from <br/><br/>
        /// <b>Note: </b> This information is <b>not</b> always available and dependant on how clipboard-friendly the source browser application is
        /// </summary>
        SourceUrl,
        /// <summary>
        /// The title of the web page a clip was copied from
        /// </summary>
        SourceUrlTitle,
        /// <summary>
        /// A convienence property providing the domain from <see cref="SourceUrl"/>
        /// </summary>
        SourceUrlDomain, //seperator
        /// <summary>
        /// The <b>last</b> datetime a clip was copied
        /// </summary>
        CopyDateTime,
        /// <summary>
        /// The amount of times this exact clip has been copied, disregarding any editing that may have occured along its history.<br/><br/>
        /// <b>Note: </b> This info may not be available depending on users preferences
        /// </summary>
        CopyCount,
        /// <summary>
        /// The amount of times a clip has been pasted or dropped<br/><br/>
        /// <b>Note: </b> This info may not be available depending on users preferences or when pasted from a context menu
        /// </summary>
        PasteCount,
        /// <summary>
        /// A machine name the clip was copied from
        /// </summary>
        SourceDeviceName,
        /// <summary>
        /// The type of machine a clip was copied from (will obviously only be windows for now)
        /// </summary>
        SourceDeviceType,
        /// <summary>
        /// Only available in action sequences. Will have no affect if referenced in a <see cref="MpParameterFormat"/>
        /// </summary>
        LastOutput,
    }


}
