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
	class Turret : GameObject
	{
		private Bullet m_Bullet = null;

		public Turret(string Filename) : base(Filename)
		{
			
			m_Bullet.SetParent(this);
		}

		public override void Update(float fDeltaTime)
		{
			float fRotation = 0.0f;
			if (IsKeyDown(KeyboardKey.KEY_LEFT))
			{
				fRotation -= 2.0f * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_RIGHT))
			{
				fRotation += 2.0f * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_SPACE))
			{
				m_Bullet = new Bullet("../Images/Bullet.png");
			}

			Matrix3 rotation = new Matrix3();
			rotation.SetRotateZ(fRotation);
			m_LocalTransform = m_LocalTransform * rotation;

			base.Update(fDeltaTime);
		}
	}
}
