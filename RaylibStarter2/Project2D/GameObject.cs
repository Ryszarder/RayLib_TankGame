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
		//Parent and childern
		protected GameObject m_Parent = null;
		protected List<GameObject> m_Children = new List<GameObject>();

		//Matrices
		protected Matrix3 m_LocalTransform;
		protected Matrix3 m_GlobalTransform;

		//Drawing
		protected Image m_Image;
		protected Texture2D m_Texture;

		protected float m_fRadius = 0.0f;

		public GameObject(string filename)
		{
			//load image and convert to texture
			m_Image = LoadImage(filename);
			m_Texture = LoadTextureFromImage(m_Image);

			m_fRadius = m_Image.width * 0.5f;

			m_LocalTransform.Identity();
			m_GlobalTransform.Identity();

			//m_LocalTransform.m7 = 200;
			//m_LocalTransform.m8 = 100;

			CollisionManager.AddObject(this);
		}

		public void SetParent(GameObject parent)
		{
			if (m_Parent != null)
				m_Parent.m_Children.Remove(this);

			m_Parent = parent;

			if (m_Parent != null)
			parent.m_Children.Add(this);
		}

		public void GetParent()
		{

		}

		public void AddChild()
		{

		}

		public void RemoveChild()
		{

		}

		public void SetPosition()
		{

		}

		public void GetPosition()
		{

		}

		public void SetScale()
		{

		}

		public void GetScale()
		{

		}

		public virtual void Update(float fDeltaTime)
		{

		}

		public void UpdateTransforms()
		{
			if (m_Parent != null)
				m_GlobalTransform = m_Parent.m_GlobalTransform * m_LocalTransform;
			else
				m_GlobalTransform = m_LocalTransform;

			foreach(GameObject child in m_Children)
			{
				child.UpdateTransforms();
			}
		}

		public void Draw()
		{
			Renderer.DrawTexture(m_Texture, m_GlobalTransform, RLColor.WHITE.ToColor());
		}

		public virtual void OnCollision(GameObject otherObj)
		{
			//Do object specifi stuff when colluded, e.g. destory or push stuff
		}

		public float GetRadius()
		{
			return m_fRadius;
		}


	}
}
