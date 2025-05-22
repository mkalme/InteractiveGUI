using System;

namespace InteractiveGUI {
    public interface ILayoutCreator {
        IInteractiveProperty[] CreateLayout(object source);
    }
}
