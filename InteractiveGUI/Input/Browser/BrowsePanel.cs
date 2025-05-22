using System;
using System.Windows.Forms;

namespace InteractiveGUI {
    class BrowsePanel : TableLayoutPanel {
        public BrowseType BrowseType { get; set; }
        public string Filter { get; set; }
        public string Path {
            get => _textBox.Text;
            set => _textBox.Text = value;
        }

        private DarkTextBox _textBox;

        public FolderBrowserDialog FolderDialog { get; set; } = new FolderBrowserDialog();
        public OpenFileDialog FileDialog { get; set; } = new OpenFileDialog();
        public SaveFileDialog SaveFileDialog { get; set; } = new SaveFileDialog();

        public BrowsePanel(BrowseType type, string filter) {
            BrowseType = type;
            Filter = filter;

            FileDialog.Filter = Filter;
            SaveFileDialog.Filter = Filter;

            DarkButton button = new DarkButton();
            button.Text = type == BrowseType.SaveAs ? "Save As" :  "Browse";
            button.MouseClick += BrowseButtonClick;
            button.Image = IconResources.GetIcon("InteractiveGUI.Resources.Icons.FolderBrowserDialogControl_16x.png");
            button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            _textBox = new DarkTextBox();
            _textBox.Location = new System.Drawing.Point(button.Width + 3);
            _textBox.Dock = DockStyle.Fill;
            _textBox.Margin = new Padding(3, 0, 0, 0);

            ColumnCount = 2;
            ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            Controls.Add(button, 0, 0);
            Controls.Add(_textBox, 1, 0);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Dock = DockStyle.Top;
            Margin = new Padding(0);
        }

        private void BrowseButtonClick(object sender, EventArgs args) {
            switch (BrowseType) {
                case BrowseType.Folder:
                    FolderDialog.ShowDialog();
                    Path = FolderDialog.SelectedPath;
                    break;
                case BrowseType.File:
                    FileDialog.ShowDialog();
                    Path = FileDialog.FileName;
                    break;
                case BrowseType.SaveAs:
                    SaveFileDialog.ShowDialog();
                    Path = SaveFileDialog.FileName;
                    break;
            }
        }
    }
}
