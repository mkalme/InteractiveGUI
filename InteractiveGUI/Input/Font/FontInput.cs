using System;
using System.Drawing;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class FontInput : InputAttribute {
        public override bool TryParse(IInteractiveProperty property, out object output) {
            output = null;
            if (property.Control.GetType() != typeof(FontPanel)) return false;

            output = (property.Control as FontPanel).SelectedFont;
            return true;
        }

        public override Control CreateControl(IInteractiveProperty property) {
            Font font = ValueHelper.GetValue(property.GetValue(), new Font("Segoe UI", 10));

            return new FontPanel(font);
        }
    }
}
