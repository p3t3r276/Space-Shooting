using System;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public class Player : Entity
	{
		private float rotAngle;
		private bool _up = false, _down = false, _left = false, _right = false;

		public Player(float x, float y) : base(x, y)
		{
			speed = 10f;
		}

		public override void Update()
		{
			base.Update();

			Rotate();

			Console.WriteLine($"{{{_position.X}, {_position.Y}}}");
		}

		public override void Render(Graphics g)
		{
			g.TranslateTransform(_position.X + 16, _position.Y + 16);
			g.RotateTransform(-rotAngle);
			g.TranslateTransform(-(_position.X + 16), -(_position.Y + 16));
			g.FillRectangle(Brushes.White, _position.X, _position.Y, 32, 32);
			g.FillRectangle(Brushes.Orange, _position.X + 12, _position.Y + 36, 8, 8);
			g.ResetTransform();
		}

		public void Rotate()
		{
			var opp = Game.mousePositionRelativeToForm.X - _position.X;
			var adj = Game.mousePositionRelativeToForm.Y - _position.Y;
			rotAngle = (float)Math.Atan2(opp, adj) * Game.Rad2Deg;
		}


		public bool Up
		{
			set { _up = value; }
		}

		public bool Down
		{
			set { _down = value; }
		}

		public bool Left
		{
			set { _left = value; }
		}

		public bool Right
		{
			set { _right = value; }
		}
	}
}
