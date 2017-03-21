using SpaceShooting.Manager;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting
{
	public partial class Game : Form
	{
		private GameStateManager _gsm;
		private Graphics _g;
		private Timer _timer;
		private WindowManager _window;
		private Handler _handler;


		public static int WIDTH = 800;
		public static int HEIGHT = 600;
		public static Point mousePositionRelativeToForm;
		public const float RadToDeg = 180f / (float)Math.PI;
		public static Game mainForm;

		public Game()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			GameInit();

			if (_window.FullScreen == true)
			{
				WIDTH = Width;
				HEIGHT = Height;
			}
		}

		private void Game_Update(object sender, EventArgs e)
		{
			_gsm.Update();
			Invalidate();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			_g = e.Graphics;
			_gsm.Render(_g);
		}

		private void GameInit()
		{
			mainForm = this;
			_timer = new Timer
			{
				Interval = 20,
				Enabled = true
			};
			_timer.Tick += new EventHandler(Game_Update);

			_handler = new Handler();
			_gsm = new GameStateManager(_handler);

			_window = new WindowManager(WIDTH, HEIGHT, "Space Shooting Game", Color.Black, this, false);
		}

		private void Game_KeyDown(object sender, KeyEventArgs e)
		{
			_gsm.KeyDown(e);
		}

		private void Game_MouseMove(object sender, MouseEventArgs e)
		{
			mousePositionRelativeToForm = PointToClient(Cursor.Position);
		}

		private void Game_KeyUp(object sender, KeyEventArgs e)
		{
			_gsm.KeyUp(e);
		}

		public static float Clamp(float value, float min, float max)
		{
			if (value >= max)
			{
				return value = max;
			}
			else if (value <= min)
			{
				return value = min;
			}
			else
			{
				return value;
			}
		}

		private void Game_MouseDown(object sender, MouseEventArgs e)
		{
			_gsm.MouseDown(e);
		}

		private void Game_MouseUp(object sender, MouseEventArgs e)
		{
			_gsm.MouseUp(e);
		}
	}
}
