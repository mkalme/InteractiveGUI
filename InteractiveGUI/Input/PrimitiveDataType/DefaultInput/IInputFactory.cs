using System;

namespace InteractiveGUI {
    public interface IInputFactory {
        InputAttribute CreateInput(Type property);
    }
}
