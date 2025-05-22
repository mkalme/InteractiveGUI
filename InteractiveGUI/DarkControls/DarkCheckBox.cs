using System;
using System.Drawing;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class DarkCheckBox : CheckBox {
        public DarkCheckBox() {
            ForeColor = SystemColors.HighlightText;
            
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;

            Margin = new Padding(0);
        }
    }
}
