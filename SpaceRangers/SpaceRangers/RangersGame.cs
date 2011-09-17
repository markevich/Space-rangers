using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceRangers.Classes;
using SpaceRangers.Classes.Graphics;
using SpaceRangers.Enums;

namespace SpaceRangers
{

    public class RangersGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Debugger _debugger;
        public RangersGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Classes.Content.Initialize(this);
        }

        protected override void Initialize()
        {
            _debugger=new Debugger();
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.ApplyChanges();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentContainer.LoadContentInfo();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            _debugger.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _debugger.Draw(_spriteBatch);
			_spriteBatch.Begin();
			_spriteBatch.Draw(ContentContainer.GetSprite(ShipsEnum.RedPlane),new Vector2(200, 200), Color.White);
        	_spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
