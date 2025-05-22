using System;

namespace InteractiveGUI {

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class InteractiveAttribute : Attribute {
        public string DisplayName { get; set; }

        public InteractiveAttribute() {

        }
        public InteractiveAttribute(string displayText) {
            DisplayName = displayText;
        }
    }
}
