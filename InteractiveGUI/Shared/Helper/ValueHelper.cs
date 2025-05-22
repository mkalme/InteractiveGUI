using System;

namespace InteractiveGUI {
     static class ValueHelper {
        public static TValue GetValue<TValue>(object value, TValue defaultValue) {
            if (value == null) return defaultValue;
            return (TValue)value;
        }
    }
}
