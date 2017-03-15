using SpaceShooting.Entity;
using SpaceShooting.Manager;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.GameState
{
	public class PlayState : GameState
	{
		Player player;

		public PlayState(GameStateManager gsm) : base(gsm)
		{
			player = new Player((Game.WIDTH - 16) / 2, (Game.HEIGHT - 16) / 2);
		}

		public override void KeyUp(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.W:
					player.Up = false;
					break;
				case Keys.S:
					player.Down = false;
					break;
				case Keys.A:
					player.Left = false;
					break;
				case Keys.D:
					player.Right = false;
					break;
			}
		}

		public override void KeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.W:
					player.Up = true;
					break;
				case Keys.S:
					player.Down = true;
					break;
				case Keys.A:
					player.Left = true;
					break;
				case Keys.D:
					player.Right = true;
					break;
			}
		}

		public override void Render(Graphics g)
		{
			player.Render(g);
		}

		public override void Update()
		{
			player.Update();
		}
	}
}
