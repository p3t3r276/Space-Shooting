using SpaceShooting.Manager;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.GameState
{
	public abstract class GameState
	{
		protected GameStateManager _gsm;
		protected Handler _handler;

		public GameState(GameStateManager gsm, Handler handler)
		{
			_gsm = gsm;
			_handler = handler;
		}

		public void Render(Graphics g)
		{
			_handler.Render(g);
		}
		public void Update()
		{
			_handler.Update();
		}
		public abstract void KeyUp(KeyEventArgs e);
		public abstract void KeyDown(KeyEventArgs e);
		public abstract void MouseDown(MouseEventArgs e);
	}
}
