using System;
using System.Reflection;
using System.Windows.Forms;

namespace InteractiveGUI {
    public static class DoubleBufferingExtensions {
        public static void SetDoubleBuffering(this Control control) {
            typeof(Control).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                control,
                new object[] { true });
        }
    }
}
