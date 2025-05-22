using System;
using System.Collections.Generic;
using System.Drawing;

namespace InteractiveGUI {
    public class DefaultInputFactory : IInputFactory {
        private Dictionary<Type, Func<object>> _inputs = new Dictionary<Type, Func<object>>() {
            {typeof(Font), () => new FontInput()},
            {typeof(DateTime), () => new DateInput() },
            {typeof(bool), () => new CheckBoxInput() },
            {typeof(Color), () => new ColorInput()  },
            {typeof(Point), () => new TextPropertyInput("X", "Y") },
            {typeof(PointF), () => new TextPropertyInput("X", "Y") },
            {typeof(Size), () => new TextPropertyInput("Width", "Height") },
            {typeof(SizeF), () => new TextPropertyInput("Width", "Height") },
        };

        public InputAttribute CreateInput(Type type) {
            InputAttribute input;
            if (!_inputs.TryGetValue(type, out Func<object> inputFunc)) {
                if (type.IsEnum) {
                    input = new ComboBoxInput(type);
                }else if (type.IsArray) {
                    input = new ArrayInput();
                } else if (!type.IsPrimitive && type != typeof(string) && type != typeof(decimal)) {
                    input = new ObjectInput();
                } else if (type.IsInterface) {
                    return null;
                } else {
                    input = new PrimitiveDataTypeInput();
                }
            } else {
                input = inputFunc() as InputAttribute;
            }

            return input;
        }
    }
}
