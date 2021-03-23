using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
	class Turret : GameObject
	{
		public Turret(string Filename) : base(Filename)
		{
			this.Filename = Filename;
		}
	}
}
