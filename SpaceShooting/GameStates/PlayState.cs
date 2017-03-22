using SpaceShooting.Entity;
using SpaceShooting.HUD;
using SpaceShooting.Manager;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.GameStates
{
	public class PlayState : GameState
	{
		private Spawner _spawner;
		private Hud _hud;
		private SpawnPoint[] _spawnPoints;

		public PlayState(GameStateManager gsm, Handler handler) : base(gsm, handler)
		{
			_handler.entitiesList.Add(new Player((Game.WIDTH - 16) / 2, (Game.HEIGHT - 16) / 2, _handler));

			_hud = new Hud();

			_spawnPoints = new SpawnPoint[3];

			_spawnPoints[0] = new SpawnPoint(10, 10);
			_spawnPoints[1] = new SpawnPoint(Game.WIDTH, Game.HEIGHT);
			_spawnPoints[2] = new SpawnPoint(Game.WIDTH / 2, Game.HEIGHT);

			_spawner = new Spawner(_handler, _spawnPoints);
		}

		public override void Update()
		{
			base.Update();

			_spawner.Update();
			_hud.Update();

			CheckGameOver();
			CheckGameFinish();
		}

		public override void Render(Graphics g)
		{
			base.Render(g);
			_hud.Render(g);
		}

		public override void KeyUp(KeyEventArgs e)
		{
			for (int i = 0; i < _handler.entitiesList.Count; i++)
			{
				Player tempObject = _handler.entitiesList[i] as Player;
				if (tempObject != null)
				{
					switch (e.KeyCode)
					{
						case Keys.W:
							tempObject.Up = false;
							break;
						case Keys.S:
							tempObject.Down = false;
							break;
						case Keys.A:
							tempObject.Left = false;
							break;
						case Keys.D:
							tempObject.Right = false;
							break;
					}
				}
			}
		}

		public override void KeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				_gsm.Paused = true;
			}

			for (int i = 0; i < _handler.entitiesList.Count; i++)
			{
				Player tempObject = _handler.entitiesList[i] as Player;
				if (tempObject != null)
				{
					switch (e.KeyCode)
					{
						case Keys.W:
							tempObject.Up = true;
							break;
						case Keys.S:
							tempObject.Down = true;
							break;
						case Keys.A:
							tempObject.Left = true;
							break;
						case Keys.D:
							tempObject.Right = true;
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
					Player tempObject = _handler.entitiesList[i] as Player;
					if (tempObject != null)
					{
						tempObject.Firing = true;
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
					Player tempObject = _handler.entitiesList[i] as Player;
					if (tempObject is Player)
					{
						tempObject.Firing = false;
					}
				}
			}
		}

		public void CheckGameOver()
		{
			if (Hud.HEALTH <= 0)
			{
				_handler.entitiesList.Clear();
				_gsm.SetState(GameStateManager.GAMEOVER);
			}
		}

		public void CheckGameFinish()
		{
			if (_spawner.AllWaveCompleted)
			{
				_handler.entitiesList.Clear();
				_gsm.SetState(GameStateManager.GAMEFINISH);
			}
		}
	}
}
