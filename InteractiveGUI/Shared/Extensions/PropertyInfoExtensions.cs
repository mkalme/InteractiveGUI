using System;
using System.Linq;
using System.Reflection;

namespace InteractiveGUI {
    static class PropertyInfoExtensions {
        public static bool IsStatic(this PropertyInfo source, bool nonPublic = false) {
            return source.GetAccessors(nonPublic).Any(x => x.IsStatic);
        }
    }
}
