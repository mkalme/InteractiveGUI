using System;
using System.Windows.Forms;

namespace InteractiveGUI {
    public abstract class InputAttribute : Attribute {
        public abstract bool TryParse(IInteractiveProperty property, out object output);
        public abstract Control CreateControl(IInteractiveProperty property);
    }
}
