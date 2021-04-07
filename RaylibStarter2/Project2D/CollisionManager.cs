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
		//Creates a new list for the objects
		private static List<GameObject> m_ObjectList = new List<GameObject>();

		public static void AddObject(GameObject obj)
		{
			m_ObjectList.Add(obj);
		}

		//Fucntions is ckecking when to objects collide
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

					//Calculating to set the new local variables with the object Min,Max and position
					Vector2 obj1Min = obj1.GetMin() + obj1.GetPosition();
					Vector2 obj1Max = obj1.GetMax() + obj1.GetPosition();
					Vector2 obj2Min = obj2.GetMin() + obj2.GetPosition();
					Vector2 obj2Max = obj2.GetMax() + obj2.GetPosition();

					//Compares obj1 Max is greater than obj2 Min and obj1 Min is less than obj2 Max
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
