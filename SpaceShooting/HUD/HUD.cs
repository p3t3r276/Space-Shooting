using SpaceShooting.Manager;
using System.Drawing;

namespace SpaceShooting.HUD
{
	public class Hud
	{
		Handler _handler;
		public static int HEALTH = 10;
		public static int AMMO = 100;
		public static int COINS = 0;

		public Hud(Handler handler)
		{
			_handler = handler;
		}

		public void Update()
		{
		}

		public void Render(Graphics g)
		{
			g.DrawString($"COINS: {COINS}", new Font("Arial", 25f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.White, 32, 32);
			g.DrawString($"HEALTH: {HEALTH} of 10", new Font("Arial", 25f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.White, 32, Game.HEIGHT - 40);
			g.DrawString($"AMMO: {AMMO} of 100", new Font("Arial", 25f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.White, Game.WIDTH - 250, Game.HEIGHT - 40);
		}
	}
}
