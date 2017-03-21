using SpaceShooting.HUD;
using SpaceShooting.Manager;
using System;

namespace SpaceShooting.Entity
{
	public abstract class Enemy : Entity
	{
		protected int _health;
		protected bool _hit;
		protected int _hitTimer;

		public Enemy(float x, float y, Handler handler) : base(x, y, handler)
		{
			_health = 0;
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
			Die();
		}

		public int Health
		{
			get { return _health; }
			set { _health = value; }
		}

		public void Die()
		{
			if (_health <= 0)
			{
				_handler.entitiesList.Remove(this);
				_handler.entitiesList.Add(new Explosion(_position.X, _position.Y, _handler, _size, _size + 20));
				Hud.COINS++;
			}
		}

		public bool Hitted
		{
			get { return _hit; }
			set { _hit = value; }
		}
	}
}
