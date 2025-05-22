using System;
using System.Collections.Generic;
using System.Reflection;

namespace InteractiveGUI {
    public class LayoutCreator : ILayoutCreator {
        public IPropertyCreator PropertyCreator { get; set; } = new PropertyCreator();

        public IInteractiveProperty[] CreateLayout(object source) {
            PropertyInfo[] properties = source.GetType().GetProperties();

            List<IInteractiveProperty> output = new List<IInteractiveProperty>();
            for (int i = 0; i < properties.Length; i++) {
                var property = properties[i];

                if (PropertyCreator.Create(property, source, out IInteractiveProperty interactiveProperty)) {
                    output.Add(interactiveProperty);
                }
            }

            return output.ToArray();
        }
    }
}
