using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRangers.Classes
{
    class Texture
    {
        private Texture2D _texture;
        private string _path;
        private bool _isLoaded = false;

        public Texture(string path)
        {
            _path = path;
        }
        private Texture2D Load()
        {
            _texture = Content.Load<Texture2D>(_path);
            _isLoaded = true;
            return _texture;
        }
        public Texture2D GetTexture()
        {
            return (_isLoaded ? _texture : Load());
        }
        public void Reset()
        {
            _isLoaded = false;
        }
    }
}
