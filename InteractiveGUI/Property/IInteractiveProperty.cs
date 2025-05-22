using System;
using System.Windows.Forms;

namespace InteractiveGUI {
    public interface IInteractiveProperty {
        Type Type { get; }
        object Owner { get; set; }
        string DisplayName { get; set; }
        Control Control { get; set; }

        InputAttribute ControlInput { get; set; }
        ValidatorAttribute Validator { get; set; }

        void SetValue(object value);
        object GetValue();
    }
}
