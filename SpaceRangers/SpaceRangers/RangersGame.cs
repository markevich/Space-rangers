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

        private Sprite sprite;
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentContainer.LoadContentInfo();
            texture = ContentContainer.GetSprite(ShipsEnum.Walk);
            sprite=new Sprite(ShipsEnum.Walk,new Point(24,32),new Point(1,4),8,12);

        }

        private Texture2D texture;
        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            _debugger.Update(gameTime);
            sprite.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _debugger.Draw(_spriteBatch);
			_spriteBatch.Begin();
            sprite.Draw(_spriteBatch);
        	_spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
