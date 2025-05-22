using System;
using System.Reflection;

namespace InteractiveGUI {
    public class ParameterLayoutCreator : ILayoutCreator {
        public IInputFactory InputFactory { get; set; } = new DefaultInputFactory();

        public IInteractiveProperty[] CreateLayout(object source) {
            ParameterInfo[] parameters = source as ParameterInfo[];

            IInteractiveProperty[] properties = new IInteractiveProperty[parameters.Length];
            for (int i = 0; i < properties.Length; i++) {
                var property = new InteractiveParameter(parameters[i]);

                property.DisplayName = parameters[i].Name;
                property.ControlInput = InputFactory.CreateInput(parameters[i].ParameterType);
                property.Validator = new DefaultValidator();

                properties[i] = property;
            }

            return properties;
        }
    }
}
