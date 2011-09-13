using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SpaceRangers.Classes
{
    static class Content
    {
        private static ContentManager content;
        public static void Initialize(Game game)
        {
            content = game.Content;
        }
        public static T Load<T>(string path)
        {
            try
            {
                var item =content.Load<T>(path);
                return item;
            }
            catch (Exception e)
            {
                throw new Exception("Error on loading content with type "+typeof(T)+". Original exception:"+e.Message);
            }
        }
        public static void Unload()
        {
            content.Unload();
            ContentContainer.Unload();
        }
    }
}
