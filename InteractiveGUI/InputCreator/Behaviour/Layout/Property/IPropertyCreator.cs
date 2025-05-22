using System;
using System.Reflection;

namespace InteractiveGUI {
    public interface IPropertyCreator {
        bool Create(PropertyInfo property, object source, out IInteractiveProperty output);
    }
}
