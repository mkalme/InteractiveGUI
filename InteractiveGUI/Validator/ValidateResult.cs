using System;

namespace InteractiveGUI {
    public struct ValidateResult {
        public bool Validated { get; }
        public string ErrorMessage { get; }

        public static implicit operator ValidateResult(bool validated) => new ValidateResult(validated, "");
        public static implicit operator bool(ValidateResult result) => result.Validated;

        public ValidateResult(bool validated, string errorMessage) {
            Validated = validated;
            ErrorMessage = errorMessage;
        }
    }
}
