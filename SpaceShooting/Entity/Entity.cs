using System.Drawing;

namespace SpaceShooting.Entity
{
	public abstract class Entity
	{
		protected float _x, _y, _velX, _velY, size;
		protected Color color;
		protected float speed = 1;

		public Entity(float x, float y)
		{

			_x = x;
			_y = y;
		}

		public void Update()
		{
			_x += _velX;
			_y += _velY;
		}
		public abstract void Render(Graphics g);
	}
}
