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
		public static Vector2 mousePositionRelativeToForm;
		public const float Rad2Deg = 180f / (float)Math.PI;

		public Game()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Game_Init();
		}

		private void Game_Update(object sender, EventArgs e)
		{
			Invalidate();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			g = e.Graphics;
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
		}

		private void Game_MouseMove(object sender, MouseEventArgs e)
		{
			mousePositionRelativeToForm = PointToClient(Cursor.Position);
		}
	}
}
