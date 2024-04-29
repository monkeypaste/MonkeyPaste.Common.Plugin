using Newtonsoft.Json;
using System;
using System.Text;

namespace MonkeyPaste.Common.Plugin {
    public static class MpJsonExtensions {
        #region Serialize
        public static string SerializeObject(this object obj, bool omitNulls = false) {
            return SerializeObject_internal(obj, omitNulls ? new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore } : null);
        }


        public static string SerializeObjectToBase64(this object obj, bool omitNulls = false, Encoding enc = null) {
            string jsonStr = SerializeObject(obj, omitNulls);
            string base64Str = jsonStr.ToBase64String(enc);
            return base64Str;
        }

        private static string SerializeObject_internal(object obj, JsonSerializerSettings settings = null, Encoding enc = null) {
            if (obj == null) {
                return string.Empty;
            }
            try {
                return JsonConvert.SerializeObject(obj, settings);
            }
            catch (Exception ex) {
                Console.WriteLine($"Error serializing type '{obj.GetType()}':");
                Console.WriteLine(ex.ToString());
                return string.Empty;
            }
        }
        #endregion

        #region Deserialize


        public static T DeserializeObject<T>(this string obj) where T : new() {
            if (obj is string objStr) {
                try {
                    return JsonConvert.DeserializeObject<T>(objStr);
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error deserializing str: {objStr}");
                    Console.WriteLine(ex.ToString());
                }

            }
            return new T();
        }

        public static T DeserializeBase64Object<T>(this string obj, Encoding enc = null) where T : new() {
            return DeserializeBase64Object_internal<T>(obj, enc);
        }
        private static T DeserializeBase64Object_internal<T>(object obj, Encoding enc = null) where T : new() {
            if (obj is string objBase64Str && !string.IsNullOrWhiteSpace(objBase64Str)) {
                try {
                    string objStr = objBase64Str.ToStringFromBase64(enc);
                    return objStr.DeserializeObject<T>();
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error deserializing base64 str: {objBase64Str}");
                    Console.WriteLine(ex.ToString());
                }
            }
            return new T();
        }
        #endregion

    }
}
