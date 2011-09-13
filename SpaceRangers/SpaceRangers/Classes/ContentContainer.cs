using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using XmlLibrary;
namespace SpaceRangers.Classes
{
    static class ContentContainer
    {
        private static Dictionary<String, Texture> TexturesInfo;
        private const string TexturesXmlPath = "Xml/Textures";
        public static void LoadTextures()
        {
            TexturesInfo=new Dictionary<string, Texture>();
            var textureList = Content.Load<TextureList>(TexturesXmlPath);
            foreach (var texture in textureList.Textures)
            {
                TexturesInfo.Add(texture.Name,new Texture(texture.Path));
            }
        }
        public static Texture2D GetTexture(string name)
        {
            try
            {
                return TexturesInfo[name].GetTexture();
            }
            catch(Exception e)
            {
              throw  new Exception(string.Format("Cant find a texture path with name '{0}'.Original exception: {1}",name,e.Message));
            }
        }
        public static void Unload()
        {
            foreach (var info in TexturesInfo)
            {
                info.Value.Reset();
            }
        }
    }
}
