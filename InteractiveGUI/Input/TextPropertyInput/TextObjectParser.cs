using System;
using System.Collections.Generic;

namespace InteractiveGUI {
    public class TextObjectParser : ObjectParser {
        public string[] Values { get; set; }
        public IDictionary<IInteractiveProperty, int> Properties { get; set; } = new Dictionary<IInteractiveProperty, int>();

        public PrimitiveDataTypeTextParser TextParser { get; set; } = new PrimitiveDataTypeTextParser();

        protected override bool TryParse(IInteractiveProperty property, out object output) {
            output = null;
            if (!Properties.TryGetValue(property, out int index)) return false;

            return TextParser.TryParse(Values[index], Type.GetTypeCode(property.Type), out output);
        }
    }
}
