using SpaceShooting.Manager;
using System;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public class BasicEnemy : Enemy
	{
		Random rand = new Random();

		public BasicEnemy(float x, float y, Handler handler) : base(x, y, handler)
		{
			_health = 2;
			_speed = 8.0f;
			_size = 16;
			_velocity.X = 1;
			_velocity.Y = -1;
		}

		public override void Update()
		{
			base.Update();
		}

		public override void Collision()
		{
		}

		public override RectangleF GetBound()
		{
			return new RectangleF(_position.X, _position.Y, _size, _size);
		}

		public override void Move()
		{
			if (_position.X <= 0 || _position.X >= Game.WIDTH - 16)
			{
				_velocity.X = -_velocity.X;
			}

			if (_position.Y <= 0 || _position.Y >= Game.HEIGHT - 16)
			{
				_velocity.Y = -_velocity.Y;
			}
		}

		public override void Render(Graphics g)
		{
			g.FillEllipse(Brushes.Red, _position.X, _position.Y, _size, _size);
		}
	}
}
