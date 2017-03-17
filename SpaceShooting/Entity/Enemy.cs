using SpaceShooting.Manager;

namespace SpaceShooting.Entity
{
	public abstract class Enemy : Entity
	{
		protected int _health;

		public Enemy(float x, float y, Handler handler) : base(x, y, handler)
		{
			_health = 0;
		}

		public override void Update()
		{
			base.Update();
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
			}
		}
	}
}
