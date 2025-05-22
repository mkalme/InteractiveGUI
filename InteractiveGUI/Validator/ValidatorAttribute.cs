using System;

namespace InteractiveGUI {
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ValidatorAttribute : Attribute {
        public abstract ValidateResult Validate(object input);
    }
}
