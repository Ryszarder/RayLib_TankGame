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
		//public Vector2 m_v2Centre = new Vector2();
		//public float m_fRadius = 0.0f;

		//public CollisionManager(Vector2 v2Centre,)

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

					//test collision
					Vector2 difference = obj1.GetPosition() - obj2.GetPosition();
					float dist = difference.Magnitude();
					float combinedRaduis = obj1.GetRadius() + obj2.GetRadius();
					if(dist < combinedRaduis)
					{
						//folat fPenetration = combinedRadius - dist;
						//differeence.Normalsed();

						//if colliding, resovle collision
						obj1.OnCollision(obj2);
					}
					
				}
			}
		}
	}
}
