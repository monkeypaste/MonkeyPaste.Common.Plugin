namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// The UI-element to reperesent the <see cref="MpParameterFormat.value"/> or <see cref="MpParameterFormat.values"/> depending on the type
    /// </summary>
    public enum MpParameterControlType {
        None = 0,
        /// <summary>
        /// A text input box. 
        /// <br/><b>Relevant Properties: </b><see cref="MpParameterFormat.minLength"/>,<see cref="MpParameterFormat.maxLength"/>, <see cref="MpParameterFormat.pattern"/> and <see cref="MpParameterFormat.patternInfo"/>
        /// </summary>
        TextBox,
        /// <summary>
        /// A masked text input box
        /// /// <br/><b>Relevant Properties: </b><see cref="MpParameterFormat.minLength"/>,<see cref="MpParameterFormat.maxLength"/>, <see cref="MpParameterFormat.pattern"/> and <see cref="MpParameterFormat.patternInfo"/>.
        /// </summary>
        PasswordBox,
        /// <summary>
        /// A single-select combo box
        /// </summary>
        ComboBox,
        /// <summary>
        /// A single-select list
        /// </summary>
        List,
        /// <summary>
        /// A toggle-style mutli-select list
        /// </summary>
        MultiSelectList,
        /// <summary>
        /// A variable length list where all values are treated as selected. Values can be predefined and/or created at runtime.
        /// </summary>
        EditableList,
        /// <summary>
        /// A true or false checkbox
        /// </summary>
        CheckBox,
        /// <summary>
        /// A decimal or integer value slider with default min/max values as 0/1 resepectively
        /// /// <br/><b>Relevant Properties: </b><see cref="MpParameterFormat.minimum"/>,<see cref="MpParameterFormat.maximum"/>,<see cref="MpParameterFormat.precision"/> and <see cref="MpParameterFormat.unitType"/>.
        /// </summary>
        Slider,
        /// <summary>
        /// A single file select dialog providing the file path as the value. Setting the <see cref="MpParameterValueFormat.label"/> will give the button a unique label.
        /// </summary>
        FileChooser,
        /// <summary>
        /// A single directory select dialog providing the directory path as the value. Setting the <see cref="MpParameterValueFormat.label"/> will give the button a unique label.
        /// </summary>
        DirectoryChooser,
        /// <summary>
        /// A date or time picker depending on the <see cref="MpParameterFormat.unitType"/> being <see cref="MpParameterValueUnitType.Time"/> or <see cref="MpParameterValueUnitType.Date"/>
        /// </summary>
        DateTimePicker,
        /// <summary>
        /// A uri-navigatible link where the <see cref="MpParameterValueFormat.value"/> should be an absolute uri and can optionally have a different display <see cref="MpParameterValueFormat.label"/>
        /// </summary>
        Hyperlink,
        /// <summary>
        /// Internal use only
        /// </summary>
        Button,
        /// <summary>
        /// Internal use only for now DO NOT USE
        /// </summary>
        ShortcutRecorder,

        /// <summary>
        /// Internal use only for now DO NOT USE
        /// </summary>
        ComponentPicker,
    }

}
