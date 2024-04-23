
using System.Collections.Generic;
using System.Linq;

namespace MonkeyPaste.Common.Plugin {


    public static class MpPortableDataFormats {
        #region Private Variables

        private static MpIPlatformDataObjectRegistrar _registrar;
        #endregion

        #region Constants

        #region Avalonia Formats

        public const string AvFiles = "Files";
        public const string AvImage = "PNG";
        public const string AvText = "Text";

        #endregion

        #region Windows Formats
        public const string WinText1 = AvText;
        public const string WinText2 = MimeText;
        public const string WinText3 = "Unicode";
        public const string WinText4 = "OEMText";

        public const string WinHtml1 = "HTML Format";
        public const string WinHtml2 = MimeHtml;

        public const string WinRtf = "Rich Text Format";

        public const string WinCsv = "CSV";

        public const string WinXaml = "Xaml";
        public const string WinXamlPackage = "XamlPackage";

        public const string WinFiles1 = AvFiles;
        public const string WinFiles2 = "FileDrop";

        public const string WinImage1 = AvImage;
        public const string WinImage2 = "Bitmap";
        public const string WinImage3 = "DeviceIndependentBitmap";
        #endregion

        #region Mac Formats
        public const string MacRtf1 = "public.rtf";
        public const string MacRtf2 = "com.apple.flat-rtfd";

        public const string MacText1 = AvText;
        public const string MacText2 = "public.utf8-plain-text";
        public const string MacText3 = "public.utf16-external-plain-text";
        public const string MacText4 = "public.plain-text";

        public const string MacHtml1 = "public.html";
        public const string MacHtml2 = "Apple HTML pasteboard type";

        public const string MacFiles1 = AvFiles;
        public const string MacFiles2 = "public.file-url";
        public const string MacFiles3 = "NSFilenamesPboardType";

        public const string MacUrl1 = "public.url";
        public const string MacUrl2 = "com.apple.webarchive";
        public const string MacChromeUrl1 = "org.chromium.source-url";
        // this formats on dnd from chrome on mac with the toplevel domain url as the content
        public const string MacChromeUrl2 = "org.chromium.chromium-renderer-initiated-drag";

        public const string MacImage1 = AvImage;
        public const string MacImage2 = "public.png";
        public const string MacImage3 = "public.tiff";
        #endregion

        #region Linux
        public const string LinuxText1 = AvText;
        public const string LinuxText2 = MimeText;
        public const string LinuxText3 = "text/unicode";
        public const string LinuxText4 = "UTF8_STRING";

        public const string LinuxHtml = MimeHtml;

        public const string LinuxImage1 = AvImage;
        public const string LinuxImage2 = "image/png";
        public const string LinuxImage3 = "image/bmp";
        public const string LinuxImage4 = "image/tiff";
        public const string LinuxImage5 = "image/x-bmp";

        public const string LinuxFiles1 = AvFiles;
        public const string LinuxFiles2 = MimeUriList;
        public const string LinuxFiles3 = "x-special/gnome-copied-files";

        #endregion

        #region Mime (inter-platform) formats
        public const string MimeHtml = "text/html";
        public const string MimeText = "text/plain";
        public const string MimeJson = "application/json";

        public const string MimeMozUrl = "text/x-moz-url-priv";
        public const string MimeUriList = "text/uri-list";
        #endregion

        #region Cef Formats

        //public const string CefDragData = "CefDragData";
        //public const string CefUnicodeUrl = "UniformResourceLocatorW";
        public const string CefAsciiUrl = "UniformResourceLocator";

        #endregion

        #region Internal Formats
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

        #region Runtime formats

        public const string Text =
#if MAC
            MacText1;
#elif WINDOWS
            WinText1;
#elif LINUX
            LinuxText1;
#else
            AvText;
#endif

        public const string Text2 =
#if WINDOWS
            WinText2;
#elif MAC
            MacText2;
#elif LINUX
            LinuxText2;
#else
            AvText;
#endif
        public const string Text3 =
#if WINDOWS
            WinText3;
#elif MAC
            MacText3;
#elif LINUX
            LinuxText3;
#else
            AvText;
#endif

        public const string Rtf =
#if WINDOWS
            WinRtf;
#elif MAC
            MacRtf1;
#else
            WinRtf;

#endif
        public const string Image =
#if WINDOWS
            WinImage1;
#elif MAC
            MacImage1;
#elif LINUX
            LinuxImage1;
#else
            AvImage;
#endif

        public const string Image2 =
#if WINDOWS
            WinImage2;
#elif MAC
            MacImage2;
#elif LINUX
            LinuxImage2;
#else
            AvImage;
#endif

        public const string Files =
#if WINDOWS
            WinFiles1;
#elif MAC
            MacFiles1;
#elif LINUX
            LinuxFiles1;
#else
            AvFiles;
#endif

        public const string Files2 =
#if WINDOWS
            WinFiles2;
#elif MAC
            MacFiles2;
#elif LINUX
            LinuxFiles2;
#else
            AvFiles;
#endif

        public const string Csv =
#if WINDOWS
            WinCsv;
#else
            WinCsv;
#endif

        public const string Html =
#if WINDOWS
            MimeHtml;
#else
            MimeHtml;
#endif
        public const string Xhtml =
#if WINDOWS
            WinHtml1;
#else
            WinHtml1;
#endif

        #endregion

        #endregion

        #region Format Groups


        private static string[] _plainTextFormats = [
            LinuxText2,
            LinuxText3,
            LinuxText4,
            MacText1,
            MacText2,
            MacText3,
            MacText4,
            MimeText,
            WinText1,
            WinText2,
            WinText3,
            WinText4,
            ];

        private static string[] _rtfFormats = [
            MacRtf1,
            MacRtf2,
            WinRtf,
            ];

        private static string[] _csvFormats = [
            WinCsv,
            ];

        private static string[] _htmlFormats = [
            LinuxHtml,
            MacHtml1,
            MacHtml2,
            MimeHtml,
            WinHtml1,
            WinHtml2,
            ];

        private static string[] _imageFormats = [
            LinuxImage2,
            LinuxImage3,
            LinuxImage4,
            WinImage1,
            WinImage2,
            WinImage3,
            MacImage2,
            MacImage3,
            ];
        public static string[] ImageFormats =>
            _imageFormats;

        private static string[] _fileFormats = [
            LinuxFiles2,
            LinuxFiles2,
            MacFiles2,
            MacFiles3,
            WinFiles2
            ];

        private static IEnumerable<string> _textFormats =>
            // NOTE these are ordered from least to highest 'fidelity' as for rendering priority:
            // text,csv,rtf,html
            _plainTextFormats
            .Union(_csvFormats)
            .Union(_rtfFormats)
            .Union(_htmlFormats);

        static string[] _AllInternalFormats = [
#if !LINUX
		                INTERNAL_SOURCE_URI_LIST_FORMAT,  
#endif
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
                    ];
        #endregion

        #region Properties

        public static string[] SortedTextFormats =>
            _textFormats.Distinct().ToArray();

        private static Dictionary<string,int> _regReaderLookup = new Dictionary<string,int>();
        public static IEnumerable<string> RegisteredReaderFormats =>
            _regReaderLookup.Where(x=>x.Value > 0).Select(x=>x.Key);

        private static Dictionary<string,int> _regWriterLookup = new Dictionary<string,int>();
        public static IEnumerable<string> RegisteredWriterFormats =>
            _regWriterLookup.Where(x=>x.Value > 0).Select(x=>x.Key);


        private static List<string> _regInternalFormats = [];
        public static IReadOnlyList<string> RegisteredInternalFormats =>
            _regInternalFormats;
        public static IEnumerable<string> RegisteredFormats =>
            RegisteredReaderFormats
            .Union(RegisteredWriterFormats)
            .Union(RegisteredInternalFormats)
            .Distinct();

        #endregion

        #region Public Methods

        public static void Init(MpIPlatformDataObjectRegistrar registrar) {
            _registrar = registrar;

            _regWriterLookup.Clear();
            _regReaderLookup.Clear();

            foreach (string formatName in _AllInternalFormats) {
                RegisterDataFormat(formatName, false, false);
            }
        }

        public static void RegisterDataFormat(string format, bool isReader, bool isWriter) {
            int result = -1;
            if(isReader) {
                result = Register_internal(_regReaderLookup, format);
            }
            if(isWriter) {
                result = Register_internal(_regWriterLookup, format);
            }

            if (!isReader && !isWriter) {
                // NOTE this should only happen for internal formats
                if (!_AllInternalFormats.Contains(format)) {
#if DEBUG
                    throw new System.Exception($"Non-internal format registration mismatch for '{format}'");
#endif
                } else if (!_regInternalFormats.Contains(format)) {
                    _regInternalFormats.Add(format);
                }
            }
            MpConsole.WriteLine($"Format '{format}' IsReader: {isReader} IsWriter: {isWriter} REGISTERED ({result})");
        }
        public static void UnregisterDataFormat(string format, bool isReader, bool isWriter) {
            int result = -1;
            if (isReader) {
                result = UnregisterFromLookup(_regReaderLookup, format);
            }
            if (isWriter) {
                result = UnregisterFromLookup(_regWriterLookup, format);
            }
            MpConsole.WriteLine($"Format '{format}' IsReader: {isReader} IsWriter: {isWriter} UNREGISTERED ({result})");
        }

        public static bool IsTextFormat(string format) {
            return SortedTextFormats.Contains(format);
        }
        public static bool IsPlainTextFormat(string format) {
            return _plainTextFormats.Contains(format);
        }
        
        public static bool IsRtfFormat(string format) {
            return _rtfFormats.Contains(format);
        }
        
        public static bool IsCsvFormat(string format) {
            return _csvFormats.Contains(format);
        }
        public static bool IsHtmlFormat(string format) {
            return _htmlFormats.Contains(format);
        }
        public static bool IsImageFormat(string format) {
            return _imageFormats.Contains(format);
        }
        
        public static bool IsFilesFormat(string format) {
            return _fileFormats.Contains(format);
        }
        
        public static bool IsFormatStrBase64(string format) {
            if(IsImageFormat(format) is true ||
                format == CefAsciiUrl) {
                return true;
            }
            return false;
        }
        public static bool IsAvaloniaFormat(string format) {
            return
                format == AvFiles ||
                format == AvImage ||
                format == AvText;
        }
        public static string GetDefaultFileExt(string format) {
            if(IsPlainTextFormat(format) is true) {
                return "txt";
            }
            if (IsHtmlFormat(format) is true) {
                return "html";
            }
            if(IsRtfFormat(format) is true) {
                return "rtf";
            }
            if(IsCsvFormat(format) is true) {
                return "csv";
            }
            if (format == MacImage3 ||
                format == LinuxImage4) {
                return "tiff";
            }
            if(format == LinuxImage3) {
                return "bmp";
            }
            if(IsImageFormat(format) is true) {
                return "png";
            }
            // fallback to txt
            return "txt";
        }
        #endregion

        #region Private Methods

        private static int UnregisterFromLookup(Dictionary<string, int> lookup, string format) {
            if (!lookup.TryGetValue(format, out int reg_count)) {
                return 0;
            }
            reg_count--;
            if (reg_count <= 0) {
                lookup.Remove(format);
            } else {
                lookup[format] = reg_count;
            }
            return reg_count;
        }
        private static int Register_internal(Dictionary<string, int> lookup, string format) {
            if (!lookup.TryGetValue(format, out int reg_count)) {
                reg_count = 1;
                lookup.Add(format, 0);
                if (_registrar != null) {
                    // pretty sure registering is only needed for win32 c++ but just keeping it
                    int id = _registrar.RegisterFormat(format);
                }
            } else {
                reg_count++;
            }
            lookup[format] = reg_count;

            return reg_count;
        }
        #endregion
    }
}
