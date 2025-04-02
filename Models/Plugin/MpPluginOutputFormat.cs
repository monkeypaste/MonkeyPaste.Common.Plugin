namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// The type of content this plugin can potentially create
    /// </summary>
    public class MpPluginOutputFormat {
        /// <summary>
        /// True when plugin outputs html documents or fragments of html
        /// </summary>
        public bool html { get; set; }
        /// <summary>
        /// True when plugin outputs plain text
        /// </summary>
        public bool text { get; set; } = false;
        /// <summary>
        /// True when plugin outputs image data
        /// </summary>
        public bool image { get; set; } = false;
        /// <summary>
        /// True when plugin outputs a file or directory on the users file-system
        /// </summary>
        public bool file { get; set; } = false;
        /// <summary>
        /// True when plugin outputs image roi's (2-d regions of interest) related to the source input
        /// </summary>
        public bool imageAnnotation { get; set; } = false;
        /// <summary>
        /// True when plugin outputs text roi's (1-d regions of interest) related to the source input
        /// </summary>
        public bool textAnnotation { get; set; } = false;

        /// <summary>
        /// When true the plugins output is received like a new clipboard item in the host application
        /// </summary>
        /// <returns></returns>
        public bool IsOutputNewContent() {
            return html || text || image || file;
        }
        /// <summary>
        /// When true the plugins configuration and output is associated the the input content (clip)
        /// </summary>
        /// <returns></returns>
        public bool IsOutputAnnotation() {
            return imageAnnotation || textAnnotation;
        }
    }



}
