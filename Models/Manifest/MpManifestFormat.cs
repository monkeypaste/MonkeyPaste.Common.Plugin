
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// The essential meta-information for <see cref="MpPluginFormat"/>
    /// </summary>
    public class MpManifestFormat {
        #region Statics

        #endregion

        #region Interfaces

        #endregion

        #region Properties
        /// <summary>
        /// (required) The display name for this plugin. Cannot be more than 32 characters long
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// (required) RFC 4122 compliant 128-bit GUID (UUID) with only letters, numbers and hyphens
        /// </summary>
        public string guid { get; set; }
        /// <summary>
        /// The major, minor, build, revision info for this plugin. The default is "1.0.0.0". It is only required when publishing your plugin for public use.
        /// </summary>
        public string version { get; set; } = "1.0.0.0";
        /// <summary>
        /// A brief summary of what the plugin does. It cannot be more than 1024 characters.
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// You or or your businesses name
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// A link associated to this plugins license
        /// </summary>
        public string licenseUrl { get; set; }
        /// <summary>
        /// When <paramValue>true</paramValue>, this plugin will <b>not install</b> if user does not accept the optionally viewable <see cref="licenseUrl"/> 
        /// </summary>
        public bool? requireLicenseAcceptance { get; set; }
        /// <summary>
        /// If you accept donations for this or other works you can provide a url to your donation portal here 
        /// </summary>
        public string donateUrl { get; set; }
        /// <summary>
        /// A url to a MarkDown (.md), Html (.html) or plain text file with further details about this. 
        /// </summary>
        public string readmeUrl { get; set; }
        /// <summary>
        /// A webpage about this project
        /// </summary>
        public string projectUrl { get; set; }
        /// <summary>
        /// A url to a zip compressed file (.zip) of this projects build output
        /// </summary>
        public string packageUrl { get; set; }
        /// <summary>
        /// Terms that describe this plugin for searching and group in comma separated paramValue format (csv). It cannot be more than 1024 characters long.
        /// </summary>
        public string tags { get; set; }

        /// <summary>
        /// A uri (relative or absolute) to an image file (png,jpg, jpeg or bmp). <br/>
        /// <b>Note:</b> For best usability this should be an absolute uri
        /// </summary>
        public string iconUri { get; set; }
        /// <summary>
        /// The version of MonkeyPaste this plugin was published with
        /// </summary>
        public string publishedAppVersion { get; set; }

        /// <summary>
        /// The default type is <see cref="MpPluginPackageType.Dll"/>. All other types are currently experimental.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public MpPluginPackageType packageType { get; set; } = MpPluginPackageType.Dll;

        /// <summary>
        /// A <see cref="MpManifestFormat"/> can only be one type of plugin. See <see cref="MpPluginType"/> for more info.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual MpPluginType pluginType { get; set; } = MpPluginType.Analyzer;
        /// <summary>
        /// Any requirements that cannot be included in this plugins bundle to operate
        /// </summary>
        public List<MpPluginDependency> dependencies { get; set; } = [];

        /// <summary>
        /// When set to <see cref="MpPluginDebugMode.Debug"/>, during startup the application will wait for you to attach a debugger to the main application process, called MonkeyPaste*<br/><br/>
        /// <b>Note:</b> If you expierence <b>input lag</b> (mouse and keyboard) on Windows while step-tracing. You can prevent this by setting <see cref="debugMode"/> to <see cref="MpPluginDebugMode.DebugLocalInputOnly"/> which will disable global input listening. THis will inhibit some application functionality but the lag will be gone.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public MpPluginDebugMode debugMode { get; set; } = MpPluginDebugMode.None;
        #endregion

        public override string ToString() {
            return $"{title} ({version})";
        }
    }


}
