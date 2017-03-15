using SpaceShooting.Manager;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting
{
	public partial class Game : Form
	{
		private GameStateManager gsm;
		Graphics g;
		Timer timer;
		WindowManager window;

		public static int WIDTH = 800;
		public static int HEIGHT = 600;
		public static Point mousePositionRelativeToForm;
		public const float Rad2Deg = 180f / (float)Math.PI;

		public Game()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Game_Init();
			if (window.FullScreen == true)
			{
				WIDTH = Width;
				HEIGHT = Height;
			}
		}

		private void Game_Update(object sender, EventArgs e)
		{
			gsm.Update();
			Invalidate();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			g = e.Graphics;
			gsm.Render(g);
		}

		private void Game_Init()
		{
			timer = new Timer
			{
				Interval = 20,
				Enabled = true
			};
			timer.Tick += new EventHandler(Game_Update);

			gsm = new GameStateManager();

			window = new WindowManager(WIDTH, HEIGHT, "Space Shooting Game", Color.Black, this, false);
		}

		private void Game_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape: Application.Exit(); break;
			}

			gsm.KeyDown(e);
		}

		private void Game_MouseMove(object sender, MouseEventArgs e)
		{
			mousePositionRelativeToForm = PointToClient(Cursor.Position);
		}

		private void Game_KeyUp(object sender, KeyEventArgs e)
		{
			gsm.KeyUp(e);
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
	}
}
