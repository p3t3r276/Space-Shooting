using SpaceShooting.Manager;
using System;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public abstract class Entity
	{
		protected float _speed = 0;
		protected int _size = 0;
		protected PointF _position, _velocity;
		protected Handler _handler;

		protected bool _up = false;
		protected bool _down = false;
		protected bool _left = false;
		protected bool _right = false;

		protected bool _firing;
		protected int _firingTimer;
		protected int _firingTimerDelay;

		public Entity(float x, float y, Handler handler)
		{
			_handler = handler;
			_position = new PointF(x, y);
			_velocity = new PointF(0, 0);

			_firing = false;
			_firingTimer = Environment.TickCount;
			_firingTimerDelay = 200;
		}

		public virtual void Update()
		{
			_position.X += _velocity.X * _speed;
			_position.Y += _velocity.Y * _speed;

			Shoot();
			Move();
		}
		public abstract void Render(Graphics g);
		public abstract void Collision();
		public abstract RectangleF GetBound();
		public abstract void Move();

		public virtual void Shoot()
		{
			if (_firing)
			{
				int elapsed = Environment.TickCount - _firingTimer;
				if (elapsed > _firingTimerDelay)
				{
					_firingTimer = Environment.TickCount;
					_handler.entitiesList.Add(new Bullet(_position.X + _size / 2, _position.Y + _size / 2, _handler));
				}
			}
		}

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

		public bool Firing
		{
			set { _firing = value; }
		}
	}
}
