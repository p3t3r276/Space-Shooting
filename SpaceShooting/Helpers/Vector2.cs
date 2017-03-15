using System;
using System.Drawing;

namespace SpaceShooting.Helpers
{
	public class Vector2
	{
		private float _x, _y;

		public Vector2(float x, float y)
		{
			_x = x;
			_y = y;
		}

		public Vector2(PointF point)
		{
			_x = point.X;
			_y = point.Y;
		}

		public float magnitude()
		{
			return (float)Math.Sqrt(_x * _x + _y * _y);
		}

		public Vector2 normalize()
		{
			float magnitude = this.magnitude();
			if (magnitude == 0) magnitude = 1;
			return new Vector2(_x / magnitude, _y / magnitude);
		}

		public static Vector2 operator +(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1._x + v2._x, v1._y + v2._y);
		}

		public static Vector2 operator *(Vector2 v, float multiplier)
		{
			return new Vector2(v._x * multiplier, v._y * multiplier);
		}

		public float X
		{
			get { return _x; }
			set { _x = value; }
		}

		public float Y
		{
			get { return _y; }
			set { _y = value; }
		}
	}
}
