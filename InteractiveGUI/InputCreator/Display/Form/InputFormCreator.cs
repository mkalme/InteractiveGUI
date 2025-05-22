using System;
using System.Drawing;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class InputFormCreator {
        public object Source { get; set; }

        public IInputPanelCreator PanelCreator { get; set; } = new InputPanelCreator();
        public ILayoutCreator LayoutCreator { get; set; } = new LayoutCreator();
        public IObjectParser ObjectParser { get; set; } = new ObjectParser();

        public string Title { get; set; }

        private int _width = 0;

        public InputFormCreator(object source, string title = "") {
            Source = source;
            Title = title;

            if (string.IsNullOrEmpty(title)) Title = $"Edit {source.GetType().Name}";
        }

        public Form CreateForm() {
            Form form = new Form();

            Panel panel = CreateFormPanel(form);
            panel.Dock = DockStyle.Fill;

            form.Controls.Add(panel);

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Padding = new Padding(10);
            form.Width = 800;
            form.Height = 500;

            form.BackColor = Color.FromArgb(35, 35, 35);
            form.Text = Title;

            form.Width = (int)(_width * 3F);
            form.Height = panel.Controls[0].Height + 150;

            form.MaximizeBox = false;

            form.Select();

            return form;
        }
        public Panel CreateFormPanel(Form form) {
            IInteractiveProperty[] layout = LayoutCreator.CreateLayout(Source);

            Panel inputPanel = PanelCreator.CreatePanel(layout);
            _width = inputPanel.Width;
            
            inputPanel.AutoSize = true;
            inputPanel.Dock = DockStyle.Top;

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.SetDoubleBuffering();

            panel.RowCount = 2;
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            DarkButton button = new DarkButton();
            button.Text = "Done";
            button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button.Margin = new Padding(3, 12, 3, 4);
            button.BorderColor = SystemColors.HighlightText;

            button.Click += (object sender, EventArgs args) => {
                if(ObjectParser.TryParse(layout)) form.Close();
            };

            panel.Controls.Add(inputPanel, 0, 0);
            panel.Controls.Add(button, 0, 1);

            return panel;
        }
    }
}
