using System;
using System.Reflection;
using System.Windows.Forms;

namespace InteractiveGUI {    
    public class InteractiveProperty : InteractivePropertyBase {
        public PropertyInfo Property { get; set; }

        public override Type Type => Property.PropertyType;

        public InteractiveProperty(PropertyInfo property, string displayName, InputAttribute controlInput, ValidatorAttribute validator) {
            Property = property;
            DisplayName = displayName;
            ControlInput = controlInput;
            Validator = validator;
        }

        public override object GetValue() {
            return Property.GetValue(Owner);
        }
        public override void SetValue(object value) {
            Property.SetValue(Owner, value);
        }
    }
}
