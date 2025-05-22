using System;

namespace InteractiveGUI {
    public interface IObjectParser {
        bool TryParse(IInteractiveProperty[] layout);
    }
}
