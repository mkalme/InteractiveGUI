using System;
using System.Collections.Generic;
using System.Reflection;

namespace InteractiveGUI {
    public class PropertyCreator : IPropertyCreator {
        public PropertyType PropertyType { get; set; }

        public virtual bool Create(PropertyInfo property, object source, out IInteractiveProperty output) {
            output = null;
            if (!Filter(property)) return false;
            GetAttributes(property, out InteractiveAttribute interactiveAttribute, out InputAttribute input, out ValidatorAttribute validator);

            if (PropertyType.HasFlag(PropertyType.WithAttributesOnly) && interactiveAttribute == null) return false;

            output = CreateProperty(property, property.Name, input, validator);
            output.Owner = source;

            if (interactiveAttribute?.DisplayName != null) output.DisplayName = interactiveAttribute.DisplayName;

            return true;
        }

        protected virtual void GetAttributes(PropertyInfo property, out InteractiveAttribute interactiveAttribute, out InputAttribute input, out ValidatorAttribute validator) {
            IEnumerable<Attribute> attributes = property.GetCustomAttributes();

            interactiveAttribute = null;
            input = null;
            validator = null;

            foreach (var attribute in attributes) {
                var type = attribute.GetType();

                if (type == typeof(InteractiveAttribute)) {
                    interactiveAttribute = attribute as InteractiveAttribute;
                } else if (type.IsSubclassOf(typeof(InputAttribute))) {
                    input = attribute as InputAttribute;
                } else if (type.IsSubclassOf(typeof(ValidatorAttribute))) {
                    validator = attribute as ValidatorAttribute;
                }
            }
        }
        protected virtual bool Filter(PropertyInfo property) {
            if (PropertyType.HasFlag(PropertyType.Static) && !property.IsStatic()) return false;
            if (!property.CanWrite) return false;

            return true;
        }
        protected virtual IInteractiveProperty CreateProperty(PropertyInfo property, string name, InputAttribute input, ValidatorAttribute validator) {
            IInteractiveProperty output;
            if (property.PropertyType.IsStruct()) {
                output = new InteractiveStructProperty(property, name, input, validator);
            } else {
                output = new InteractiveProperty(property, name, input, validator);
            }

            if (input == null) output.ControlInput = new DefaultInput();
            if (validator == null) output.Validator = new DefaultValidator();

            return output;
        }
    }
}
