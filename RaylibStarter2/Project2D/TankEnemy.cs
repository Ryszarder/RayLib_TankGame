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
	class TankEnemy : GameObject
	{
		private Vector2 m_v2Velocity;
		private float m_fSpeed = 200.0f;

		public TankEnemy(string Filename) : base(Filename)
		{
			m_LocalTransform.m7 = 400;
			m_LocalTransform.m8 = 400;

			m_v2Velocity.x = 0;
			m_v2Velocity.y = 0;
		}

		public override void Update(float fDeltaTime)
		{
			float fRotation = 0.0f;

			//update velocity via input
			if (IsKeyDown(KeyboardKey.KEY_I))
			{
				m_v2Velocity.y -= m_fSpeed * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_K))
			{
				m_v2Velocity.y += m_fSpeed * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_J))
			{
				fRotation -= 2.0f * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_L))
			{
				fRotation += 2.0f * fDeltaTime;
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
		public override void OnCollision(GameObject otherObj)
		{
			//m_LocalTransform.m7 = m_v2PrevPosition.x;
			//m_LocalTransform.m8 = m_v2PrevPosition.y;

			////	//Circle collision - calaulate normal
			//Vector2 v2Normal = otherObj.GetPosition() - GetPosition();
			//v2Normal.Normalise();

			////	////Calaulate reflection
			//Vector2 reflection = -2.0f * m_v2Velocity.Dot(v2Normal) * v2Normal + m_v2Velocity;

			////	////Change dircetion
			//m_v2Velocity = reflection;

			//m_v2Velocity.x = -1000;

			m_LocalTransform.m7 = m_v2PrevPosition.x;
			m_LocalTransform.m8 = m_v2PrevPosition.y;

			//m_v2Velocity.x = 0;
			//m_v2Velocity.y = 0;

			m_v2Velocity = m_v2Velocity * -1f;

			UpdateTransforms();
		}
	}
}
