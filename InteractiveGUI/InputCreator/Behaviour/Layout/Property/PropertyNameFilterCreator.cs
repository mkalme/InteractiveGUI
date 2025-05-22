using System;
using System.Collections.Generic;
using System.Reflection;

namespace InteractiveGUI {
    public class PropertyNameFilterCreator : IPropertyCreator {
        public IPropertyCreator Creator { get; set; }
        public HashSet<string> Properties { get; set; }

        public PropertyNameFilterCreator(IPropertyCreator creator, string[] properties) {
            Creator = creator;
            Properties = new HashSet<string>(properties);
        }

        public bool Create(PropertyInfo property, object source, out IInteractiveProperty output) {
            if (Properties.Contains(property.Name)) {
                return Creator.Create(property, source, out output);
            } else {
                output = null;
                return false;
            }
        }
    }
}
