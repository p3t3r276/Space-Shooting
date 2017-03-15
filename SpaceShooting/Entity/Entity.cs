using System.Drawing;

namespace SpaceShooting.Entity
{
	public abstract class Entity
	{
		protected float _x, _y, _velX, _velY, size;
		protected float speed = 1.0f;

		public Entity(float x, float y)
		{
			_x = x;
			_y = y;
		}

		public virtual void Update()
		{
			_x += _velX;
			_y += _velY;
		}
		public abstract void Render(Graphics g);
	}
}
