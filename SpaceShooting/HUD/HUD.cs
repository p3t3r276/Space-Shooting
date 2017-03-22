using System.Drawing;

namespace SpaceShooting.HUD
{
	public class Hud
	{
		public static int HEALTH = 10;
		public static int AMMO = 100;
		public static int COINS = 0;

		public Hud()
		{
		}

		public void Update()
		{
		}

		public void Render(Graphics g)
		{
			g.DrawString($"COINS: {COINS}", new Font("Arial", 25f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.White, 32, 32);
			g.FillRectangle(Brushes.OrangeRed, 32, Game.HEIGHT - 40, HEALTH * 20, 30);
			g.DrawRectangle(Pens.White, 32, Game.HEIGHT - 40, 200, 30);
			g.FillRectangle(Brushes.DarkBlue, Game.WIDTH - 250, Game.HEIGHT - 40, AMMO * 2, 30);
			g.DrawRectangle(Pens.White, Game.WIDTH - 250, Game.HEIGHT - 40, 200, 30);

		}
	}
}
