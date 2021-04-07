using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathClasses;

namespace Project2D
{
	class Grid : GameObject
	{
		//Initializing the variables 
		private int m_nWidth;
		private int m_nHeight;
		//Creating a random number
		private Random rnd = new Random();

		public Grid(string Filename) : base(Filename)
		{
		}

		public override void OnCollision(GameObject otherObj)
		{
			//Sets the range of the random number to the variables
			m_nWidth = rnd.Next(50, 750);
			m_nHeight = rnd.Next(50, 550);

			//Set the new position of the Box when collided
			m_LocalTransform.m7 = m_nWidth;
			m_LocalTransform.m8 = m_nHeight;

			//When collided add 1 to the score 
			m_nScore++;

			//Call the Function to Update when collided
			UpdateTransforms();
		}
	}
}
