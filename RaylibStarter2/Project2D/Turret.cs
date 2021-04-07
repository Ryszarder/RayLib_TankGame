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

		public Turret(string Filename) : base(Filename)
		{	
		}

		//Sets so when the keys are activated that make an action 
		public override void Update(float fDeltaTime)
		{
			//Set to 0 so the turret doesn't keep rotating
			float fRotation = 0.0f;

			//When hold down the Turret roatates left
			if (IsKeyDown(KeyboardKey.KEY_Q))
			{
				fRotation -= 2.0f * fDeltaTime;
			}
			//When hold down the Turret roatates right
			if (IsKeyDown(KeyboardKey.KEY_E))
			{
				fRotation += 2.0f * fDeltaTime;
			}
			//When pressed the Turret will fire a bullet
			if (IsKeyPressed(KeyboardKey.KEY_SPACE))
			{
				//Creates the Bullet here to be draw when space is pressed
				Bullet m_Bullet = new Bullet("../Images/Bullet.png");
				m_Bullet.SetParent(this.GetParent().GetParent());
				//Sets the LocalTransform to the GlobalTransform so it doesn't move when the Tank rotates
				m_Bullet.LocalTransform = GlobalTransform;
				//Set the distance from where the bullet is draw so it doesn't collide with the Tank
				m_Bullet.OffSet();
			}

			Matrix3 rotation = new Matrix3();
			rotation.SetRotateZ(fRotation);
			m_LocalTransform = m_LocalTransform * rotation;

			base.Update(fDeltaTime);
		}
	}
}
