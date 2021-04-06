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
		private int m_nWidth;
		private int m_nHeight;
		private Random rnd = new Random();

		public Grid(string Filename) : base(Filename)
		{
			m_LocalTransform.m7 = 400;
			m_LocalTransform.m8 = 100;
		}

		public override void OnCollision(GameObject otherObj)
		{
			m_nWidth = rnd.Next(50, 750);
			m_nHeight = rnd.Next(50, 550);

			m_LocalTransform.m7 = m_nWidth;
			m_LocalTransform.m8 = m_nHeight;

			//m_nScore++;

			//DrawText(Convert.ToString(m_nScore), 780, 20, 20, RLColor.BLACK);

			UpdateTransforms();
		}
	}
}
