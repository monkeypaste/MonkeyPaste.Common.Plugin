using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyPaste.Common.Plugin {
    public static class MpCsvExtensions {

        #region Csv
        public static string ToCsv(this IEnumerable<string> strList, MpICustomCsvFormat csvObj) {
            return ToCsv(strList, csvObj.CsvFormat);
        }
        public static string ToCsv(this IEnumerable<string> strList, MpCsvFormatProperties csvProps = null) {
            if (strList == null || !strList.Any()) {
                return string.Empty;
            }
            csvProps = csvProps == null ? MpCsvFormatProperties.Default : csvProps;
            return
                string.Join(
                    csvProps.EocSeparator,
                    strList.Select(x => csvProps.EncodeValue(x)));
        }
        public static List<string> ToListFromCsv(this string csvStr, MpICustomCsvFormat csvObj) {
            return ToListFromCsv(csvStr, csvObj.CsvFormat);
        }
        public static List<string> ToListFromCsv(this string csvStr, MpCsvFormatProperties csvProps = null) {
            csvProps = csvProps == null ? MpCsvFormatProperties.Default : csvProps;
            return
                csvStr.Split(new string[] { csvProps.EocSeparator }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => csvProps.DecodeValue(x))
                .ToList();
        }

        public static string AddCsvItem(this string csvStr, string item, bool allowDup = true, MpCsvFormatProperties csvProps = null) {
            csvProps = csvProps ?? MpCsvFormatProperties.Default;
            var items = csvStr.ToListFromCsv(csvProps);
            if (allowDup || !items.Contains(item)) {
                items.Add(item);
            }
            return items.ToCsv(csvProps);
        }

        public static string RemoveCsvItem(this string csvStr, string item, bool removeAll = true, MpCsvFormatProperties csvProps = null) {
            csvProps = csvProps ?? MpCsvFormatProperties.Default;
            var items = csvStr.ToListFromCsv(csvProps);
            List<string> to_remove = new();
            foreach (var curitem in items) {
                if (curitem == item && (removeAll || !to_remove.Any())) {
                    to_remove.Add(curitem);
                }
            }
            to_remove.ForEach(x => items.Remove(x));
            return items.ToCsv(csvProps);
        }

        #endregion
    }

    public class MpCsvFormatProperties {
        public static string EXCEL_EOF_MARKER = "\0"; // tested in excel 365 on windows csv terminates with \0 on a trailing line
        public static string CSV_DEFAULT_COLUMN_SEPARATOR = ",";
        public static string CSV_DEFAULT_ROW_SEPARATOR = Environment.NewLine;

        public static double CSV_DEFAULT_FORMATTED_FONT_SIZE = 14.0d;
        public static string CSV_DEFAULT_FORMATTED_FONT_FAMILY = "Consolas";

        public static MpCsvFormatProperties Default => new MpCsvFormatProperties();
        public static MpCsvFormatProperties DefaultBase64Value => new MpCsvFormatProperties() { IsValueBase64 = true };

        public string EocSeparator { get; set; } = CSV_DEFAULT_COLUMN_SEPARATOR;
        public string EorSeparator { get; set; } = CSV_DEFAULT_ROW_SEPARATOR;

        public double FormattedFontSize { get; set; } = CSV_DEFAULT_FORMATTED_FONT_SIZE;
        public string FormattedFontFamily { get; set; } = CSV_DEFAULT_FORMATTED_FONT_FAMILY;

        public bool IsValueBase64 { get; set; } = false;

        public Encoding ValueEncoding { get; set; } = null; // default/null resolves to UTF-8 (or tentatively based on locale)

        public string EncodeValue(string value) {
            //return IsValueBase64 ? paramValue.ToBase64String(ValueEncoding) : paramValue;
            return IsValueBase64 ?
                Convert.ToBase64String(Encoding.UTF8.GetBytes(value)) : value;
        }

        public string DecodeValue(string value) {
            if (IsValueBase64) {
                //if (!paramValue.IsStringBase64()) {
                //    // predefined values may not be encoded..
                //    return paramValue;
                //}
                //return paramValue.ToStringFromBase64(ValueEncoding);
                return Encoding.UTF8.GetString(Convert.FromBase64String(value));
            }
            return value;
        }
    }
    public interface MpICustomCsvFormat {
        MpCsvFormatProperties CsvFormat { get; }
    }
}
