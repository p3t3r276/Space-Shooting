using SpaceShooting.HUD;
using SpaceShooting.Manager;
using System;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public class Enemy : Entity
	{
		private int _health;
		private int _coins;
		private bool _hit;
		private int _hitTimer;

		public Enemy(float x, float y, Handler handler) : base(x, y, handler)
		{
			_health = 2;
			_speed = 6.0f;
			_size = 25;
			_coins = 1;
			_hit = false;
			_hitTimer = 0;
		}

		public override void Update()
		{
			base.Update();

			if (_hit)
			{
				int eslapsed = Environment.TickCount - _hitTimer;
				if (eslapsed > 50)
				{
					_hit = false;
					_hitTimer = 0;
				}
			}

			if (_health <= 0)
			{
				Die();
			}
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
                    break;
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

		public int Health
		{
			get { return _health; }
			set { _health = value; }
		}

		public void Die()
		{
			_handler.entitiesList.Remove(this);
			_handler.entitiesList.Add(new Explosion(_position.X, _position.Y, _handler, _size, _size + 20));
			Hud.COINS += _coins;
		}

		public bool Hitted
		{
			get { return _hit; }
			set { _hit = value; }
		}
	}
}