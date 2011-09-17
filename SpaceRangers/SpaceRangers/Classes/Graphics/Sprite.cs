using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceRangers.Classes.Graphics
{
    class Sprite
    {
        private Enum _textureName;
        private int _framesCount;
        private Point _startFrame;

        public Sprite(Enum textureName,Point frameWidthHeight,Point startFrame,int framesCount)
        {
            _textureName = textureName;
            _startFrame = startFrame;
            _framesCount = framesCount;
            checkParams();
        }

        private void checkParams()
        {
            throw new NotImplementedException();
        }

        private Texture2D GetTexture()
        {
            return ContentContainer.GetSprite(_textureName);
        }

        public void Update()
        {
            
        }
        public void Draw()
        {
            
        }

    }
}
