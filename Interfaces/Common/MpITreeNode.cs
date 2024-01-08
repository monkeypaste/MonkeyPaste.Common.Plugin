using System.Collections.Generic;

namespace MonkeyPaste.Common.Plugin {
    public interface MpITreeNode : MpIExpandable {
        IEnumerable<MpITreeNode> Children { get; }
    }
}
