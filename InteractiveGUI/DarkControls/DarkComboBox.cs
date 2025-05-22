using System;
using System.Drawing;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class DarkComboBox : ComboBox {
        public DarkComboBox() {
            BackColor = Color.FromArgb(45, 45, 45);
            ForeColor = SystemColors.HighlightText;

            FlatStyle = FlatStyle.Flat;

            Margin = new Padding(0);
        }
    }
}
