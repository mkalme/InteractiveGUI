using System;
using System.Drawing;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class ColorInput : InputAttribute {
        public override bool TryParse(IInteractiveProperty property, out object output) {
            output = null;
            if (property.Control.GetType() != typeof(ColorPanel)) return false;

            output = ((ColorPanel)property.Control).SelectedColor;
            return true;
        }

        public override Control CreateControl(IInteractiveProperty property) {
            Color color = ValueHelper.GetValue(property.GetValue(), Color.Empty);

            return new ColorPanel(color);
        }
    }
}
