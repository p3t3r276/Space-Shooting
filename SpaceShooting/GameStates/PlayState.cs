using SpaceShooting.Entity;
using SpaceShooting.Manager;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.GameStates
{
	public class PlayState : GameState
	{
		private Spawner _spawner1;
		private HUD.Hud hud;

		public PlayState(GameStateManager gsm, Handler handler) : base(gsm, handler)
		{
			_handler.entitiesList.Add(new Player((Game.WIDTH - 16) / 2, (Game.HEIGHT - 16) / 2, _handler));

			_spawner1 = new Spawner(100, 32, _handler);

			hud = new HUD.Hud(_handler);
		}

		public override void Update()
		{
			base.Update();

			_spawner1.Update();
			hud.Update();
		}

		public override void Render(Graphics g)
		{
			base.Render(g);
			hud.Render(g);
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
			if (e.KeyCode == Keys.Escape)
			{
				_handler.entitiesList.Clear();
				_gsm.SetState(GameStateManager.MENU);
			}

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
