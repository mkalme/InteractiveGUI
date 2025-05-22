using System;
using System.Reflection;

namespace InteractiveGUI {
    public class InteractiveParameter : InteractivePropertyBase {
        public ParameterInfo Parameter { get; set; }

        public override Type Type => Parameter.ParameterType;

        public InteractiveParameter(ParameterInfo parameter) {
            Parameter = parameter;
        }

        public override void SetValue(object value) {
            Owner = value;
        }
        public override object GetValue() {
            return Owner;
        }
    }
}
