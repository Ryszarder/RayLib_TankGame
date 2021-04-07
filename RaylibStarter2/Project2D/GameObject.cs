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

		//Collision
		protected Vector2 m_v2Min;
		protected Vector2 m_v2Max;
		protected Vector2 m_v2PrevPosition;

		//Score
		protected int m_nScore = 0;

		public GameObject(string Filename)
		{
			//load image and convert to texture
			m_Image = LoadImage(Filename);
			m_Texture = LoadTextureFromImage(m_Image);

			
			m_v2Min.x = -(m_Texture.width * 0.5f);
			m_v2Min.y = -(m_Texture.height * 0.5f);

			//Set the Min of the objects x-axis and y-axis
			m_v2Max.x = (m_Texture.width * 0.5f);
			m_v2Max.y = (m_Texture.height * 0.5f);

			//Sets the Identity matrix to the LocalTransform and GlobalTransform
			m_LocalTransform.Identity();
			m_GlobalTransform.Identity();

			CollisionManager.AddObject(this);
		}

		//Function sets the hierarchy of objects being the parent or child
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

		//Get the new position of the object
		public Vector2 GetPosition()
		{
			return new Vector2(m_LocalTransform.m7 , m_LocalTransform.m8);
		}

		//Function that can be override so all other class can be updated
		public virtual void Update(float fDeltaTime)
		{
			//Updates the Cildren in the game
			for (int i = 0; i < m_Children.Count; ++i)
			{
				m_Children[i].Update(fDeltaTime);
			}
		}

		public void UpdateTransforms()
		{
			//Calculate the value for the m_v2PrevPosition
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

		//Draws all the objects and text on the program
		public void Draw()
		{
			Renderer.DrawTexture(m_Texture, m_GlobalTransform, RLColor.WHITE.ToColor());

			foreach (GameObject child in m_Children)
			{
				child.Draw();
			}

			//Draws the score text in the top left corner
			DrawText(m_nScore.ToString(), 780, 20, 20, RLColor.BLACK);
		}

		//Allow the other class objects to override the Function to do different action when collided
		public virtual void OnCollision(GameObject otherObj)
		{
		}

		//Get Vector2 Min for objects
		public Vector2 GetMin()
		{
			return m_v2Min;
		}

		//Get Vector2 Max for objects
		public Vector2 GetMax()
		{
			return m_v2Max;
		}
	}
}
