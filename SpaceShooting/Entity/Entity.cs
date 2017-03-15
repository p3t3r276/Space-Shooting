using System.Drawing;

namespace SpaceShooting.Entity
{
	public abstract class Entity
	{
		protected float speed = 0;
		protected PointF _position, _velocity;

		public Entity(float x, float y)
		{
			_position = new PointF(x, y);
			_velocity = new PointF(0, 0);
		}

		public virtual void Update()
		{
			_position.X += _velocity.X * speed;
			_position.Y += _velocity.Y * speed;
		}
		public abstract void Render(Graphics g);
	}
}
