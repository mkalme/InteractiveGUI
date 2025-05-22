using System;
using System.Windows.Forms;

namespace InteractiveGUI {
    public abstract class InteractivePropertyBase : IInteractiveProperty {
        public abstract Type Type { get; }

        public object Owner { get; set; }
        public string DisplayName { get; set; }
        public Control Control { get; set; }
        public InputAttribute ControlInput { get; set; }
        public ValidatorAttribute Validator { get; set; }

        public abstract void SetValue(object value);
        public abstract object GetValue();
    }
}
