using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SpaceRangers.Classes;
using SpaceRangers.Enums;

namespace SpaceRangers
{
    class Debugger
    {
        private int _frameCount;
        private float _seconds;
        private int _fps;
        public  void Update(GameTime gameTime)
        {
            _seconds = (float)gameTime.TotalGameTime.TotalSeconds;
            if (gameTime.TotalGameTime.TotalSeconds <= 1) return;
            if (_seconds != 0)
                _fps = (int)(_frameCount/_seconds);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _frameCount++;
            spriteBatch.Begin();
            var font = ContentContainer.GetFont(FontsEnum.Arial12);
            spriteBatch.DrawString(font, "FPS: " + _fps, new Vector2(0, 0), Color.Yellow);
            spriteBatch.End();
        }
    }
}
