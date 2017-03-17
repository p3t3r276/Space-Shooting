using SpaceShooting.Manager;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public abstract class Entity
	{
		protected float speed = 0;
		protected PointF _position, _velocity;
		protected Handler _handler;
		protected bool _up = false,
			_down = false,
			_left = false,
			_right = false;

		private float x;
		private float y;

		public Entity(float x, float y, Handler handler)
		{
			_handler = handler;
			_position = new PointF(x, y);
			_velocity = new PointF(0, 0);
		}

		public Entity(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public virtual void Update()
		{
			_position.X += _velocity.X * speed;
			_position.Y += _velocity.Y * speed;
		}
		public abstract void Render(Graphics g);
		public abstract void Collision();
		public abstract RectangleF GetBound();
		public abstract void Move();

		public PointF Position
		{
			get { return _position; }
			set { _position = value; }
		}

		public PointF Velocity
		{
			get { return _velocity; }
			set { _velocity = value; }
		}

		public bool Up
		{
			set { _up = value; }
		}

		public bool Down
		{
			set { _down = value; }
		}

		public bool Right
		{
			set { _right = value; }
		}

		public bool Left
		{
			set { _left = value; }
		}
	}
}
