using SpaceShooting.Manager;
using System;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public class Bullet : Entity
	{
		public Bullet(float x, float y, Handler handler) : base(x, y, handler)
		{
			speed = 7.0f;
			CalculateDirection();

		}

		public override void Update()
		{
			base.Update();
		}

		public override void Render(Graphics g)
		{
			g.FillRectangle(Brushes.Yellow, _position.X, _position.Y, 8, 8);
		}

		public void CalculateDirection()
		{
			float diffX = Game.mousePositionRelativeToForm.X - _position.X;
			float diffY = Game.mousePositionRelativeToForm.Y - _position.Y;
			float dist = (float)Math.Sqrt(diffX * diffX + diffY * diffY);

			_velocity.X = (1 / dist) * diffX;
			_velocity.Y = (1 / dist) * diffY;
		}
	}
}
