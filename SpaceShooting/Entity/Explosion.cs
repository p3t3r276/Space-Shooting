using SpaceShooting.Manager;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public class Explosion : Entity
	{
		private float _maxSize;

		public Explosion(float x, float y, Handler handler, float size, float maxSize) : base(x, y, handler)
		{
			_maxSize = maxSize;
			_size = size;
		}

		public override void Update()
		{
			_size += 1.0f;
			if (_size >= _maxSize)
			{
				_handler.entitiesList.Remove(this);
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
		}

		public override void Render(Graphics g)
		{
			g.DrawEllipse(new Pen(Color.FromArgb(140, 255, 255, 255)), _position.X, _position.Y, _size, _size);
		}
	}
}
