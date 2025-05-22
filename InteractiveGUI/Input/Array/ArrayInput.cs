using System;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class ArrayInput : InputAttribute {
        private IInteractiveProperty _property;

        public override bool TryParse(IInteractiveProperty property, out object output) {
            output = property.GetValue();
            return true;
        }

        public override Control CreateControl(IInteractiveProperty property) {
            _property = property;
            
            DarkButton button = new DarkButton();
            button.Text = "Edit";
            button.MouseClick += ButtonClick;
            button.Image = IconResources.GetIcon("InteractiveGUI.Resources.Icons.Edit_grey_16x.png");
            button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            button.Padding = new Padding(1, 0, 0, 0);
            button.Width = 57;

            return button;
        }

        private void ButtonClick(object sender, EventArgs args) {
            new ArrayInputForm(_property).ShowDialog();
        }
    }
}
