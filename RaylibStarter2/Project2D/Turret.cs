﻿using System;
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

		public override void Update(float fDeltaTime)
		{
			float fRotation = 0.0f;
			if (IsKeyDown(KeyboardKey.KEY_Q))
			{
				fRotation -= 2.0f * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_E))
			{
				fRotation += 2.0f * fDeltaTime;
			}
			if (IsKeyPressed(KeyboardKey.KEY_SPACE))
			{
				Bullet m_Bullet = new Bullet("../Images/Bullet.png");
				m_Bullet.SetParent(this.GetParent().GetParent());
				m_Bullet.LocalTransform = GlobalTransform;
				m_Bullet.OffSet();
			}

			Matrix3 rotation = new Matrix3();
			rotation.SetRotateZ(fRotation);
			m_LocalTransform = m_LocalTransform * rotation;

			base.Update(fDeltaTime);
		}
	}
}
