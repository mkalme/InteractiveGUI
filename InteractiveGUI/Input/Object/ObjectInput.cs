using System;
using System.Windows.Forms;

namespace InteractiveGUI {
    public class ObjectInput : InputAttribute {
        public PropertyType PropertyType { get; set; }
        public string[] Properties { get; set; }

        private IInteractiveProperty _property;

        private LayoutCaptureCreater _layoutCaptureCreator;

        public ObjectInput(PropertyType propertyType = PropertyType.Default, params string[] properties) {
            PropertyType = propertyType;
            Properties = properties;

            PropertyCreator propertyCreator = new PropertyCreator() {
                PropertyType = propertyType
            };

            _layoutCaptureCreator = new LayoutCaptureCreater(new LayoutCreator() { PropertyCreator = propertyCreator });
        }

        public override bool TryParse(IInteractiveProperty property, out object output) {
            output = property.GetValue();
            return true;
        }

        public override Control CreateControl(IInteractiveProperty property) {
            ObjectPanel panel = new ObjectPanel(property.GetValue());
            panel.EditButtonClick += EditButtonClick;
            panel.NewInstanceButtonClick += NewInstanceButtonClick;

            _property = property;

            return panel;
        }

        private void EditButtonClick(object sender, EventArgs args) {
            IPropertyCreator propertyCreator;

            propertyCreator = new PropertyCreator() {
                PropertyType = PropertyType
            };

            if (Properties.Length > 0) propertyCreator = new PropertyNameFilterCreator(propertyCreator, Properties);

            _layoutCaptureCreator = new LayoutCaptureCreater(new LayoutCreator() {
                PropertyCreator = propertyCreator
            });

            InputFormCreator creator = new InputFormCreator(_property.GetValue()) {
                LayoutCreator = _layoutCaptureCreator
            };

            creator.CreateForm().ShowDialog();
        }
        private void NewInstanceButtonClick(object sender, EventArgs args) {
            var form = new ObjectCreatorForm(_property.Type.GetConstructors(), _property.Type);
            form.ShowDialog();

            if (form.Object != null) {
                _property.SetValue(form.Object);
            }
        }
    }
}
