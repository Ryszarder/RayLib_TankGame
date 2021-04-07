using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    class Game
    {
		//Creates a new stopwatch variable
        Stopwatch stopwatch = new Stopwatch();

		//Sets the variables to use for the stopwatch
        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;

		//Gives the level class a member variable
		private Level m_Level = null;

		public Game()
        {
        }

        public void Init()
        {
			//Runs the Start function on the stopwatch
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
				//Writes in the console how many ticks per second
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }

			//Initialize objects here
			m_Level = new Level();
		}

        public void Shutdown()
        {
        }

        public void Update()
        {
            lastTime = currentTime;
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

			//Update game objects here    
			m_Level.Update(deltaTime);
			m_Level.UpdateTransforms();
			
			//check collision after all objects have been updated
			CollisionManager.CheckCollision();
		}

        public void Draw()
        {
            BeginDrawing();

			//Make the background colour of the program
            ClearBackground(RLColor.LIGHTGRAY);

			//Draw game objects here
			//Draws in the top left corner the fps counter display
            DrawText(fps.ToString(), 10, 10, 14, RLColor.BLUE);

			//Draws the objects/variables in the Level class
			m_Level.Draw();

			EndDrawing();
        }

    }
}
