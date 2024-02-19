using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// The static model (or format) of an argument for a plugin that requires information and/or interaction from the host-application. Like an HTML form element, they can be hidden or visible and may have rules for acceptable valeus.
    /// </summary>
    public class MpParameterFormat : MpIParamterValueProvider {
        #region Interfaces

        #region MpIParameterValueProvider Implementation
        [JsonIgnore]
        string MpIParamterValueProvider.ParamId => paramId;
        [JsonIgnore]
        string MpIParamterValueProvider.Value {
            get {
                if (values == null || values.Count == 0) {
                    return string.Empty;
                }
                if (values.Where(x => x.isDefault).Count() > 0) {
                    return values.Select(x => x.value).ToCsv(CsvProps);
                }
                return values.First().value;
            }
        }
        #endregion

        #endregion
        private string _paramId = null;
        /// <summary>
        /// When unset will fallback to a <see cref="string"/> representation of the parameter's <see cref="int"/> index
        /// </summary>
        public string paramId {
            get {
                if (string.IsNullOrEmpty(_paramId)) {
                    // fallback
                    _paramId = label;
                }
                return _paramId;
            }
            set {
                if (!string.IsNullOrEmpty(value) && paramId != value) {
                    // don't let omitted/empty name become paramValue
                    _paramId = value;
                }
            }
        }
        /// <summary>
        /// Used to identitify the <see cref="value"/>
        /// </summary>
        public string label { get; set; } = string.Empty;
        /// <summary>
        /// The placeholder text for <see cref="MpParameterControlType.TextBox"/> and <see cref="MpParameterControlType.PasswordBox"/> <see cref="controlType"/>'s
        /// </summary>
        public string placeholder { get; set; } = string.Empty;
        /// <summary>
        /// A short hint to help user understand this parameters purpose or usage
        /// </summary>
        public string description { get; set; } = string.Empty;
        /// <summary>
        /// (Defaults to <see cref="MpParameterControlType.TextBox"/>) The UI-element representing this parameters <see cref="value"/>
        /// </summary>
        public MpParameterControlType controlType { get; set; } = MpParameterControlType.TextBox;
        /// <summary>
        /// (Defaults to <see cref="MpParameterValueUnitType.PlainText"/>) Instructs host application on how to prepare the <see cref="value"/> received during a plugin request.<br/><b>Note:</b>Some combinations of <see cref="unitType"/> and <see cref="controlType"/> are not supported or currently limited to host-only behavior. See <a href="https://www.monkeypaste.com/docs/plugins">docs</a> for more info.
        /// </summary>
        public MpParameterValueUnitType unitType { get; set; } = MpParameterValueUnitType.PlainText;
        /// <summary>
        /// (Default is false) When true, this parameter will only be presented to the user <i>directly</i> before a plugin request. <see cref="isExecuteParameter"/> is primarily useful for crediantial data so a plugins parameter form is less cluttred and only shows actionable items.<br/><br/><b>Note: </b><see cref="isExecuteParameter"/> is intended to be used in conjunction with <see cref="isSharedValue"/> but is not required.
        /// </summary>
        public bool isExecuteParameter { get; set; }
        /// <summary>
        /// (Default is false) When true the <see cref="value"/> becomes static across all <see cref="MpPresetFormat"/>'s
        /// </summary>
        public bool isSharedValue { get; set; }
        /// <summary>
        /// (Default is false) Allows <see cref="values"/> to be determined at runtime. When true your plugin must implement <see cref="MpISupportDeferredValue"/> or <see cref="MpISupportDeferredValueAsync"/> where you will receive this parameters <see cref="paramId"/> in the <see cref="MpDeferredParameterValueRequestFormat"/> request. 
        /// </summary>
        public bool isValueDeferred { get; set; }
        /// <summary>
        /// (Default is true) Determines if this parameters UI-element is hidden from the user or not
        /// </summary>
        public bool isVisible { get; set; } = true;
        /// <summary>
        /// (Default is false) User interaction will be disabled when true and if <see cref="controlType"/> is <see cref="MpParameterControlType.TextBox"/> the value will appear like a TextBlock instead
        /// </summary>
        public bool isReadOnly { get; set; } = false;
        /// <summary>
        /// (Default is false) When true and value is not provided the parameter form will invalidate before your plugin will receive a request
        /// </summary>
        public bool isRequired { get; set; } = false;
        /// <summary>
        ///  (Default is false) Since values are stored (remembered) by default. A Use case for <see cref="canRemember"/> would be when this an <see cref="isExecuteParameter"/> and user may not want store their input for next time.
        /// </summary>
        public bool canRemember { get; set; } = false;

        //TextBox
        /// <summary>
        /// (Default is <see cref="int.MaxValue"/>) Can be useful for <see cref="MpParameterControlType.TextBox"/> controls for validation
        /// </summary>
        public int maxLength { get; set; } = int.MaxValue;
        /// <summary>
        /// (Default is 0) Can be useful for <see cref="MpParameterControlType.TextBox"/> controls for validation
        /// </summary>
        public int minLength { get; set; } = 0;
        /// <summary>
        /// An optional regular expression compared to the string value you would receive from a request for validation. The regular expression must then result in a <b>match</b> for this parameter to be valid.
        /// </summary>
        public string pattern { get; set; } = string.Empty;
        /// <summary>
        /// Used in conjunction with <see cref="pattern"/> to provide information about why the input is not valid
        /// </summary>
        public string patternInfo { get; set; } = string.Empty;

        //Slider
        /// <summary>
        /// (Default is 0) Used when <see cref="controlType"/> is <see cref="MpParameterControlType.Slider"/> for the minimum threshold as a decimal value
        /// </summary>
        public double minimum { get; set; } = 0;
        /// <summary>
        ///  (Default is 1) Used when <see cref="controlType"/> is <see cref="MpParameterControlType.Slider"/> for the maximum threshold as a decimal value
        /// </summary>
        public double maximum { get; set; } = 1;
        /// <summary>
        /// (Default is 2) Used when <see cref="controlType"/> is <see cref="MpParameterControlType.Slider"/> and <see cref="unitType"/> is <see cref="MpParameterValueUnitType.Decimal"/> to clamp the values digits after the deciaml place.
        /// </summary>
        public int precision { get; set; } = 2;

        /// <summary>
        /// A container for single-value <see cref="controlType"/>'s default string representation <br/><br/><b>Note: </b>Only <see cref="value"/> or <see cref="values"/> can be defined <b>not both</b>.
        /// </summary>
        public MpParameterValueFormat value { private get; set; }


        private List<MpParameterValueFormat> _values;
        /// <summary>
        /// A list of possible default values for this parameter. 
        /// </summary>
        public List<MpParameterValueFormat> values {
            get {
                if (_values == null) {
                    _values = new List<MpParameterValueFormat>();
                    if (value != null) {
                        value.isDefault = true;
                        _values.Add(value);
                    }
                }
                return _values;
            }
            set => _values = value;
        }

        /// <summary>
        /// Used internally when decoding multi-value parameters
        /// </summary>
        [JsonIgnore]
        public MpCsvFormatProperties
            CsvProps => controlType.GetControlCsvProps();
    }

}
