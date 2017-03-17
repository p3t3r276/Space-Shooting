using SpaceShooting.Entity;
using SpaceShooting.Manager;
using System.Windows.Forms;

namespace SpaceShooting.GameState
{
	public class PlayState : GameState
	{
		public PlayState(GameStateManager gsm, Handler handler) : base(gsm, handler)
		{
			_handler.entitiesList.Add(new Player((Game.WIDTH - 16) / 2, (Game.HEIGHT - 16) / 2, _handler));
			_handler.entitiesList.Add(new SmartEnemy(100, 100, _handler));
		}

		public override void KeyUp(KeyEventArgs e)
		{
			for (int i = 0; i < _handler.entitiesList.Count; i++)
			{
				Entity.Entity player = _handler.entitiesList[i];
				if (player is Player)
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
			}
		}

		public override void KeyDown(KeyEventArgs e)
		{
			for (int i = 0; i < _handler.entitiesList.Count; i++)
			{
				Entity.Entity player = _handler.entitiesList[i];
				if (player is Player)
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
			}
		}

		public override void MouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				for (int i = 0; i < _handler.entitiesList.Count; i++)
				{
					Entity.Entity temp = _handler.entitiesList[i];
					if (temp is Player)
					{
						temp.Firing = true;
					}
				}
			}
		}

		public override void MouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				for (int i = 0; i < _handler.entitiesList.Count; i++)
				{
					Entity.Entity temp = _handler.entitiesList[i];
					if (temp is Player)
					{
						temp.Firing = false;
					}
				}
			}
		}
	}
}
