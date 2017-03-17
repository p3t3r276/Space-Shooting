using SpaceShooting.Manager;
using System;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public class Bullet : Entity
	{
		public Bullet(float x, float y, Handler handler) : base(x, y, handler)
		{
			speed = 20.0f;
			Move();
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
				Entity temp = _handler.entitiesList[i];
				if (temp is BasicEnemy)
				{
					if (GetBound().IntersectsWith(temp.GetBound()))
					{
						_handler.entitiesList.Remove(temp);
						_handler.entitiesList.Remove(this);
					}
				}
			}
		}

		public override RectangleF GetBound()
		{
			return new RectangleF(_position.X, _position.Y, 8, 8);
		}

		public override void Move()
		{
			float diffX = Game.mousePositionRelativeToForm.X - _position.X;
			float diffY = Game.mousePositionRelativeToForm.Y - _position.Y;
			float dist = (float)Math.Sqrt(diffX * diffX + diffY * diffY);
			if (dist <= 50) dist = 50;

			_velocity.X = (1 / dist) * diffX;
			_velocity.Y = (1 / dist) * diffY;
		}
	}
}
