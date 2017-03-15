using SpaceShooting.Entity;
using SpaceShooting.Manager;
using System.Drawing;

namespace SpaceShooting.GameState
{
	public class PlayState : GameState
	{
		Player player;
		public PlayState(GameStateManager gsm) : base(gsm)
		{
			player = new Player(50, 50);
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
