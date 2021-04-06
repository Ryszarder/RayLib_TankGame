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
		private Tank m_Tank = null;
		//private TankEnemy m_TankEnemy = null;
		private Grid m_Grid = null;

		public Level() : base("")
		{
			m_Tank = new Tank("../Images/Tank.png");
			m_Tank.SetParent(this);

			//m_TankEnemy = new TankEnemy("../Images/TankE.png");
			//m_TankEnemy.SetParent(this);

			for (int i = 0; i < 5; i++)
			{
				m_Grid = new Grid("../Images/Box.png");
				m_Grid.SetParent(this);
			}
		}
	}
}
