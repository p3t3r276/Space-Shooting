using System.Drawing;

namespace SpaceShooting.Entity
{
	public class Player : Entity
	{
		public Player(float x, float y) : base(x, y)
		{
		}

		public override void Render(Graphics g)
		{
			g.FillRectangle(Brushes.White, _y, _y, 100, 100);
		}
	}
}
