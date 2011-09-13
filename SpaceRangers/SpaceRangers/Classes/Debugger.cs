using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceRangers
{
    class Debugger
    {
        public int FrameCount { get; set; }
        private float _seconds;
        public int FPS { get; set; }
        private SpriteFont arial12;
        private RangersGame game;

        public Debugger(RangersGame game,SpriteFont font1)
        {
            this.game = game;
            arial12 = font1;

        }
        public  void Update(GameTime gameTime)
        {
            _seconds = (float)gameTime.TotalGameTime.TotalSeconds;
            if(gameTime.TotalGameTime.TotalSeconds>1)
            {
                if (_seconds != 0)
                    FPS = (int)(FrameCount/_seconds);
            }
        }
        public void Trace(Object obj)
        {
            Debug.WriteLine(obj);
        }
    }
}
