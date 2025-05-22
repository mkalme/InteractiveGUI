using System;
using System.Drawing;
using System.Windows.Forms;

namespace InteractiveGUI {
    class ColorPanel : Panel {
        public Color SelectedColor {
            get => _colorPanel.BackColor;
            set => _colorPanel.BackColor = value;
        }
        public ColorDialog Dialog { get; set; }

        private Panel _colorPanel = new Panel();

        public ColorPanel(Color color) {
            SelectedColor = color;

            Dialog = new ColorDialog();
            Dialog.Color = SelectedColor;

            _colorPanel.Width = 25;
            _colorPanel.Height = 25;
            _colorPanel.Margin = new Padding(0);
            _colorPanel.MouseClick += ColorClick;
            _colorPanel.BorderStyle = BorderStyle.FixedSingle;

            DarkButton button = new DarkButton();
            button.Text = "Change color";
            button.MouseClick += ColorClick;
            button.Width = 105;
            button.Location = new Point(_colorPanel.Width + 3, 0);
            button.Image = IconResources.GetIcon("InteractiveGUI.Resources.Icons.ColorPalette_16x.png");
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.TextAlign = ContentAlignment.MiddleRight;

            Controls.Add(_colorPanel);
            Controls.Add(button);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Margin = new Padding(0);
        }

        private void ColorClick(object sender, EventArgs args) {
            Dialog.ShowDialog();
            SelectedColor = Dialog.Color;
        }
    }
}
