using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class ObjectParser : IObjectParser {
        public bool TryParse(IInteractiveProperty[] layout) {
            (bool, object)[] parsedValues = new (bool, object)[layout.Length];

            for (int i = 0; i < layout.Length; i++) {
                var property = layout[i];

                bool parsed = TryParse(property, out object output);
                parsedValues[i] = (parsed, output);
            }

            if (NotifyOfUnparsedValues(parsedValues, layout)) return false;

            for (int i = 0; i < layout.Length; i++) {
                var property = layout[i];
                var value = parsedValues[i].Item2;

                var result = property.Validator.Validate(value);
                if (result) {
                    property.SetValue(value);
                } else {
                    NotifyOfInvalidValue(property, result.ErrorMessage);
                    return false;
                }
            }

            return true;
        }

        private bool NotifyOfUnparsedValues((bool, object)[] values, IInteractiveProperty[] layout) {
            List<string> names = new List<string>(values.Length);

            int index = 0;
            foreach (var value in values) {
                if (value.Item1) {
                    index++;
                    continue;
                }

                names.Add(layout.ElementAt(index).DisplayName);
                index++;
            }

            if (names.Count > 0) {
                string title = "Some inputs couldn't be parsed.";
                string message = $"The following inputs couldn't be parsed:\n{string.Join(", ", names)}";

                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return names.Count > 0;
        }
        private void NotifyOfInvalidValue(IInteractiveProperty property, string errorMsg) {
            string title = "The input is invalid.";
            string message = $"The following input couldn't be validated: {property.DisplayName}\nError message: {errorMsg}";

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected virtual bool TryParse(IInteractiveProperty property, out object output) {
            return property.ControlInput.TryParse(property, out output);
        }
    }
}
