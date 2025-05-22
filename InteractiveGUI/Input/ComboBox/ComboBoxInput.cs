using System;
using System.Linq;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class ComboBoxInput : InputAttribute {
        public object[] Items { get; set; }

        public ComboBoxInput(params object[] items) {
            Items = items;
        }
        public ComboBoxInput(Type enumType) {
            Items = Enum.GetValues(enumType).Cast<object>().ToArray();
        }

        public override bool TryParse(IInteractiveProperty property, out object output) {
            output = null;
            if (property.Control.GetType() != typeof(DarkComboBox)) return false;

            output = ((DarkComboBox)property.Control).SelectedItem;
            return true;
        }

        public override Control CreateControl(IInteractiveProperty property) {
            DarkComboBox comboBox = new DarkComboBox();
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            object value = property.GetValue();

            foreach (var item in Items) {
                comboBox.Items.Add(item);
            }

            comboBox.SelectedItem = value;

            return comboBox;
        }
    }
}
