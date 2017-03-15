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
			speed = 10.0f;
		}

		public override void Update()
		{
			base.Update();

			_position.X = Game.Clamp(_position.X, 0, Game.WIDTH - 38);
			_position.Y = Game.Clamp(_position.Y, 0, Game.HEIGHT - 32);

			Rotate();
			Move();
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

		public void Move()
		{
			if (_up) _velocity.Y = -1;
			else if (_down) _velocity.Y = 1;
			else if (_left) _velocity.X = -1;
			else if (_right) _velocity.X = 1;

			if (!_up && !_down) _velocity.Y = 0;
			if (!_left && !_right) _velocity.X = 0;
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
