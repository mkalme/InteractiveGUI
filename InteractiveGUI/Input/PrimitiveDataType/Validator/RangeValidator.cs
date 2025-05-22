using System;

namespace InteractiveGUI {
    public class RangeValidator : ValidatorAttribute {
        public long Min { get; set; }
        public long Max { get; set; }

        public RangeValidator(long min, long max) {
            Min = min;
            Max = max;
        }

        public override ValidateResult Validate(object input) {
            if (input.GetType() != typeof(int)) {
                return new ValidateResult(false, "Wrong datatype.");
            }

            int value = (int)input;
            bool valid = value >= Min && value <= Max;

            return new ValidateResult(valid, valid ? "" : $"The input is not in the supported range: {Min} min, {Max} max.");
        }
    }
}
