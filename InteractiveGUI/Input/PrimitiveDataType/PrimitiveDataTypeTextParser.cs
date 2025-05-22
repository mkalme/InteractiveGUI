using System;

namespace InteractiveGUI {
    public class PrimitiveDataTypeTextParser {
        private delegate bool ParseDelegate<TOutput>(string text, out TOutput output);

        public PrimitiveDataTypeTextParser() {

        }

        public bool TryParse(string text, TypeCode typeCode, out object output) {
            if (typeCode != TypeCode.String && typeCode != TypeCode.DateTime) {
                text = text.Replace('.', ',');
            }

            switch (typeCode) {
                case TypeCode.Boolean:
                    return TryParse<bool>(bool.TryParse, text, out output);
                case TypeCode.Char:
                    return TryParse<char>(char.TryParse, text, out output);
                case TypeCode.SByte:
                    return TryParse<sbyte>(sbyte.TryParse, text, out output);
                case TypeCode.Byte:
                    return TryParse<byte>(byte.TryParse, text, out output);
                case TypeCode.Int16:
                    return TryParse<short>(short.TryParse, text, out output);
                case TypeCode.UInt16:
                    return TryParse<ushort>(ushort.TryParse, text, out output);
                case TypeCode.Int32:
                    return TryParse<int>(int.TryParse, text, out output);
                case TypeCode.UInt32:
                    return TryParse<uint>(uint.TryParse, text, out output);
                case TypeCode.Int64:
                    return TryParse<long>(long.TryParse, text, out output);
                case TypeCode.UInt64:
                    return TryParse<ulong>(ulong.TryParse, text, out output);
                case TypeCode.Single:
                    return TryParse<float>(float.TryParse, text, out output);
                case TypeCode.Double:
                    return TryParse<double>(double.TryParse, text, out output);
                case TypeCode.Decimal:
                    return TryParse<decimal>(decimal.TryParse, text, out output);
                case TypeCode.DateTime:
                    return TryParse<DateTime>(DateTime.TryParse, text, out output);
                case TypeCode.String:
                    output = text;
                    return true;
                default:
                    output = null;
                    return false;
            }
        }

        private static bool TryParse<TOutput>(ParseDelegate<TOutput> parse, string text, out object output) {
            bool successful = parse(text, out TOutput value);

            output = value;
            return successful;
        }
    }
}
