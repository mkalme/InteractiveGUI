using System;
using System.Reflection;

namespace InteractiveGUI {
    public class InteractiveStructProperty : InteractivePropertyBase {
        public override Type Type => Property.PropertyType;

        public PropertyInfo Property { get; set; }

        private object _value;

        public InteractiveStructProperty(PropertyInfo property, string displayName, InputAttribute controlInput, ValidatorAttribute validator) {
            Property = property;
            DisplayName = displayName;
            ControlInput = controlInput;
            Validator = validator;
        }

        public override void SetValue(object value) {
            _value = value;
            Property.SetValue(Owner, _value);
        }
        public override object GetValue() {
            if (_value == null) _value = Property.GetValue(Owner);
            return _value;
        }
    }
}
