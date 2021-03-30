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
	static class CollisionManager
	{
		private static List<GameObject> m_ObjectList = new List<GameObject>();

		public static void AddObject(GameObject obj)
		{
			m_ObjectList.Add(obj);
		}

		public static void CheckCollision()
		{
			//test Collision here
			foreach(GameObject obj1 in m_ObjectList)
			{
				foreach(GameObject obj2 in m_ObjectList)
				{
					//don't have objects collide with themselves
					if (obj1 == obj2)
						continue;

					Vector2 obj1Min = obj1.GetMin() + obj1.GetPosition();
					Vector2 obj1Max = obj1.GetMax() + obj1.GetPosition();
					Vector2 obj2Min = obj2.GetMin() + obj2.GetPosition();
					Vector2 obj2Max = obj2.GetMax() + obj2.GetPosition();

					if (obj1Max.x > obj2Min.x &&
						obj1Max.y > obj2Min.y &&
						obj1Min.x < obj2Max.x &&
						obj1Min.y < obj2Max.y)
					{
						obj1.OnCollision(obj2);
					}
				}
			}
		}
	}
}
