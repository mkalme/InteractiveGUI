using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class TextPropertyInput : InputAttribute {
        public string[] Properties { get; set; }

        private IInteractiveProperty[] _interactiveProperties;
        private IPropertyCreator _propertyCreator = new PropertyCreator() { PropertyType = PropertyType.Default };
        private static readonly Regex _whitespaceRegex = new Regex(@"\s+");

        private ToolTip _toolTip = new ToolTip();

        public TextObjectParser TextObjectParser { get; set; } = new TextObjectParser();

        public TextPropertyInput(params string[] properties) {
            Properties = properties;
        }

        public override bool TryParse(IInteractiveProperty property, out object output) {
            output = null;
            if (property.Control.GetType() != typeof(DarkTextBox)) return false;

            TextObjectParser.Values = _whitespaceRegex.Replace(((DarkTextBox)property.Control).Text, "").Split(";");

            bool parsed = TextObjectParser.TryParse(_interactiveProperties);
            if (_interactiveProperties.Length > 0) {
                output = _interactiveProperties[0].Owner;
            } else {
                output = property.GetValue();
            }

            return parsed;
        }

        public override Control CreateControl(IInteractiveProperty property) {
            object source = property.GetValue();

            StringBuilder toolTipText = new StringBuilder();
            _interactiveProperties = new IInteractiveProperty[Properties.Length];

            string[] values = new string[Properties.Length];
            for (int i = 0; i < Properties.Length; i++) {
                var thisProperty = property.Type.GetProperty(Properties[i]);

                _propertyCreator.Create(thisProperty, source, out IInteractiveProperty output);
                TextObjectParser.Properties.Add(output, i);

                object value = output.GetValue();

                _interactiveProperties[i] = output;
                values[i] = value == null ? "0" : value.ToString();

                toolTipText.Append($"{thisProperty.PropertyType.GetName()} {thisProperty.Name}");
                if (i < Properties.Length - 1) toolTipText.Append("; ");
            }

            DarkTextBox textBox = new DarkTextBox();
            textBox.Text = string.Join("; ", values);
            textBox.CharacterType = CharacterType.Regular;

            string toolTip = toolTipText.ToString();

            _toolTip.SetToolTip(textBox, toolTip);
            foreach (var control in textBox.Controls) {
                _toolTip.SetToolTip(control as Control, toolTip);
            }

            return textBox;
        }
    }
}
