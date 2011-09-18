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
        private Point _frameWidthHeight;
        public Sprite(Enum textureName,Point frameWidthHeight,Point startFrame,int framesCount)
        {
            _textureName = textureName;
            _startFrame = startFrame;
            _framesCount = framesCount;
            _frameWidthHeight = frameWidthHeight;
            checkParams();
        }

        private void checkParams()
        {

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
