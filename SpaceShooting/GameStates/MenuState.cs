using SpaceShooting.Manager;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.GameStates
{
	public class MenuState : GameState
	{
		Label[] lbls;

		public MenuState(GameStateManager gsm, Handler handler) : base(gsm, handler)
		{
			lbls = new Label[2];
			Color color = Color.White;
			Font fnt = new Font("Arial", 25f, FontStyle.Bold, GraphicsUnit.Pixel);
			int top = 250;

			lbls[0] = new Label()
			{
				Text = "PLAY",
				Top = top
			};

			lbls[1] = new Label()
			{
				Text = "QUIT",
				Top = top + 100
			};

			foreach (Label lbl in lbls)
			{
				lbl.ForeColor = color;
				lbl.Font = fnt;
				lbl.Size = new Size(100, 100);
				lbl.Left = (Game.WIDTH - lbl.Size.Width) / 2;
				lbl.Click += Click;
				Game.mainForm.Controls.Add(lbl);
			}
		}

		private void Click(object sender, EventArgs e)
		{
			Label tempLabel = (Label)sender;
			if (tempLabel.Text == "PLAY")
			{
				Game.mainForm.Controls.Clear();
				_gsm.SetState(GameStateManager.PLAY);
			}
			else if (tempLabel.Text == "QUIT")
			{
				Application.Exit();
			}
		}

		public override void Render(Graphics g)
		{
			base.Render(g);
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
