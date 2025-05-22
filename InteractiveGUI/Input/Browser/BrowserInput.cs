using System;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class BrowserInput : InputAttribute {
        public BrowseType BrowseType { get; set; }
        public string Filter { get; set; } = "All files (*.*)|*.*";

        public BrowserInput(BrowseType browseType) {
            BrowseType = browseType;
        }
        public BrowserInput(string filter) {
            BrowseType = BrowseType.File;
            Filter = filter;
        }
        public BrowserInput(BrowseType browseType, string filter) {
            BrowseType = browseType;
            Filter = filter;
        }

        public override bool TryParse(IInteractiveProperty property, out object output) {
            output = null;
            if (property.Control.GetType() != typeof(BrowsePanel)) return false;

            output = ((BrowsePanel)property.Control).Path;
            return true;
        }

        public override Control CreateControl(IInteractiveProperty property) {
            BrowsePanel panel = new BrowsePanel(BrowseType, Filter);
            panel.Path = property.GetValue() as string;

            return panel;
        }
    }
}
