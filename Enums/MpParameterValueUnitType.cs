namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// The intended format for the <see cref="MpParameterFormat.value"/> or <see cref="MpParameterFormat.values"/>. See specific types for details. Many combinations of <see cref="MpParameterValueUnitType"/> and <see cref="MpParameterControlType"/> will be ignored.
    /// </summary>
    public enum MpParameterValueUnitType {
        None = 0,
        /// <summary>
        /// A true or false value
        /// </summary>
        Bool,
        /// <summary>
        /// A counting number. Used in conjunction with <see cref="MpParameterControlType.Slider"/> for integer sliders
        /// </summary>
        Integer,
        /// <summary>
        /// A double-precision number. Used in conjunction with <see cref="MpParameterControlType.Slider"/> for decimal sliders
        /// </summary>
        Decimal,
        /// <summary>
        /// A plain text string. 
        /// </summary>
        PlainText,
        /// <summary>
        /// Used in conjunction with <see cref="MpParameterControlType.DateTimePicker"/> for a date selector
        /// </summary>
        Date,
        /// <summary>
        /// Used in conjunction with <see cref="MpParameterControlType.DateTimePicker"/> for a time selector
        /// </summary>
        Time,
        /// <summary>
        /// Used internally. Not relavant for any controls
        /// </summary>
        FileSystemPath,
        /// <summary>
        /// A string substitution value replacing "{query_key_name_here>}" with the query result from some clip as <b>plain text</b>.<br/> 
        /// Possible query key names are all <see cref="MpContentQueryPropertyPathType"/> keys. <br/><br/>
        /// <b>Example: </b>When paired with <see cref="MpParameterControlType.TextBox"/> the text box is given a query-field selector in the UI to simplify creating a content query. A useful hidden parameter may be a <see cref="MpParameterControlType.TextBox"/> with <see cref="MpParameterValueUnitType.PlainTextContentQuery"/> and setting the default value to '{ClipText}' to then always receive the plain text of the input clip.<br/><br/>
        /// <b>Note: </b>Text outside of curly braces or curly braces without a matching <see cref="MpContentQueryPropertyPathType"/> will be treated as plain text.<br/><br/>
        /// </summary>
        PlainTextContentQuery,
        /// <summary>
        /// This is a convienence type converting that Html to plain text and then Uri encoding it. See <see cref="PlainTextContentQuery"/> for more info about content queries
        /// </summary>
        UriEscapedPlainTextContentQuery,
        /// <summary>        /// 
        /// Clips raw content is internally stored as follows: <br/>
        /// Text: Html fragments (blocks and inlines) <br/>
        /// Images: Base64 strings of the images bitmap <br/> 
        /// Files: A string of file system paths separated by environment new lines in plain text<br/><br/>
        /// See <see cref="PlainTextContentQuery"/> for more information about content queries
        /// </summary>
        RawDataContentQuery,
        /// <summary>
        /// Used with <see cref="MpParameterControlType.MultiSelectList"/> and <see cref="MpParameterControlType.EditableList"/> to receive a list of the selected <see cref="MpParameterValueFormat.value"/>'s. <br/><br/>To access the values as a list of strings use the extension method <see cref="MpPluginExtensions.GetRequestParamStringListValue(MpParameterMessageRequestFormat, string)"/> on the <see cref="MpMessageRequestFormatBase"/> parameter.
        /// </summary>
        DelimitedPlainText,
        /// <summary>
        /// Gives <see cref="MpParameterControlType.EditableList"/> entries individual content-query field selectors.<br/><br/> See <see cref="PlainTextContentQuery"/> and <see cref="DelimitedPlainText"/> for more info.
        /// </summary>
        DelimitedPlainTextContentQuery,
        /// <summary>
        /// Used internally for action parameters.
        /// </summary>
        CollectionComponentId,
        /// <summary>
        /// Used internally for action parameters.
        /// </summary>
        ActionComponentId,
        /// <summary>
        /// Used internally for action parameters.
        /// </summary>
        AnalyzerComponentId,
        /// <summary>
        /// Used internally for action parameters.
        /// </summary>
        ContentPropertyPathTypeComponentId,
        /// <summary>
        /// Used internally for action parameters.
        /// </summary>
        ApplicationCommandComponentId
    }

}
