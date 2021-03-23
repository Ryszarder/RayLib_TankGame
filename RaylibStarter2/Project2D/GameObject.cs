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

		public Matrix3 LocalTransform
		{
			get { return m_LocalTransform;  }
			set { m_LocalTransform = value;  }
		}

		public Matrix3 GlobalTransform
		{
			get { return m_GlobalTransform; }
			set { m_GlobalTransform = value; }
		}


		//Drawing
		protected Image m_Image;
		protected Texture2D m_Texture;

		protected float m_fRadius = 0.0f;

		protected string Filename;

		public GameObject(string Filename)
		{
			//load image and convert to texture
			m_Image = LoadImage(Filename);
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

		public GameObject GetParent()
		{
			if (m_Parent != null)
				return m_Parent;
			else
				return null;
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
			//foreach (GameObject child in m_Children)
			//{
			//	child.Update(fDeltaTime);
			//}
			for (int i = 0; i < m_Children.Count; ++i)
			{
				m_Children[i].Update(fDeltaTime);
			}
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

			foreach (GameObject child in m_Children)
			{
				child.Draw();
			}
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
