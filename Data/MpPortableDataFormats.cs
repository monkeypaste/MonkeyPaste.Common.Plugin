
using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {


    public static class MpPortableDataFormats {
        #region Private Variables

        private static MpIPlatformDataObjectRegistrar _registrar;

        private static string[] _defaultFormatNames = new string[] {

            // windows

            Text,
            //Rtf,
            WinXaml,
            WinXamlPackage,
            //Html,
            Csv,
            //Unicode,
            //OemText,
            //FileDrop,
            //WinBitmap,
            //WinDib,
#if MAC
            MacRtf1,
            MacRtf2,
            MacText1,
            MacText2,
            MacText3,
            MacFiles2,
#endif

            // linux

            MimeMozUrl,
            MimeGnomeFiles,
            MimeUriList, 

            // avalonia

            Rtf,
            Xhtml,
            Files,
            Image,

            // cef

            Html,
            MimeText,
            MimeJson,
            CefAsciiUrl,
            //CefUnicodeUrl,

            // internal
            INTERNAL_SOURCE_URI_LIST_FORMAT, // maps to LinuxUriList            
            INTERNAL_CONTENT_PARTIAL_HANDLE_FORMAT,
            INTERNAL_CONTENT_TITLE_FORMAT,
            INTERNAL_CONTENT_ROI_FORMAT,
            INTERNAL_CONTENT_ANNOTATION_FORMAT,
            INTERNAL_CONTENT_DELTA_FORMAT,
            INTERNAL_PARAMETER_REQUEST_FORMAT,
            INTERNAL_SEARCH_CRITERIA_ITEM_FORMAT,
            INTERNAL_TAG_ITEM_FORMAT,
            INTERNAL_CONTENT_TYPE_FORMAT,
            INTERNAL_ACTION_ITEM_FORMAT,
            INTERNAL_PROCESS_INFO_FORMAT,
            INTERNAL_FILE_LIST_FRAGMENT_FORMAT,
            INTERNAL_CONTENT_ID_FORMAT,
            INTERNAL_DATA_OBJECT_SOURCE_TYPE_FORMAT
        };


        #endregion

        #region Constants

        // Windows Formats
        public const string WinText = "Text";
        public const string WinXaml = "Xaml";
        public const string WinXamlPackage = "XamlPackage";
        public const string WinUnicode = "Unicode";
        public const string WinOEMText = "OEMText";
        public const string WinFiles = "Files";
        public const string WinImage = "PNG";


        public const string WinCsv = "CSV";
        public const string WinBitmap = "Bitmap";
        public const string WinDib = "DeviceIndependentBitmap";
        public const string WinRtf = "Rich Text Format";
        public const string WinXhtml = "HTML Format";
        public const string WinFileDrop = "FileDrop";

        // Mac Formats
        public const string MacRtf1 = "public.rtf";
        public const string MacRtf2 = "com.apple.flat-rtfd";

        public const string MacText1 = "public.utf8-plain-text";
        public const string MacText2 = "public.utf16-external-plain-text";
        public const string MacText3 = "NSStringPboardType";

        public const string MacHtml1 = "public.html";
        public const string MacHtml2 = "Apple HTML pasteboard type";

        public const string MacFiles1 = "public.file-url";
        public const string MacFiles2 = "NSFilenamesPboardType";

        public const string MacUrl = "public.url";
        public const string MacUrl2 = "com.apple.webarchive";
        // this formats on dnd from chrome on mac with the toplevel domain url as the content
        public const string MacUrl3 = "org.chromium.chromium-renderer-initiated-drag";

        public const string MacImage1 = "public.tiff";
        public const string MacImage2 = "public.png";


        // Avalonia Formats


        // Cef Formats

        //public const string CefDragData = "CefDragData";
        //public const string CefUnicodeUrl = "UniformResourceLocatorW";
        public const string CefAsciiUrl = "UniformResourceLocator";

        // mime formats
        public const string MimeHtml = "text/html";
        public const string MimeText = "text/plain";
        public const string MimeJson = "application/json";

        public const string MimeMozUrl = "text/x-moz-url-priv";
        public const string MimeUriList = "text/uri-list";
        // Linux (gnome) only
        public const string MimeGnomeFiles = "x-special/gnome-copied-files";

        // Runtime formats

        public const string Text =
#if MAC
            MacText1;
#else
            WinText;
#endif

        public const string Text2 =
#if WINDOWS
            WinUnicode;
#elif MAC
            MacText2;
#endif
        public const string Text3 =
#if WINDOWS
            WinOEMText;
#elif MAC
            MacText3;
#endif

        public const string Rtf =
#if WINDOWS
            WinRtf;
#elif MAC
            MacRtf1;
#endif
        public const string Image =
#if WINDOWS
            WinImage;
#elif MAC
            MacImage1;
#endif

        public const string Image2 =
#if WINDOWS
            WinBitmap;
#elif MAC
            MacImage2;
#endif

        public const string Files =
#if WINDOWS
            WinFiles;
#elif MAC
            MacFiles1;
#endif
        public const string Csv =
#if WINDOWS
            WinCsv;
#elif MAC
            WinCsv;
#endif

        public const string Html =
#if WINDOWS
            MimeHtml;
#elif MAC
            MimeHtml;
#endif
        public const string Xhtml =
#if WINDOWS
            WinXhtml;
#elif MAC
            WinXhtml;
#endif

        // internal

        public const string INTERNAL_SOURCE_URI_LIST_FORMAT = MimeUriList;

        public const string INTERNAL_CONTENT_ID_FORMAT = "Mp Internal Content";
        public const string INTERNAL_CONTENT_PARTIAL_HANDLE_FORMAT = "Mp Internal Partial Content";
        public const string INTERNAL_CONTENT_TYPE_FORMAT = "Mp Internal Content Type";
        public const string INTERNAL_CONTENT_TITLE_FORMAT = "Mp Internal Content Title";
        public const string INTERNAL_CONTENT_ROI_FORMAT = "Mp Internal Content Roi";
        public const string INTERNAL_CONTENT_ANNOTATION_FORMAT = "Mp Internal Content Annotation";
        public const string INTERNAL_CONTENT_DELTA_FORMAT = "Mp Internal Quill Delta Json";

        public const string INTERNAL_PARAMETER_REQUEST_FORMAT = "Mp Internal Parameter Request Format";
        public const string INTERNAL_SEARCH_CRITERIA_ITEM_FORMAT = "Mp Internal Search Criteria Item";
        public const string INTERNAL_TAG_ITEM_FORMAT = "Mp Internal Tag Tile Item";
        public const string INTERNAL_ACTION_ITEM_FORMAT = "Mp Internal Action Item";
        public const string INTERNAL_PARAMETER_VALUE_FORMAT = "Mp Internal Parameter Value";
        public const string INTERNAL_PROCESS_INFO_FORMAT = "Mp Internal Process Info";
        public const string INTERNAL_FILE_LIST_FRAGMENT_FORMAT = "Mp Internal File List Fragment Format";
        public const string INTERNAL_RTF_TO_HTML_FORMAT = "Mp Internal RTF To HTML Content Type";
        public const string INTERNAL_HTML_TO_RTF_FORMAT = "Mp Internal HTML To RTF Content Type";


        // NOTE data object is not registered and only used to merge data objects
        public const string INTERNAL_DATA_OBJECT_SOURCE_TYPE_FORMAT = "Mp Internal Data Object Source Type Format";
        public const string INTERNAL_DATA_OBJECT_FORMAT = "Mp Internal Data Object Format";

        public const string PLACEHOLDER_DATAOBJECT_TEXT = "3acaaed7-862d-47f5-8614-3259d40fce4d";
        #endregion

        #region Statics

        public static string[] InternalFormats = new string[] {
            INTERNAL_SOURCE_URI_LIST_FORMAT,
            INTERNAL_CONTENT_ID_FORMAT,
            INTERNAL_CONTENT_PARTIAL_HANDLE_FORMAT,
            INTERNAL_CONTENT_TITLE_FORMAT,
            INTERNAL_CONTENT_ROI_FORMAT,
            INTERNAL_CONTENT_ANNOTATION_FORMAT,
            INTERNAL_CONTENT_DELTA_FORMAT,
            INTERNAL_PARAMETER_REQUEST_FORMAT,
            INTERNAL_SEARCH_CRITERIA_ITEM_FORMAT,
            INTERNAL_TAG_ITEM_FORMAT,
            INTERNAL_DATA_OBJECT_FORMAT,
            INTERNAL_CONTENT_TYPE_FORMAT,
            INTERNAL_ACTION_ITEM_FORMAT,
            INTERNAL_PROCESS_INFO_FORMAT,
            INTERNAL_PARAMETER_VALUE_FORMAT,
            INTERNAL_FILE_LIST_FRAGMENT_FORMAT,
            INTERNAL_RTF_TO_HTML_FORMAT,
            INTERNAL_HTML_TO_RTF_FORMAT,
            INTERNAL_DATA_OBJECT_SOURCE_TYPE_FORMAT
        };
        #endregion

        #region Properties

        private static List<string> _formatLookup = new List<string>();
        public static IEnumerable<string> RegisteredFormats =>
            _formatLookup;

        #endregion

        #region Public Methods

        public static void Init(MpIPlatformDataObjectRegistrar registrar) {
            _registrar = registrar;

            _formatLookup.Clear();

            foreach (string formatName in _defaultFormatNames) {
                RegisterDataFormat(formatName);
            }
        }

        public static void RegisterDataFormat(string format) {
            if (_formatLookup.Contains(format)) {
                return;
            }
            // pretty sure registering is only needed for win32 c++ but just keeping it
            int id = _registrar == null ? 0 : _registrar.RegisterFormat(format);
            _formatLookup.Add(format);
            //MpConsole.WriteLine($"Successfully registered format name:'{format}' id:{id}");
        }

        public static void UnregisterDataFormat(string format) {
            _formatLookup.Remove(format);
        }

        #endregion
    }
}
