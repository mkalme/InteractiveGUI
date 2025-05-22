using System;
using System.Collections.Generic;
using System.Drawing;

namespace InteractiveGUI {
    public static class TypeColorController {
        public static readonly Color PrimitiveDataTypeColor = Color.FromArgb(200, 200, 200);
        public static readonly Color EnumColor = Color.FromArgb(184, 215, 131);
        public static readonly Color StructColor = Color.FromArgb(134, 198, 115);
        public static readonly Color ObjectColor = Color.FromArgb(45, 147, 173);
        public static readonly Color ArrayColor = SystemColors.HighlightText;
        public static readonly Color InterfaceColor = Color.FromArgb(255, 233, 140);

        private static readonly HashSet<Type> _primitiveDataTypes = new HashSet<Type>() {
            typeof(byte),
            typeof(sbyte),
            typeof(ushort),
            typeof(short),
            typeof(uint),
            typeof(int),
            typeof(ulong),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(string),
            typeof(char),
            typeof(bool)
        };

        public static Color GetColor(Type type) {
            if (_primitiveDataTypes.Contains(type)) return PrimitiveDataTypeColor;

            if (type.IsEnum) return EnumColor;
            if (type.IsArray) return ArrayColor;
            if (type.IsInterface) return InterfaceColor;
            if (type.IsValueType) return StructColor;

            return ObjectColor;
        }
    }
}
