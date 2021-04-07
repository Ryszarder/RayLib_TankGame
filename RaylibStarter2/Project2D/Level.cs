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
	class Level : GameObject
	{
		//Creates the variables of objects names
		private Tank m_Tank = null;
		
		private Grid m_Grid = null;

		//private TankEnemy m_TankEnemy = null;

		//Sets the object to fine it's location and draw it's sprite and set it as the parent
		public Level() : base("")
		{
			m_Tank = new Tank("../Images/Tank.png");
			m_Tank.SetParent(this);

			//Runs a for loop to draw 5 of the same object
			for (int i = 0; i < 5; i++)
			{
				m_Grid = new Grid("../Images/Box.png");
				m_Grid.SetParent(this);
			}

			//m_TankEnemy = new TankEnemy("../Images/TankE.png");
			//m_TankEnemy.SetParent(this);
		}
	}
}
