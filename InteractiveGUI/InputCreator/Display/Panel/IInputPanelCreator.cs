using System;
using System.Windows.Forms;

namespace InteractiveGUI {
    public interface IInputPanelCreator {
        Panel CreatePanel(IInteractiveProperty[] layout);
    }
}
