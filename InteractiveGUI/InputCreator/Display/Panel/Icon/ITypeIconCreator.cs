using System;
using System.Drawing;

namespace InteractiveGUI {
    public interface ITypeIconCreator {
        Image CreateIcon(Type type);
    }
}
