using System;
using System.Windows.Forms;

namespace InteractiveGUI {
    public partial class ArrayInputForm : Form {
        private IInteractiveProperty _property;
        private Array _array;

        private IInputFactory _inputFactory = new DefaultInputFactory();

        private IInteractiveProperty _currentProperty;
        private InputAttribute _currentInput;

        public ValidatorAttribute IndividualValidator { get; set; }

        public ArrayInputForm(IInteractiveProperty property) {
            InitializeComponent();

            _property = property;
            _array = ValueHelper.GetValue(property.GetValue(), Array.CreateInstance(property.Type, 0));

            TypeLabel.Text = _property.Type.Name;
            LengthUpDown.Value = _array.Length;

            GoToUpDown.Maximum = _array.Length - 1;

            if (_array.Length > 0) SetInput(_array.GetValue(0));
        }

        private void LengthUpDown_Leave(object sender, EventArgs e) {
            if (LengthUpDown.Value == _array.Length) return;

            string title = "Change array size";
            string text = $"Are you sure you want to change the array size from {_array.Length} to {LengthUpDown.Value}";

            if (MessageBox.Show(text, title, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Array newArray = Array.CreateInstance(_array.GetType().GetElementType(), (long)LengthUpDown.Value);

                _array.CopyTo(newArray, 0);
                _array = newArray;

                _property.SetValue(_array);

                GoToUpDown.Maximum = _array.Length - 1;
            } else {
                LengthUpDown.Value = _array.Length;
            }
        }

        private void SetInput(object value) {
            var input = _inputFactory.CreateInput(_array.GetType().GetElementType());
            var interactiveVariable = new InteractiveVariable() { Owner = value };

            var control = input.CreateControl(interactiveVariable);

            InputPanel.Controls.Clear();
            InputPanel.Controls.Add(control);

            _currentInput = input;
            _currentProperty = interactiveVariable;
            _currentProperty.Control = control;
        }

        private void GoToButton_Click(object sender, EventArgs e) {
            long index = (long)GoToUpDown.Value;
            if (index < 0 || index >= _array.Length) return;

            SetInput(_array.GetValue(index));
        }
        private void SetValueButton_Click(object sender, EventArgs e) {
            if (_currentInput.TryParse(_currentProperty, out object output)) {
                if (SetForAllCheckBox.Checked) {
                    for (int i = 0; i < _array.Length; i++) {
                        _array.SetValue(output, i);
                    }
                } else {
                    _array.SetValue(output, (long)GoToUpDown.Value);
                }
            } else {
                string title = "Some inputs couldn't be parsed.";
                string message = "The input couldn't be parsed.";

                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
