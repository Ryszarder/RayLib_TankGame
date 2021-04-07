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
		//Initializing the variables 
		private Vector2 m_v2Velocity;
		private float m_fSpeed = 200.0f;
		private Turret m_Turret = null;

		public Tank(string Filename) : base(Filename)
		{
			//Sets the position in the game where the tank starts
			m_LocalTransform.m7 = 400;
			m_LocalTransform.m8 = 300;

			//Sets it Velocity to 0 so it doesn't always move even when the key isn't pressed
			m_v2Velocity.x = 0;
			m_v2Velocity.y = 0;

			//Creates the Turret object to be draw and set as the child of the Tank
			m_Turret = new Turret("../Images/Turret.png");
			m_Turret.SetParent(this);
		}

		public override void Update(float fDeltaTime)
		{
			//Set rotation to 0 so it won't always be rotating
			float fRotation = 0.0f;

			//update velocity via input
			if (IsKeyDown(KeyboardKey.KEY_W))
			{
				//Takes the answer from the multiplication and takes it away from m_v2Velocity value
				//Meaning when the Key is hold down it goes forward
				m_v2Velocity.y -= m_fSpeed * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_S))
			{
				//Takes the answer from the multiplication and adds it to m_v2Velocity value
				//Meaning when the Key is hold down it goes backwards
				m_v2Velocity.y += m_fSpeed * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_A))
			{
				//Decides how fast the Tank will rotate left 
				fRotation -= 2.0f * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_D))
			{
				//Decides how fast the Tank will rotate right 
				fRotation += 2.0f * fDeltaTime;
			}

			//Add velocity to our transforms
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
			m_LocalTransform.m7 = m_v2PrevPosition.x;
			m_LocalTransform.m8 = m_v2PrevPosition.y;

			//stop in place
			//m_v2Velocity.x = 0;
			//m_v2Velocity.y = 0;

			//Bounce off
			m_v2Velocity = m_v2Velocity * -1;

			UpdateTransforms();
		}
	}
}
