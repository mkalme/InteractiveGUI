using System;
using System.Collections.Generic;

namespace InteractiveGUI {
    static class TypeExtensions {
        private static readonly HashSet<Type> _integers = new HashSet<Type>() {
            typeof(byte),
            typeof(sbyte),
            typeof(ushort),
            typeof(short),
            typeof(uint),
            typeof(int),
            typeof(ulong),
            typeof(long)
        };
        private static readonly HashSet<Type> _fractions = new HashSet<Type>() {
            typeof(float),
            typeof(double),
            typeof(decimal)
        };
        private static readonly Dictionary<Type, string> _aliases = new Dictionary<Type, string>(){
            { typeof(byte), "byte" },
            { typeof(sbyte), "sbyte" },
            { typeof(short), "short" },
            { typeof(ushort), "ushort" },
            { typeof(int), "int" },
            { typeof(uint), "uint" },
            { typeof(long), "long" },
            { typeof(ulong), "ulong" },
            { typeof(float), "float" },
            { typeof(double), "double" },
            { typeof(decimal), "decimal" },
            { typeof(object), "object" },
            { typeof(bool), "bool" },
            { typeof(char), "char" },
            { typeof(string), "string" },
            { typeof(void), "void" }
        };

        public static bool IsInteger(this Type type) {
            return _integers.Contains(type);
        }
        public static bool IsFraction(this Type type) {
            return _fractions.Contains(type);
        }

        public static bool IsStruct(this Type type) {
            return type.IsValueType && !type.IsPrimitive && !type.IsEnum && type != typeof(decimal) && type != typeof(DateTime);
        }
        public static bool IsNullable(this Type type) {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static string GetName(this Type type) {
            if (type.IsArray) return $"{type.GetElementType().GetName()}[]";
            if (type.IsPointer) return $"{type.GetElementType().GetName()}*";
            if (type.IsNullable()) return $"{type.GetElementType().GetName()}[]";

            if (_aliases.TryGetValue(type, out string alias)) return alias;

            return type.Name;
        }
    }
}
