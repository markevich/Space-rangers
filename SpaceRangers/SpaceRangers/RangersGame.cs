using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SpaceRangers.Classes;

namespace SpaceRangers
{

    public class RangersGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Debugger debugger;
        private SpriteFont arial12;
        public RangersGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Classes.Content.Initialize(this);
        }
        
        protected override void Initialize()
        {
            IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = false;

            debugger=new Debugger(this,arial12);
            Services.AddService(typeof(Debugger),debugger);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentContainer.LoadTextures();
            arial12 = Content.Load<SpriteFont>("Fonts/Arial12");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            debugger.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            debugger.FrameCount++;
            spriteBatch.Begin();
            spriteBatch.DrawString(arial12, "FPS: " + debugger.FPS, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(ContentContainer.GetTexture("RedPlane"),new Vector2(100,100),Color.White);
            spriteBatch.Draw(ContentContainer.GetTexture("RedPlane"), new Vector2(100, 200), Color.White);
            spriteBatch.Draw(ContentContainer.GetTexture("RedPlane"), new Vector2(100, 300), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
