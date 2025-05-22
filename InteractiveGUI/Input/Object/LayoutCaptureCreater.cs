using System;

namespace InteractiveGUI {
    public class LayoutCaptureCreater : ILayoutCreator {
        public ILayoutCreator LayoutCreator { get; set; }
        public IInteractiveProperty[] Properties { get; set; }

        public LayoutCaptureCreater(ILayoutCreator layoutCreator) {
            LayoutCreator = layoutCreator;
        }

        public IInteractiveProperty[] CreateLayout(object source) {
            Properties = LayoutCreator.CreateLayout(source);

            return Properties;
        }
    }
}
