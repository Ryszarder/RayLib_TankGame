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
	class GameObject
	{
		protected GameObject parent = null;
		protected List<GameObject> m_Children = new List<GameObject>();
		protected Matrix3 localTransform = new Matrix3();
		protected Matrix3 globalTransform = new Matrix3();
		protected Image m_Sprite;
		protected Texture2D m_Texture;


		public void GetParent()
		{

		}

		public void SetParent()
		{

		}

		public void AddChild()
		{

		}

		public void RemoveChild()
		{

		}

		public void GetPosition()
		{

		}

		public void SetPosition()
		{

		}

		public void GetScale()
		{

		}

		public void SetScale()
		{

		}

		public void Update()
		{

		}

		public void UpdateTransforms()
		{

		}

		public void Draw()
		{

		}

		public void OnCollision()
		{

		}

		public void GetRadius()
		{

		}

	}
}
