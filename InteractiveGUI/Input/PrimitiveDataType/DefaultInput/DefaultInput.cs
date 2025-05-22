using System;
using System.Windows.Forms;

namespace InteractiveGUI {

    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultInput : InputAttribute {
        private IInputFactory _inputFactory = new DefaultInputFactory();
        private InputAttribute _inputAttribute;

        public override bool TryParse(IInteractiveProperty property, out object output) {
            return _inputAttribute.TryParse(property, out output);
        }

        public override Control CreateControl(IInteractiveProperty property) {
            _inputAttribute = _inputFactory.CreateInput(property.Type);

            return _inputAttribute.CreateControl(property);
        }
    }
}
