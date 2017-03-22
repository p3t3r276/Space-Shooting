using SpaceShooting.HUD;
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
			_size = 40;

			_recovering = false;
			_recoveringTimer = Environment.TickCount;
		}

		public override void Update()
		{
			base.Update();

			_position.X = Game.Clamp(_position.X, 0, Game.WIDTH - 38);
			_position.Y = Game.Clamp(_position.Y, 0, Game.HEIGHT - _size);

			Rotate();
			Recover();
			Collision();
		}

		public override void Render(Graphics g)
		{
			g.TranslateTransform(_position.X + _size / 2, _position.Y + _size / 2);
			g.RotateTransform(-rotAngle);
			g.TranslateTransform(-(_position.X + _size / 2), -(_position.Y + _size / 2));
			if (_recovering)
			{
				g.FillEllipse(Brushes.DeepPink, _position.X, _position.Y, _size, _size);
			}
			else
			{
				g.FillEllipse(Brushes.White, _position.X, _position.Y, _size, _size);
			}
			g.FillRectangle(Brushes.Orange, _position.X + (_size - 4) / 2, _position.Y + _size, 8, 8);
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
							Hud.HEALTH--;
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
			//Tinh góc quay theo vik trí chuột
			var opp = Game.mousePositionRelativeToForm.X - _position.X + _size / 2;
			var adj = Game.mousePositionRelativeToForm.Y - _position.Y + _size / 2;
			rotAngle = (float)Math.Atan2(opp, adj) * Game.RadToDeg;
		}

		public override void Move()
		{
			if (_up) _velocity.Y = -1;
			if (_down) _velocity.Y = 1;
			if (_left) _velocity.X = -1;
			if (_right) _velocity.X = 1;

			if (!_up && !_down) _velocity.Y = 0;
			if (!_left && !_right) _velocity.X = 0;
		}

		public override void Attack()
		{
			if (_firing)
			{
				// Chỉ bắn khi còn đạn
				if (Hud.AMMO > 0)
				{
					if (Environment.TickCount > _firingTimerDelay + _firingTimer)
					{
						_firingTimer = Environment.TickCount;
						_handler.entitiesList.Add(new Bullet(_position.X + _size / 2, _position.Y + _size / 2, _handler));
						Hud.AMMO--;
					}
				}
			}
		}

		public void Recover()
		{
			if (_recovering)
			{
				if (Environment.TickCount > _recoveringTimer + 2000)
				{
					_recovering = false;
					_recoveringTimer = Environment.TickCount;
				}
			}
		}
	}
}
