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
	class Bullet : GameObject
	{
		private Vector2 m_v2Velocity = new Vector2(0, -700);

		public Bullet(string Filename) : base(Filename)
		{
		}

		public override void Update(float fDeltaTime)
		{
			Matrix3 translation = new Matrix3();
			translation.SetTranslation(m_v2Velocity * fDeltaTime);
			m_LocalTransform = m_LocalTransform * translation;

			base.Update(fDeltaTime);
		}

		public void OffSet()
		{
			m_LocalTransform.m7 -= m_LocalTransform.m4 * 60;
			m_LocalTransform.m8 -= m_LocalTransform.m5 * 60;
		}
	}
}
