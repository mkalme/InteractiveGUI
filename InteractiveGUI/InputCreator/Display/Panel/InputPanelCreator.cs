using System;
using System.Drawing;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class InputPanelCreator : IInputPanelCreator {
        private int _height = 0;

        public Color BackColor = Color.FromArgb(40, 40, 40);
        public Color BorderColor = Color.FromArgb(107, 107, 107);

        public bool DisplayIcons = true;
        public bool DisplayLabels = true;

        public ITypeIconCreator IconCreator { get; set; } = new TypeIconCreatorCache(new TypeIconCreator());

        private ToolTip _typeToolTip = new ToolTip();

        public Panel CreatePanel(IInteractiveProperty[] layout) {
            _height = 0;
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.CellPaint += CellPaint;
            panel.SetDoubleBuffering();

            bool headerDisplayed = DisplayIcons || DisplayLabels;

            panel.ColumnCount = headerDisplayed ? 2 : 1;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            panel.RowCount = layout.Length;

            int count = 0;
            foreach (var property in layout) {
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                if (headerDisplayed) {
                    panel.Controls.Add(CreateLabelControl(property), 0, panel.RowStyles.Count - 1);
                }

                var nodePanel = CreateNodePanel(property);
                if (count == layout.Length - 1) nodePanel.MinimumSize = new Size(0, nodePanel.MinimumSize.Height + 1);

                panel.Controls.Add(nodePanel, headerDisplayed ? 1 : 0, panel.RowStyles.Count - 1);

                count++;
            }

            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            panel.BackColor = BackColor;

            panel.Height = _height;
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.AutoScroll = true;

            return panel;
        }
        private Panel CreateNodePanel(IInteractiveProperty property) {
            Panel panel = new Panel();
            panel.Margin = new Padding(4, 4, 4, 3);
            panel.MinimumSize = new Size(0, 25);
            panel.AutoSize = true;
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.SetDoubleBuffering();

            panel.Dock = DockStyle.Fill;

            Control control = property.ControlInput.CreateControl(property);
            property.Control = control;
            if (control.Height < 25) control.Location = new Point(0, (int)Math.Round((25 - control.Height) / 2F));

            panel.Controls.Add(control);

            if (control.Height > _height) _height = control.Height;

            return panel;
        }

        private Control CreateLabelControl(IInteractiveProperty property) {
            TableLayoutPanel labelPanel = new TableLayoutPanel();
            labelPanel.Margin = new Padding(1);
            labelPanel.Dock = DockStyle.Fill;
            labelPanel.AutoSize = true;
            labelPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            labelPanel.SetDoubleBuffering();

            labelPanel.ColumnCount = 2;
            labelPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, DisplayIcons ? 35 : 0));
            labelPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            if (DisplayLabels) {
                Label label = new DarkLabel();
                label.Text = property.DisplayName;
                label.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                label.Margin = new Padding(DisplayIcons ? 2 : 10, 8, label.Margin.Right - 1, label.Margin.Bottom);

                labelPanel.Controls.Add(label, 1, 0);
            }

            if (DisplayIcons) {
                PictureBox pictureBox = CreateIconControl(property);

                labelPanel.Controls.Add(pictureBox, 0, 0);
            }

            return labelPanel;
        }
        private PictureBox CreateIconControl(IInteractiveProperty property) {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(25, 25);
            pictureBox.Margin = new Padding(3, 3, 0, 0);

            pictureBox.Image = IconCreator.CreateIcon(property.Type);
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

            _typeToolTip.SetToolTip(pictureBox, property.Type.GetName());

            return pictureBox;
        }

        private void CellPaint(object sender, TableLayoutCellPaintEventArgs e) {
            TableLayoutPanel panel = sender as TableLayoutPanel;

            Rectangle r = e.CellBounds;
            using (Pen pen = new Pen(BorderColor)) {
                // top and left lines
                e.Graphics.DrawLine(pen, r.X, r.Y, r.X + r.Width, r.Y);
                e.Graphics.DrawLine(pen, r.X, r.Y, r.X, r.Y + r.Height);

                if (e.Row == panel.RowCount - 1) {
                    // last row? move hor.lines 1 up!
                    int cy = e.Row == panel.RowCount - 1 ? -1 : 0;
                    if (cy != 0) e.Graphics.DrawLine(pen, r.X, r.Y + r.Height + cy,
                                            r.X + r.Width, r.Y + r.Height + cy);
                }

                if (e.Column == panel.ColumnCount - 1) {
                    // last column ? move vert. lines 1 left!
                    int cx = e.Column == panel.ColumnCount - 1 ? -1 : 0;
                    if (cx != 0) e.Graphics.DrawLine(pen, r.X + r.Width + cx, r.Y,
                                            r.X + r.Width + cx, r.Y + r.Height);
                }
            }
        }
    }
}
