using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace MonkeyPaste.Common.Plugin {

    public static class MpPortableDataFormats {
        #region Private Variables

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
        public const string INTERNAL_CONTENT_UTC_TIMESTAMP_FORMAT = "Mp Internal UTC TIMESTAP Format";


        // NOTE data object is not registered and only used to merge data objects
        public const string INTERNAL_DATA_OBJECT_SOURCE_TYPE_FORMAT = "Mp Internal Data Object Source Type Format";
        public const string INTERNAL_DATA_OBJECT_FORMAT = "Mp Internal Data Object Format";

        public const string PLACEHOLDER_DATAOBJECT_TEXT = "3acaaed7-862d-47f5-8614-3259d40fce4d";
        #endregion

        #region Runtime formats

        public static string Text =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                MacText1 :
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                    WinText1 :
                    RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ?
                    LinuxText1 :
                    AvText;

        public static string Text2 =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                MacText2 :
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                    WinText2 :
                    RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ?
                    LinuxText2 :
                    AvText;
        public static string Text3 =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                MacText3 :
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                    WinText3 :
                    RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ?
                    LinuxText3 :
                    AvText;

        public static string Rtf =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                MacRtf1 :
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                    WinRtf :
                    WinRtf;

        public static string Image =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                MacImage1 :
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                    WinImage1 :
                    RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ?
                        LinuxImage1 :
                        AvImage;

        public static string Image2 =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                MacImage2 :
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                    WinImage2 :
                    RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ?
                        LinuxImage2 :
                        AvImage;

        public static string Files =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                MacFiles1 :
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                    WinFiles1 :
                    RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ?
                        LinuxFiles1 :
                        AvFiles;

        public static string Files2 =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ?
                MacFiles2 :
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                    WinFiles2 :
                    RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ?
                        LinuxFiles2 :
                        AvFiles;
        public static string Csv =>
            WinCsv;

        public static string Html =>
            MimeHtml;
        public static string Xhtml =>
            WinHtml1;

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
        public static IEnumerable<string> PlainTextFormats =>
            _plainTextFormats.Distinct();

        private static string[] _rtfFormats = [
            MacRtf1,
            MacRtf2,
            WinRtf,
            ];
        public static IEnumerable<string> RtfFormats =>
            _rtfFormats.Distinct();

        private static string[] _csvFormats = [
            WinCsv,
            ];

        public static IEnumerable<string> CsvFormats =>
            _csvFormats.Distinct();
        private static string[] _htmlFormats = [
            LinuxHtml,
            MacHtml1,
            MacHtml2,
            MimeHtml,
            WinHtml1,
            WinHtml2,
            ];

        public static IEnumerable<string> HtmlFormats =>
            _htmlFormats.Distinct();
        public static IEnumerable<string> TextFormats =>
            // NOTE these are ordered from least to highest 'fidelity' as for rendering priority:
            // text,csv,rtf,html
            _plainTextFormats
            .Union(_csvFormats)
            .Union(_rtfFormats)
            .Union(_htmlFormats);

        private static string[] _imageFormats = [
            AvImage,
            LinuxImage2,
            LinuxImage3,
            WinImage2,
            WinImage3,
            MacImage2,
            MacImage3,
            ];
        public static IEnumerable<string> ImageFormats =>
            _imageFormats.Distinct();

        private static string[] _fileFormats = [
            LinuxFiles2,
            LinuxFiles2,
            MacFiles2,
            MacFiles3,
            WinFiles2
            ];
        public static IEnumerable<string> FileFormats =>
            _fileFormats.Distinct();

        static string[] _AllInternalFormats = [
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
                    ];
        public static IEnumerable<string> AllInternalFormats {
            get {
                if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                    return _AllInternalFormats.Distinct().Where(x => x != INTERNAL_SOURCE_URI_LIST_FORMAT);
                }
                return _AllInternalFormats.Distinct();
            }
        }
        #endregion

        #region Properties       
        #endregion

        #region Public Methods        
        #endregion

        #region Private Methods
        #endregion
    }
}
