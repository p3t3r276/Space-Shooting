using SpaceShooting.Manager;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.GameState
{
	public class MenuState : GameState
	{
		Label lbl;

		public MenuState(GameStateManager gsm, Handler handler) : base(gsm, handler)
		{
			lbl = new Label()
			{
				Text = "Hello",
				Size = new Size(100, 150),
				ForeColor = Color.White,
				Left = 100,
				Top = 150,
				Font = new Font("Arial", 20, FontStyle.Bold)
			};
		}

		public override void Render(Graphics g)
		{
			base.Render(g);

			Game.mainForm.Controls.Add(lbl);
		}

		public override void KeyDown(KeyEventArgs e)
		{
		}

		public override void KeyUp(KeyEventArgs e)
		{
		}

		public override void MouseDown(MouseEventArgs e)
		{
		}

		public override void MouseUp(MouseEventArgs e)
		{
		}
	}
}
