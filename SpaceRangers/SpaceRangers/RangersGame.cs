using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceRangers.Classes;

namespace SpaceRangers
{

    public class RangersGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;
        private Debugger _debugger;
        private SpriteFont _arial12;
        public RangersGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Classes.Content.Initialize(this);
        }
        
        protected override void Initialize()
        {
            _debugger=new Debugger();
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
			_spriteBatch.Draw(ContentContainer.GetTexture("RedPlane"),new Vector2(200, 200), Color.White);
        	_spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
