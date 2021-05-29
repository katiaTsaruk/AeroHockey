using SFML.Window;
using SFML.Graphics;
using System;
using System.Drawing;
using SFML.System;
using Color = SFML.Graphics.Color;

namespace AeroHockey
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}
 