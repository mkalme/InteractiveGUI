using System;

namespace InteractiveGUI {
    public class InteractiveVariable : InteractivePropertyBase {
        public override Type Type => Owner.GetType();

        public override void SetValue(object value) {
            Owner = value;
        }
        public override object GetValue() {
            return Owner;
        }
    }
}
