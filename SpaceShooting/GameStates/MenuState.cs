using SpaceShooting.Manager;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.GameStates
{
	public class MenuState : GameState
	{
		Label lbl;

		public MenuState(GameStateManager gsm, Handler handler) : base(gsm, handler)
		{
			lbl = new Label()
			{
				Text = "Hello",
				ForeColor = Color.White,
				Size = new Size(100, 100),
				Font = new Font("Arial", 20f, FontStyle.Bold, GraphicsUnit.Pixel),
				Left = 50,
				Top = 50
			};

			Game.mainForm.Controls.Add(lbl);
		}

		public override void Render(Graphics g)
		{
			base.Render(g);
		}

		public override void KeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Game.mainForm.Controls.Clear();
				_gsm.SetState(GameStateManager.PLAY);
			}
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
