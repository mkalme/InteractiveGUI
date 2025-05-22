using System;
using System.Drawing;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class DarkButton : Button {
        public Color BorderColor { get; set; } = Color.FromArgb(170, 170, 170);

        public DarkButton() {
            BackColor = Color.FromArgb(55, 55, 55);
            ForeColor = SystemColors.HighlightText;

            FlatStyle = FlatStyle.Flat;

            Height = 25;
            Margin = new Padding(0);

            Paint += OnPaint;
        }

        private void OnPaint(object sender, PaintEventArgs e) {
            Button button = sender as Button;

            ControlPaint.DrawBorder(e.Graphics, button.ClientRectangle,
                                    BorderColor, 1, ButtonBorderStyle.Solid,
                                    BorderColor, 1, ButtonBorderStyle.Solid,
                                    BorderColor, 1, ButtonBorderStyle.Solid,
                                    BorderColor, 1, ButtonBorderStyle.Solid);
        }
    }
}
