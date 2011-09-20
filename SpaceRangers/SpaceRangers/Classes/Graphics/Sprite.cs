using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceRangers.Enums;

namespace SpaceRangers.Classes.Graphics
{
    class Sprite
    {
        private Enum _textureName;
        private int _framesCount;
        private Point _startFrame;
        private Point _frameSize;
        private Point _textureSize;
        private int _currentFrame;
        private int _columnsCount;
        private int _rowsCount;
        private float _timeLastFrameUpdate;
        private int _updateRate;
        private List<Rectangle> _frames; 
        public Sprite(Enum textureName,Point frameWidthHeight,Point startFrame,int framesCount,int fps)
        {
            _textureName = textureName;
            _startFrame = startFrame;
            _framesCount = framesCount;
            _frameSize = frameWidthHeight;
            _updateRate = 1000/fps;
            _timeLastFrameUpdate = 0;
            SetTextureSize();
            _columnsCount = TextureWidth / FrameWidth;
            _rowsCount = TextureHeight / FrameHeight;
            CheckParams();
            SetFrames();
        }
        #region Private properties
        private int TextureWidth { get { return _textureSize.X; } }
        private int TextureHeight { get { return _textureSize.Y; } }
        private int FrameWidth { get { return _frameSize.X; } }
        private int FrameHeight { get { return _frameSize.Y; } }
        #endregion

        private void CheckParams()
        {
            GetTexture();

            int avaliableFramesCount = (_columnsCount - _startFrame.X + 1) + (_rowsCount - _startFrame.Y)*_columnsCount;
            if(_framesCount>avaliableFramesCount)
            {
                throw new Exception(String.Format("Requested number of frames can not exceed the remaining free frames.\r\n" +
                                                  "Sprite name: '{0}'.\r\n" +
                                                  "Avaliable frames count: {1}.\r\n" +
                                                  "Requested frames count: {2}.",
                                                  _textureName,avaliableFramesCount,_framesCount));
            }

        }
        private void SetFrames()
        {
            _frames=new List<Rectangle>();
            int startFrameIndex = (_startFrame.Y-1)*_columnsCount +_startFrame.X-1;
            for (int i = startFrameIndex; i < _framesCount + startFrameIndex; i++)
            {
                int x = (i % _columnsCount)*FrameWidth;
                int y = (i / _columnsCount)*FrameHeight;

                _frames.Add(new Rectangle(x, y, FrameWidth, FrameHeight));
            }
        }
        private void SetTextureSize()
        {
            var texture = GetTexture();
            _textureSize = new Point {X = texture.Width, Y = texture.Height};
        }
        private Texture2D GetTexture()
        {
            return ContentContainer.GetSprite(_textureName);
        }
        public void Update(GameTime gameTime)
        {
            _timeLastFrameUpdate +=gameTime.ElapsedGameTime.Milliseconds;
            if (_timeLastFrameUpdate>=_updateRate)
            {
                _currentFrame++;
                _currentFrame = _currentFrame % _framesCount;
                _timeLastFrameUpdate -= _updateRate;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GetTexture(),new Vector2(300,300),_frames[_currentFrame],Color.White);
        }

    }
}
