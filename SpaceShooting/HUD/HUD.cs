using System.Drawing;

namespace SpaceShooting.HUD
{
	public class Hud
	{
		public static int HEALTH = 10;
		public static int AMMO = 100;
		public static int COINS = 0;

		Font fnt;

		public Hud()
		{
			fnt = new Font("Arial", 20f, FontStyle.Bold, GraphicsUnit.Pixel);
		}

		public void Update()
		{
		}

		public void Render(Graphics g)
		{
			//draw coins
			g.DrawString($"COINS: {COINS}", new Font("Arial", 25f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.White, 32, 32);

			//draw health
			g.DrawString("HEALTH: ", fnt, Brushes.White, 32, Game.HEIGHT - 80);
			g.FillRectangle(Brushes.OrangeRed, 32, Game.HEIGHT - 50, HEALTH * 20, 40);
			g.DrawRectangle(Pens.White, 32, Game.HEIGHT - 50, 200, 40);

			//draw ammo
			g.DrawString("AMMO: ", fnt, Brushes.White, Game.WIDTH - 250, Game.HEIGHT - 80);
			g.FillRectangle(Brushes.DarkBlue, Game.WIDTH - 250, Game.HEIGHT - 50, AMMO * 2, 40);
			g.DrawRectangle(Pens.White, Game.WIDTH - 250, Game.HEIGHT - 50, 200, 40);
		}

		public static void Reset()
		{
			HEALTH = 10;
			AMMO = 100;
			COINS = 0;
		}
	}
}
