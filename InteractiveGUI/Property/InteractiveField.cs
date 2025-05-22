using System;
using System.Reflection;

namespace InteractiveGUI {
    public class InteractiveField : InteractivePropertyBase {
        public FieldInfo Field { get; set; }

        public override Type Type => Field.FieldType;

        public override void SetValue(object value) {
            Field.SetValue(Owner, value);
        }
        public override object GetValue() {
            return Field.GetValue(Owner);
        }
    }
}
