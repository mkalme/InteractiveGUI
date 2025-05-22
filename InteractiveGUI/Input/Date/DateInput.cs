using System;
using System.Windows.Forms;

namespace InteractiveGUI {

    public class DateInput : InputAttribute {
        public override bool TryParse(IInteractiveProperty property, out object output) {
            output = null;
            if (property.Control.GetType() != typeof(DatePanel)) return false;

            output = ((DatePanel)property.Control).SelectedeDateTime;
            return true;
        }

        public override Control CreateControl(IInteractiveProperty property) {
            DateTime date = ValueHelper.GetValue(property.GetValue(), DateTime.MinValue);

            return new DatePanel() {
                SelectedeDateTime = date
            };
        }
    }
}
