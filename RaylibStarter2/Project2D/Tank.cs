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
	class Tank : GameObject
	{
		private Vector2 m_v2Velocity;
		private float m_fSpeed = 200.0f;

		public Tank(string filename) : base(filename)
		{
			m_LocalTransform.m7 = 200;
			m_LocalTransform.m8 = 100;

			m_v2Velocity.x = 0;
			m_v2Velocity.y = 0;
		}

		public override void Update(float fDeltaTime)
		{
			float fRotation = 0.0f;
			//update velocity via input
			if(IsKeyDown(KeyboardKey.KEY_W))
			{
				m_v2Velocity.y -= m_fSpeed * fDeltaTime;
			}
			if(IsKeyDown(KeyboardKey.KEY_D))
			{
				fRotation -= 1.0f * fDeltaTime;
			}

			//add velocity to our transforms
			Matrix3 translation = new Matrix3();
			translation.SetTranslation(m_v2Velocity * fDeltaTime);

			m_LocalTransform = m_LocalTransform * translation;

			Matrix3 rotation = new Matrix3();
			rotation.SetRotateZ(fRotation);
			m_LocalTransform = m_LocalTransform * rotation;

			base.Update(fDeltaTime);
		}
	}
}
