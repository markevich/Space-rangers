using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRangers.Classes
{
    class LazyContentItem<T>:IResetable
    {
        private T _item;
        private readonly string _path;
        private bool _isLoaded = false;

        public LazyContentItem(string path)
        {
            _path = path;
        }
        private T Load()
        {
            _item = Content.Load<T>(_path);
            _isLoaded = true;
            return _item;
        }
        public T GetItem()
        {
            return (_isLoaded ? _item : Load());
        }
        public void Reset()
        {
            _isLoaded = false;
        }
    }
}
