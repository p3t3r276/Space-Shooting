using SpaceShooting.Manager;
using System;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public class Bullet : Entity
	{
		public Bullet(float x, float y, Handler handler) : base(x, y, handler)
		{
			_speed = 20.0f;
			CalculateDirection();
		}

		public override void Update()
		{
			base.Update();
			Collision();
		}

		public override void Render(Graphics g)
		{
			g.FillRectangle(Brushes.Yellow, _position.X, _position.Y, 8, 8);
		}

		public override void Collision()
		{
			for (int i = 0; i < _handler.entitiesList.Count; i++)
			{
				Enemy temp = _handler.entitiesList[i] as Enemy;
				if (temp != null)
				{
					if (GetBound().IntersectsWith(temp.GetBound()))
					{
						_handler.entitiesList.Remove(this);
						temp.Health--;
					}
				}
			}
		}

		public override RectangleF GetBound()
		{
			return new RectangleF(_position.X, _position.Y, 8, 8);
		}

		public void CalculateDirection()
		{
			float diffX = Game.mousePositionRelativeToForm.X - _position.X;
			float diffY = Game.mousePositionRelativeToForm.Y - _position.Y;
			float dist = (float)Math.Sqrt(diffX * diffX + diffY * diffY);
			if (dist >= 200) dist = 200;

			_velocity.X = (1 / dist) * diffX;
			_velocity.Y = (1 / dist) * diffY;
		}

		public override void Move()
		{
		}
	}
}
