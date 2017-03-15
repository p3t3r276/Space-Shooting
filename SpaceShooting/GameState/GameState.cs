using SpaceShooting.Manager;
using System.Drawing;

namespace SpaceShooting.GameState
{
	public abstract class GameState
	{
		protected GameStateManager _gsm;

		public GameState(GameStateManager gsm)
		{
			_gsm = gsm;
		}

		public abstract void Render(Graphics g);
		public abstract void Update();
	}
}
