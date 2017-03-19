using SpaceShooting.Manager;
using System;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public class Player : Entity
	{
		private float rotAngle;

		private bool _recovering;
		private int _recoveringTimer;

		public Player(float x, float y, Handler handler) : base(x, y, handler)
		{
			_speed = 10.0f;
			_size = 32;

			_recovering = false;
			_recoveringTimer = Environment.TickCount;
		}

		public override void Update()
		{
			base.Update();

			_position.X = Game.Clamp(_position.X, 0, Game.WIDTH - 38);
			_position.Y = Game.Clamp(_position.Y, 0, Game.HEIGHT - 32);

			Rotate();
			Recover();
			Collision();
		}

		public override void Render(Graphics g)
		{
			g.TranslateTransform(_position.X + 16, _position.Y + 16);
			g.RotateTransform(-rotAngle);
			g.TranslateTransform(-(_position.X + 16), -(_position.Y + 16));
			if (_recovering)
			{
				g.FillRectangle(Brushes.DeepPink, _position.X, _position.Y, 32, 32);
			}
			else
			{
				g.FillRectangle(Brushes.White, _position.X, _position.Y, 32, 32);
			}
			g.FillRectangle(Brushes.Orange, _position.X + 12, _position.Y + 36, 8, 8);
			g.ResetTransform();
		}

		public override void Collision()
		{
			if (!_recovering)
			{
				for (int i = 0; i < _handler.entitiesList.Count; i++)
				{
					Enemy temp = _handler.entitiesList[i] as Enemy;
					if (temp != null)
					{
						if (GetBound().IntersectsWith(temp.GetBound()))
						{
							HUD.HUD.HEALTH--;
							_recovering = true;
						}
					}
				}
			}
		}

		public override RectangleF GetBound()
		{
			return new RectangleF(_position.X, _position.Y, _size, _size);
		}

		public void Rotate()
		{
			var opp = Game.mousePositionRelativeToForm.X - _position.X;
			var adj = Game.mousePositionRelativeToForm.Y - _position.Y;
			rotAngle = (float)Math.Atan2(opp, adj) * Game.RadToDeg;
		}

		public override void Move()
		{
			if (_up) _velocity.Y = -1;
			else if (_down) _velocity.Y = 1;
			else if (_left) _velocity.X = -1;
			else if (_right) _velocity.X = 1;

			if (!_up && !_down) _velocity.Y = 0;
			if (!_left && !_right) _velocity.X = 0;
		}

		public override void Shoot()
		{
			if (_firing)
			{
				if (HUD.HUD.AMMO > 0)
				{
					int elapsed = Environment.TickCount - _firingTimer;
					if (elapsed > _firingTimerDelay)
					{
						_firingTimer = Environment.TickCount;
						_handler.entitiesList.Add(new Bullet(_position.X + _size / 2, _position.Y + _size / 2, _handler));
						HUD.HUD.AMMO--;
					}
				}
			}
		}

		public void Recover()
		{
			if (_recovering)
			{
				int elapsed = (Environment.TickCount - _recoveringTimer);
				if (elapsed > 4000)
				{
					_recovering = false;
					_recoveringTimer = Environment.TickCount;
				}
			}
		}
	}
}
