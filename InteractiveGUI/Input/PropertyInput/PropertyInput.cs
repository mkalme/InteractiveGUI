using System;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class PropertyInput : InputAttribute {
        public ScaleType ScaleType { get; set; }
        public string[] Properties { get; set; }

        public ILayoutCreator LayoutCreator { get; set; }
        public IObjectParser ObjectParser { get; set; } = new ObjectParser();

        public PropertyInput(ScaleType scaleType = ScaleType.Horizontal, params string[] properties) {
            ScaleType = scaleType;
            Properties = properties;

            PropertyNameFilterCreator propertCcreator = new PropertyNameFilterCreator(new PropertyCreator() { PropertyType = PropertyType.Default }, Properties);
            LayoutCreator = new LayoutCreator() { PropertyCreator = propertCcreator };
        }

        public override bool TryParse(IInteractiveProperty property, out object output) {
            output = null;
            if (property.Control.GetType() != typeof(StructPanel)) return false;

            IInteractiveProperty[] properties = ((StructPanel)property.Control).Properties;
            if (properties.Length > 0) output = properties[0].Owner;

            return ObjectParser.TryParse(properties);
        }

        public override Control CreateControl(IInteractiveProperty property) {
            return new StructPanel(ScaleType, LayoutCreator.CreateLayout(property.GetValue()));
        }
    }
}
