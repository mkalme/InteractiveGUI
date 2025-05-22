using System;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class CheckBoxInput : InputAttribute {
        public override bool TryParse(IInteractiveProperty property, out object output) {
            output = null;
            if (property.Control.GetType() != typeof(CheckBox)) return false;

            output = ((CheckBox)property.Control).Checked;
            return true;
        }

        public override Control CreateControl(IInteractiveProperty property) {
            bool value = ValueHelper.GetValue(property.GetValue(), false);
            
            return new DarkCheckBox() {
                Text = "Yes",
                Checked = value,
                Padding = new Padding(0, 1, 0, 0)
            };
        }
    }
}
