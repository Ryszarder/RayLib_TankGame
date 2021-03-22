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
		protected Matrix3 localTransform = null;
		protected Matrix3 globalTransform = null;

		//Drawing
		protected Image m_Image;
		protected Texture2D m_Texture;

		public GameObject(string filename)
		{
			//load image and convert to texture
			m_Image = LoadImage(filename);
			m_Texture = LoadTextureFromImage(m_Image);
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
				m_globalTransform = m_Parent.m_globalTransform * m_localTransform;
			else
				m_globalTransform = m_localTransform;

			foreach(GameObject child in m_Children)
			{
				child.UpdateTransforms();
			}
		}

		public void Draw()
		{
			Renderer.DrawTexture(m_Texture, m_globalTransform, RLColor.WHITE.ToColor());
		}

		public void OnCollision()
		{

		}

		public void GetRadius()
		{

		}

	}
}
