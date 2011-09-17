using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using XmlLibrary;
namespace SpaceRangers.Classes
{
    class ContentContainer
    {
        private static Dictionary<string, Texture> _texturesInfo;
        private static Dictionary<string, Font> _fontInfo;
        private const string TexturesXmlPath = "Xml/Textures";
        private const string FontXmlPath = "Xml/Fonts";
        private static void LoadTextures()
        {
            _texturesInfo=new Dictionary<string, Texture>();
            var textureList = Content.Load<TextureList>(TexturesXmlPath);
            foreach (var texture in textureList.Textures)
            {
                _texturesInfo.Add(texture.Name,new Texture(texture.Path));
            }
        }
        private static void LoadFonts()
        {
            _fontInfo = new Dictionary<string, Font>();
            var fontList = Content.Load<FontList>(FontXmlPath);
            foreach (var font in fontList.Fonts)
            {
                _fontInfo.Add(font.Name, new Font(font.Path));
            }
        }
        public static Texture2D GetTexture(string name)
        {
            try
            {
                return _texturesInfo[name].GetTexture();
            }
            catch(Exception e)
            {
              throw  new Exception(string.Format("Cant find a texture path with name '{0}'.Original exception: {1}",name,e.Message));
            }
        }
        public static SpriteFont GetFont(string name)
        {
            try
            {
                return _fontInfo[name].GetFont();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Cant find a texture path with name '{0}'.Original exception: {1}", name, e.Message));
            }
        }
        public static void Unload()
        {
            foreach (var info in _texturesInfo)
            {
                info.Value.Reset();
            }
        }

        internal static void LoadContentInfo()
        {
            LoadFonts();
            LoadTextures();
        }
    }
}
