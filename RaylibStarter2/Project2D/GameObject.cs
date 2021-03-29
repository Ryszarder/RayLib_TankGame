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

		//protected float m_fRadius = 0.0f;
		//protected Vector2 m_v2PrevPosition;

		//protected string Filename;

		//Collision
		//protected bool m_bEnableCollision = true;
		protected Vector2 m_v2Min;
		protected Vector2 m_v2Max;
		protected Vector2 m_v2PrevPosition;

		public GameObject(string Filename)
		{
			//load image and convert to texture
			m_Image = LoadImage(Filename);
			m_Texture = LoadTextureFromImage(m_Image);

			m_v2Min.x = -(m_Texture.width * 0.5f);
			m_v2Min.y = -(m_Texture.height * 0.5f);

			m_v2Max.x = (m_Texture.width * 0.5f);
			m_v2Max.y = (m_Texture.height * 0.5f);

			//m_fRadius = m_Image.width * 0.5f;

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

		public Vector2 GetPosition()
		{
			return new Vector2(m_GlobalTransform.m7 , m_GlobalTransform.m8);
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
				m_v2PrevPosition = GetPosition() - m_Parent.GetPosition();
			else
				m_v2PrevPosition = GetPosition();

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

		public virtual void OnCollision(GameObject otherObj)// float fPenetration, Vector2 v2HitDirection
		{
			//Do object specifi stuff when colluded, e.g. destory or push stuff
			//Vector2 relfection = -2 * (dot(vel, normal) * normal + vel;
		}


		//public float GetRadius()
		//{
		//	return m_fRadius;
		//}

		public Vector2 GetMin()
		{
			return m_v2Min;
		}

		public Vector2 GetMax()
		{
			return m_v2Max;
		}


	}
}
