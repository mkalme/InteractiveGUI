using System;
using System.Reflection;

namespace InteractiveGUI {
    class ConstructorItem {
        public ParameterInfo[] Parameters { get; set; }
        public IInteractiveProperty[] Layout { get; set; }
        public string DisplayText { get; set; }

        public Func<object[], object> Invoker { get; set; }

        public ConstructorItem(string displayText) {
            DisplayText = displayText;
        }

        public override string ToString() {
            return DisplayText;
        }
    }
}
