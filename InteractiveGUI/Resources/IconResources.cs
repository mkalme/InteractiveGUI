using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace InteractiveGUI {
    static class IconResources {
        private static readonly ConcurrentDictionary<string, Image> _imageCache = new ConcurrentDictionary<string, Image>();
        private static readonly Assembly _executingAssembly = Assembly.GetExecutingAssembly();

        public static Image GetIcon(string name) {
            if (!_imageCache.TryGetValue(name, out Image image)) {

                using (Stream stream = _executingAssembly.GetManifestResourceStream(name)) {
                    image = Image.FromStream(stream);
                }

                _imageCache.TryAdd(name, image);
            }

            return image;
        }
    }
}
