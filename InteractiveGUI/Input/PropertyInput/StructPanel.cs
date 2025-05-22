using System;
using System.Drawing;
using System.Windows.Forms;

namespace InteractiveGUI {
    class StructPanel : TableLayoutPanel {
        public ScaleType ScaleType { get; set; }
        public IInteractiveProperty[] Properties { get; set; }

        public StructPanel(ScaleType scaleType, IInteractiveProperty[] properties) {
            ScaleType = scaleType;
            Properties = properties;

            if (scaleType == ScaleType.Vertical) {
                ColumnCount = 2;

                ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            }

            for (int i = 0; i < Properties.Length; i++) {
                var property = Properties[i];

                DarkLabel label = CreateLabel(property);

                Control input = property.ControlInput.CreateControl(property);
                property.Control = input;

                if (ScaleType == ScaleType.Vertical) {
                    AddVerticalControls(label, input, i);
                } else {
                    AddHorizontalControls(label, input, i);
                }
            }

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Dock = DockStyle.Top;

            Margin = new Padding(0);
        }

        private void AddVerticalControls(DarkLabel label, Control input, int count) {
            RowStyles.Add(new RowStyle(SizeType.AutoSize));

            input.Margin = new Padding(0, 0, 4, count == Properties.Length - 1 ? 0 : 3);

            Controls.Add(label, 0, count);
            Controls.Add(input, 1, count);
        }
        private void AddHorizontalControls(DarkLabel label, Control input, int count) {
            ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            Panel panel = new Panel();
            panel.Margin = new Padding(0);
            panel.AutoSize = true;
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.Padding = new Padding(0, 0, 3, 0);

            panel.Controls.Add(label);
            panel.Controls.Add(input);

            Controls.Add(panel, count, 0);

            input.Location = new Point(label.Width, 0);
        }

        private static DarkLabel CreateLabel(IInteractiveProperty property) {
            DarkLabel label = new DarkLabel();
            label.Text = property.DisplayName;
            label.AutoSize = true;
            label.Padding = new Padding(0, 5, 0, 0);

            return label;
        }
    }
}
