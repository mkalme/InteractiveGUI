using System;
using System.Drawing;
using System.Windows.Forms;

namespace InteractiveGUI {
    public partial class DarkTextBox : UserControl {
        public override Color BackColor {
            get => base.BackColor;
            set {
                base.BackColor = value;
                TextBox.BackColor = value;
            }
        }
        public override string Text {
            get => TextBox.Text;
            set {
                TextBox.Text = value;

                if (value == null) return;
                TextBox.Select(value.Length, 0);
            }
        }
        public string HintText {
            get => HintLabel.Text;
            set => HintLabel.Text = value;
        }

        public event EventHandler InputChanged {
            add {
                TextBox.TextChanged += value;
            }
            remove {
                TextBox.TextChanged -= value;
            }
        }

        public CharacterType CharacterType {
            get => _characterType;
            set {
                _characterType = value;
                _characterValidator = GetChracterValidator(value);
            }
        }
        private CharacterType _characterType;

        private Action<object, KeyPressEventArgs> _characterValidator;

        public DarkTextBox() {
            InitializeComponent();

            CharacterType = CharacterType.Regular;

            SetTextPosition();
        }

        private void SetTextPosition() {
            int height = TextBox.Font.Height;
            int top = (int)Math.Ceiling((Height - 2 - height) / 2F);

            Padding = new Padding(Padding.Left, top, Padding.Right, Padding.Bottom);
        }

        private void CustomTextBox_SizeChanged(object sender, EventArgs e) {
            SetTextPosition();
        }

        private void HintLabel_MouseDown(object sender, MouseEventArgs e) {
            HintLabel.Visible = false;
            TextBox.Focus();
        }
        private void TextBox_MouseDown(object sender, MouseEventArgs e) {
            HintLabel.Visible = false;
            TextBox.Focus();
        }

        private void TextBox_Leave(object sender, EventArgs e) {
            HintLabel.Visible = string.IsNullOrEmpty(TextBox.Text);
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e) {
            _characterValidator(sender, e);
        }

        private static Action<object, KeyPressEventArgs> GetChracterValidator(CharacterType type) {
            switch (type) {
                case CharacterType.Numbers:
                    return (object sender, KeyPressEventArgs e) => {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-') {
                            e.Handled = true;
                        }

                        if (e.KeyChar == '-' && ((sender as TextBox).Text.Length > 0) && (sender as TextBox).SelectionStart > 0) {
                            e.Handled = true;
                        }
                    };
                case CharacterType.NumbersWithDecimals:
                    return (object sender, KeyPressEventArgs e) => {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-') {
                            e.Handled = true;
                        }

                        if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
                            e.Handled = true;
                        }

                        if (e.KeyChar == '.' && (sender as TextBox).Text.Length == 1 && (sender as TextBox).Text[0] == '-') {
                            e.Handled = true;
                        }

                        if (e.KeyChar == '-' && ((sender as TextBox).Text.Length > 0) && (sender as TextBox).SelectionStart > 0) {
                            e.Handled = true;
                        }
                    };
                case CharacterType.SingleCharacter:
                    return (object sender, KeyPressEventArgs e) => {
                        e.Handled = (sender as TextBox).Text.Length > 0 && (Keys)e.KeyChar != Keys.Back;
                    };
                default:
                    return (object sender, KeyPressEventArgs e) => { };
            }
        }
    }
}
