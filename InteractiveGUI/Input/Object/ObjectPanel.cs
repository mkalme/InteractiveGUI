using System;
using System.Windows.Forms;

namespace InteractiveGUI {
    class ObjectPanel : TableLayoutPanel {
        private DarkButton _editButton;
        private DarkButton _newInstanceButton;

        public event MouseEventHandler EditButtonClick {
            add => _editButton.MouseClick += value;
            remove => _editButton.MouseClick -= value;
        }
        public event MouseEventHandler NewInstanceButtonClick {
            add => _newInstanceButton.MouseClick += value;
            remove => _newInstanceButton.MouseClick -= value;
        }

        public ObjectPanel(object source) {
            _editButton = new DarkButton();
            _editButton.Text = "Edit";
            _editButton.Margin = new Padding(0, 0, 3, 0);
            _editButton.Image = IconResources.GetIcon("InteractiveGUI.Resources.Icons.Edit_grey_16x.png");
            _editButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            _editButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            _editButton.Padding = new Padding(1, 0, 0, 0);
            _editButton.Width = 57;

            _newInstanceButton = new DarkButton();
            _newInstanceButton.Text = "New instance";
            _newInstanceButton.Width = 100;

            ColumnCount = 2;
            ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            Controls.Add(_editButton, 0, 0);
            Controls.Add(_newInstanceButton, 1, 0);

            _editButton.Visible = source != null;

            Margin = new Padding(0);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
