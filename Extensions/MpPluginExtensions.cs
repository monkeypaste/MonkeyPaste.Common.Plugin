using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// Helpers to simplify common plugin stuff
    /// </summary>
    public static class MpPluginExtensions {
        #region Private Variables

        private static Dictionary<Type, Func<MpPluginParameterRequestFormat, string, object>> typeConvLookup = new() {
            {typeof(bool),GetRequestParamBoolValue},
            {typeof(int),GetRequestParamIntValue},
            {typeof(double),GetRequestParamDoubleValue},
            {typeof(string),GetRequestParamStringValue},
            {typeof(List<string>),GetRequestParamStringListValue}
        };

        #endregion

        #region Public Methods

        #region Parsers
        public static string GetParamValue(this MpPluginParameterRequestFormat req, string paramId, string fallback = default) {
            return GetParamValue<string>(req, paramId, fallback);
        }
        public static T GetParamValue<T>(this MpPluginParameterRequestFormat req, string paramId, T fallback = default) {
            object result = null;
            if (typeConvLookup.TryGetValue(typeof(T), out var getter)) {
                result = getter.Invoke(req, paramId);
            } else {
                throw new NotSupportedException($"Type '{typeof(T)}' not supported. Conversion must be from one of the supported types: {string.Join(",", typeConvLookup.Select(x => x.Key.Name))}");
            }
            if (result == null) {
                result = fallback;
            }
            return (T)result;
        }
        public static DateTime ParseOrConvertToDateTime(this object obj, object fallback = null) {
            if (obj == default) {
                if (obj == fallback) {
                    return default;
                }
                return fallback.ParseOrConvertToDateTime(fallback);
            }
            if (obj == fallback) {
                if (fallback == null) {
                    return default;
                }
            }
            if (obj is DateTime dt) {
                return dt;
            }

            // stored as ticks
            long ticks = obj.ParseOrConvertToLong(fallback);
            return new DateTime(ticks);
        }
        public static TimeSpan ParseOrConvertToTimeSpan(this object obj, object fallback = null) {
            if (obj == default) {
                if (obj == fallback) {
                    return default;
                }
                return fallback.ParseOrConvertToTimeSpan(fallback);
            }
            if (obj == fallback) {
                if (fallback == null) {
                    return default;
                }
            }
            // stored as ticks
            long ticks = obj.ParseOrConvertToLong(fallback);
            return TimeSpan.FromTicks(ticks);
        }
        public static double ParseOrConvertToDouble(this object obj, object fallback = null) {
            if (obj == null) {
                if (obj == fallback) {
                    return 0;
                }
                return fallback.ParseOrConvertToDouble(fallback);
            }
            if (obj == fallback) {
                if (fallback == null) {
                    return 0;
                }
            }
            if (obj is double dblObj) {
                return dblObj;
            }
            if (obj is float fltObj) {
                return (double)fltObj;
            }

            if (obj is int intObj) {
                return (double)intObj;
            }

            if (obj is byte byteObj) {
                return (double)byteObj;
            }
            if (obj is bool boolObj) {
                return boolObj ? 1 : 0;
            }

            if (obj is TimeSpan tsObj) {
                return (double)tsObj.Ticks;
            }
            if (obj is string strObj) {
                if (string.IsNullOrEmpty(strObj)) {
                    if (obj == fallback) {
                        return 0;
                    }
                    return fallback.ParseOrConvertToDouble(fallback);
                }
                if (double.TryParse(strObj, out double dblVal)) {
                    return dblVal;
                }
                if (obj == fallback) {
                    return 0;
                }
                return fallback.ParseOrConvertToDouble(fallback);
            }
            Console.WriteLine($"Unknown obj type '{obj.GetType()}', cannot convert double. Returning 0");
            Debugger.Break();
            return 0;
        }
        public static long ParseOrConvertToLong(this object obj, object fallback = null) {
            if (obj == null) {
                if (obj == fallback) {
                    return 0;
                }
                return fallback.ParseOrConvertToLong(fallback);
            }
            if (obj == fallback) {
                if (fallback == null) {
                    return 0;
                }
            }
            if (obj is long lngObj) {
                return lngObj;
            }
            if (obj is TimeSpan ts) {
                return ts.Ticks;
            }
            if (obj is DateTime dt) {
                return dt.Ticks;
            }
            if (obj is string strObj && long.TryParse(strObj, out long lngVal)) {
                return lngVal;
            }

            return obj.ParseOrConvertToInt(fallback);
        }

        public static int ParseOrConvertToInt(this object obj, object fallback = null) {
            if (obj == null) {
                if (obj == fallback) {
                    return 0;
                }
                return fallback.ParseOrConvertToInt(fallback);
            }
            if (obj == fallback) {
                if (fallback == null) {
                    return 0;
                }
            }

            if (obj is int intObj) {
                return intObj;
            }
            if (obj is char charObj) {
                return (int)char.GetNumericValue(charObj);
            }
            if (obj is double dblObj) {
                return (int)dblObj;
            }
            if (obj is float fltObj) {
                return (int)fltObj;
            }
            if (obj is byte byteObj) {
                return (int)byteObj;
            }
            if (obj is bool boolObj) {
                return boolObj ? 1 : 0;
            }
            if (obj is TimeSpan tsObj) {
                return (int)tsObj.Ticks;
            }
            if (obj is long lngObj) {
                return (int)lngObj;
            }
            if (obj is string strObj) {
                return (int)obj.ParseOrConvertToDouble(fallback);
            }

            Console.WriteLine($"Unknown obj type '{obj.GetType()}', cannot convert int. Returning 0");
            Debugger.Break();
            return 0;
        }
        public static bool ParseOrConvertToBool(this object obj, object fallback = null) {
            if (obj == null) {
                if (obj == fallback) {
                    return false;
                }
                return fallback.ParseOrConvertToBool(fallback);
            }
            if (obj == fallback) {
                if (fallback == null) {
                    return false;
                }
            }
            if (obj is bool boolObj) {
                return boolObj;
            }
            if (obj is string strObj) {
                if (string.IsNullOrEmpty(strObj)) {
                    if (obj == fallback) {
                        return false;
                    }
                    return fallback.ParseOrConvertToBool(fallback);
                }
                if (strObj == "0") {
                    return false;
                }
                if (strObj == "1") {
                    return true;
                }
                if (bool.TryParse(strObj, out bool boolVal)) {
                    return boolVal;
                }

                if (obj == fallback) {
                    return false;
                }
                return fallback.ParseOrConvertToBool(fallback);
            }

            Console.WriteLine($"Unknown obj type '{obj.GetType()}', cannot convert bool. Returning 0");
            Debugger.Break();
            return false;
        }
        #endregion

        #region Csv

        public static MpCsvFormatProperties GetControlCsvProps(this MpParameterControlType controlType) {
            return IsControlTypeMultiValue(controlType) ?
                MpCsvFormatProperties.DefaultBase64Value :
                MpCsvFormatProperties.Default;
        }

        public static bool IsControlTypeMultiValue(this MpParameterControlType controlType) {
            return
                controlType == MpParameterControlType.MultiSelectList ||
                controlType == MpParameterControlType.EditableList;
        }
        public static bool IsControlCsvValue(this MpParameterControlType controlType) {
            return GetControlCsvProps(controlType).IsValueBase64;
        }

        #endregion


        #endregion

        #region Private Methods
        #region Param Parse Wrappers

        private static object GetRequestParamBoolValue(this MpPluginParameterRequestFormat req, string paramId) {
            var kvp = ValidateGet(req, paramId);
            return kvp.paramValue.ParseOrConvertToBool();
        }

        private static object GetRequestParamIntValue(this MpPluginParameterRequestFormat req, string paramId) {
            var kvp = ValidateGet(req, paramId);
            return kvp.paramValue.ParseOrConvertToInt();
        }

        private static object GetRequestParamDoubleValue(this MpPluginParameterRequestFormat req, string paramId) {
            var kvp = ValidateGet(req, paramId);
            return kvp.paramValue.ParseOrConvertToDouble();
        }

        private static object GetRequestParamStringValue(this MpPluginParameterRequestFormat req, string paramId) {
            var kvp = ValidateGet(req, paramId);
            return kvp.paramValue;
        }

        private static object GetRequestParamStringListValue(this MpPluginParameterRequestFormat req, string paramId) {
            var kvp = ValidateGet(req, paramId);
            return kvp.paramValue.ToListFromCsv(MpCsvFormatProperties.DefaultBase64Value);
        }
        #endregion

        private static MpParameterRequestItemFormat ValidateGet(MpPluginParameterRequestFormat req, string paramId) {
            if (paramId == null) {
                throw new NullReferenceException("paramId is null, must have paramValue");
            }
            if (req == null ||
                req.items == null) {
                throw new NullReferenceException($"Request error, no data");
            }

            var kvp = req.items.FirstOrDefault(x => x.paramId.ToString().Equals(paramId.ToString()));
            if (kvp == null) {
                throw new NullReferenceException($"param '{paramId}' not found");
            }
            return kvp;
        }
        #endregion
    }
}
