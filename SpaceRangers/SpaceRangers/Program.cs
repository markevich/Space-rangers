using System;

namespace SpaceRangers
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (RangersGame game = new RangersGame())
            {
                game.Run();
            }
        }
    }
#endif
}

