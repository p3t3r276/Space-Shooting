﻿using SpaceShooting.Manager;
using System;
using System.Drawing;

namespace SpaceShooting.Entity
{
	public class BasicEnemy : Enemy
	{
		public BasicEnemy(float x, float y, Handler handler) : base(x, y, handler)
		{
			_speed = 3.0f;
		}

		public override void Update()
		{
			base.Update();
			Move();
		}

		public override void Collision()
		{
		}

		public override RectangleF GetBound()
		{
			int size = 16;
			return new RectangleF(_position.X, _position.Y, size, size);
		}

		public override void Move()
		{
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
				}
			}
		}

		public override void Render(Graphics g)
		{
			g.FillEllipse(Brushes.Red, _position.X, _position.Y, 16, 16);
			g.DrawEllipse(Pens.DarkRed, _position.X, _position.Y, 16, 16);
		}
	}
}
