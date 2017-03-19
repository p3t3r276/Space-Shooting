using SpaceShooting.Manager;
using System;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public class BasicEnemy : Enemy
	{
		private Random _rand;
		private double rad;

		public BasicEnemy(float x, float y, Handler handler, Random random) : base(x, y, handler)
		{
			_health = 2;
			_speed = 8.0f;
			_size = 16;
			_rand = random;

			double angle = _rand.NextDouble() * 140 + 20;
			rad = angle * Math.PI / 180;
			_velocity.X = (float)Math.Cos(rad);
			_velocity.Y = (float)Math.Sin(rad);
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
			if (_hit)
			{
				g.FillEllipse(Brushes.White, _position.X, _position.Y, _size, _size);
			}
			else
			{
				g.FillEllipse(Brushes.Red, _position.X, _position.Y, _size, _size);
			}
		}
	}
}
