using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRangers.Classes
{
    internal class Font
    {
        private SpriteFont _font;
        private readonly string _path;
        private bool _isLoaded = false;

        public Font(string path)
        {
            _path = path;
        }

        private SpriteFont Load()
        {
            _font = Content.Load<SpriteFont>(_path);
            _isLoaded = true;
            return _font;
        }

        public SpriteFont GetFont()
        {
            return (_isLoaded ? _font : Load());
        }

        public void Reset()
        {
            _isLoaded = false;
        }
    }
}
