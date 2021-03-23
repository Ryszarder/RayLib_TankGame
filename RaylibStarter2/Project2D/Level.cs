using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
	class Level : GameObject
	{
		private Tank m_Tank = null;
		private Turret m_Turret = null;
		//private Turret = new Turret;

		public Level() : base("")
		{
			m_Tank = new Tank("../Images/Tank.png");
			m_Tank.SetParent(this);

			m_Turret = new Turret("../Images/Turret.png");
			m_Turret.SetParent(m_Tank);
		}
	}
}
