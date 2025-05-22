using System;
using System.Collections.Concurrent;
using System.Drawing;

namespace InteractiveGUI {
    public class TypeIconCreatorCache : ITypeIconCreator {
        private ConcurrentDictionary<Type, Image> _cache = new ConcurrentDictionary<Type, Image>();
        private ITypeIconCreator _typeIconCreator;

        public TypeIconCreatorCache(ITypeIconCreator typeIconCreator) {
            _typeIconCreator = typeIconCreator;
        }

        public Image CreateIcon(Type type) {
            Image image;
            if (!_cache.TryGetValue(type, out image)) {
                image = _typeIconCreator.CreateIcon(type);
                _cache.TryAdd(type, image);
            }

            return image;
        }
    }
}
