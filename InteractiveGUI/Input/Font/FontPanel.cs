using System;
using System.Drawing;
using System.Windows.Forms;

namespace InteractiveGUI {
    class FontPanel : Panel {
        private FontDialog _fontDialog = new FontDialog();
        public Font SelectedFont {
            get => _fontDialog.Font;
            set => _fontDialog.Font = value;
        }

        private DarkLabel _fontLabel = new DarkLabel();
        private DarkButton _fontButton = new DarkButton();

        public FontPanel(Font font) {
            SelectedFont = font;

            _fontLabel.Padding = new Padding(0, 5, 0, 0);

            _fontButton.Text = "Change font";
            _fontButton.Width = 103;
            _fontButton.MouseClick += (object sender, MouseEventArgs e) => {
                _fontDialog.ShowDialog();
                SelectedFont = _fontDialog.Font;

                SetLabelFont(SelectedFont);
            };
            _fontButton.Image = IconResources.GetIcon("InteractiveGUI.Resources.Icons.Font_16x.png");
            _fontButton.ImageAlign = ContentAlignment.MiddleLeft;
            _fontButton.TextAlign = ContentAlignment.MiddleRight;

            Controls.Add(_fontLabel);
            Controls.Add(_fontButton);

            SetLabelFont(SelectedFont);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Margin = new Padding(0);
        }

        private void SetLabelFont(Font font) {
            _fontLabel.Font = new Font(font.FontFamily, _fontLabel.Font.Size, font.Style);
            _fontLabel.Text = $"{font.FontFamily.Name}, {font.Size.ToString().Replace(',', '.')}";

            _fontButton.Location = new Point(_fontLabel.Width + 3, 0);
        }
    }
}
