using SpaceShooting.Manager;
using System;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public class BasicEnemy : Enemy
	{
		public BasicEnemy(float x, float y, Handler handler) : base(x, y, handler)
		{
			_health = 2;
			_speed = 6.0f;
			_size = 20;
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
			// áp sát Player
			for (int i = 0; i < _handler.entitiesList.Count; i++)
			{
				Entity target = _handler.entitiesList[i];
				if (target is Player)
				{
					float diffX = target.Position.X - _position.X;
					float diffY = target.Position.Y - _position.Y;
					float dist = (float)Math.Sqrt(diffX * diffX + diffY * diffY);

					_velocity.X = (1 / dist) * diffX;
					_velocity.Y = (1 / dist) * diffY;
				}
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
				g.FillEllipse(Brushes.ForestGreen, _position.X, _position.Y, _size, _size);
			}
		}
	}
}
