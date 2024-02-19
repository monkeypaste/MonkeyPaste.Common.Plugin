using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MonkeyPaste.Common.Plugin {
    /// <summary>
    /// A quill delta (https://github.com/blushingpenguin/Quill.Delta/)<br/>
    /// With these custom attributes: <br/>
    /// tables (https://github.com/soccerloway/quill-better-table) <br/>
    /// template embed blots (https://www.monkeypaste.com/docs/templates)<br/>
    /// </summary>
    public class MpQuillDelta : MpAnnotationNodeFormat {
        /// <summary>
        /// The annotation operations
        /// </summary>
        public List<MpQuillOp> ops { get; set; } = [];
        public override List<MpAnnotationNodeFormat> children {
            get => ops.Cast<MpAnnotationNodeFormat>().ToList();
            set => ops = value.Cast<MpQuillOp>().ToList();
        }

    }

    public class MpQuillOp : MpTextAnnotationNodeFormat {
        /// <summary>
        /// This can be text or something custom like <see cref="MpQuillImageInsert"/>
        /// </summary>
        public object insert { get; set; }
        /// <summary>
        /// The style information for this op on the range defined by <see cref="format"/>
        /// </summary>
        public MpQuillAttributes attributes { get; set; }
        /// <summary>
        /// The range to format with <see cref="attributes"/>
        /// </summary>
        public MpQuillDeltaRange format { get; set; }
        /// <summary>
        /// The count of plain text characters to delete for this op
        /// </summary>
        public int? delete { get; set; }
        /// <summary>
        /// The relative offset count in plain text characters for this op
        /// </summary>
        public int? retain { get; set; }

        [JsonIgnore]
        public override MpITextRange Range =>
            format;

    }

    public class MpQuillDeltaRange : MpITextRange {
        public int index { get; set; }
        public int length { get; set; }

        [JsonIgnore]
        int MpITextRange.Offset =>
            index;

        [JsonIgnore]
        int MpITextRange.Length =>
            length;
    }
    public class MpQuillAttributes {
        public string align { get; set; }
        public int? indent { get; set; }
        public string templateGuid { get; set; }
        public bool? isFocus { get; set; }
        public string templateName { get; set; }
        public string templateColor { get; set; }
        public string templateText { get; set; }
        public string templateType { get; set; }
        public string templateData { get; set; }
        public string templateDeltaFormat { get; set; }
        public string templateHtmlFormat { get; set; }
        public bool? wasVisited { get; set; }
        public bool? italic { get; set; }
        public bool? bold { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public string background { get; set; }
        public string list { get; set; }
        public string link { get; set; }
        public string linkType { get; set; }

        [JsonProperty("table-col")]
        public MpQuillTableCol tablecol { get; set; }

        [JsonProperty("table-cell-line")]
        public MpQuillTableCellLine tablecellline { get; set; }
        public string row { get; set; }
        public string rowspan { get; set; }
        public string colspan { get; set; }

        // non-quill attributes

        public string rect { get; set; }
        public string tag { get; set; }
    }



    public class MpQuillImageInsert {
        public string image { get; set; }
    }


    public class MpQuillTableCellLine {
        public string rowspan { get; set; }
        public string colspan { get; set; }
        public string row { get; set; }
        public string cell { get; set; }
    }

    public class MpQuillTableCol {
        public string width { get; set; }
    }


}
