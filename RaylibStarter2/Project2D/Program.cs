using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

			//Set the width and height of the program
            InitWindow(800, 600, "Hello World");
			
            game.Init();

			//While the game is running loop through these functions
            while (!WindowShouldClose())
            {
                game.Update();
                game.Draw();
            }

            game.Shutdown();

            CloseWindow();
        }
    }
}
