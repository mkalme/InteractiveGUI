using System;
using System.Windows.Forms;

namespace InteractiveGUI {

    public class PrimitiveDataTypeInput : InputAttribute {
        public PrimitiveDataTypeTextParser TextParser { get; set; } = new PrimitiveDataTypeTextParser();

        public override bool TryParse(IInteractiveProperty property, out object output) {
            return TextParser.TryParse(property.Control.Text, Type.GetTypeCode(property.Type), out output);
        }
        public override Control CreateControl(IInteractiveProperty property) {
            DarkTextBox textBox = new DarkTextBox();
            if(property.Type == typeof(string)) textBox.Dock = DockStyle.Fill;

            if (property.Type.IsInteger()) textBox.CharacterType = CharacterType.Numbers;
            else if (property.Type.IsFraction()) textBox.CharacterType = CharacterType.NumbersWithDecimals;
            else if (property.Type == typeof(char)) textBox.CharacterType = CharacterType.SingleCharacter;
            else textBox.CharacterType = CharacterType.Regular;

            object value = property.GetValue();
            if (value == null) {
                textBox.Text = "";
                return textBox;
            }

            textBox.Text = value.ToString();

            return textBox;
        }
    }
}
