using System;

namespace InteractiveGUI {
    public class DefaultValidator : ValidatorAttribute {
        public override ValidateResult Validate(object input) {
            return true;
        }
    }
}
