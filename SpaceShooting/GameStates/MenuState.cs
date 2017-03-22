using SpaceShooting.Manager;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.GameStates
{
	public class MenuState : GameState
	{
		Label[] lbls;
		Font fnt;

		public MenuState(GameStateManager gsm, Handler handler) : base(gsm, handler)
		{
			lbls = new Label[3];
			Color color = Color.White;
			fnt = new Font("Arial", 55f, FontStyle.Bold, GraphicsUnit.Pixel);
			int top = 300;

			lbls[0] = new Label()
			{
				Text = "SPACE SHOOTING",
				Top = top - 150
			};

			lbls[1] = new Label()
			{
				Text = "PLAY",
				Top = top
			};

			lbls[2] = new Label()
			{
				Text = "QUIT",
				Top = top + 100
			};

			foreach (Label lbl in lbls)
			{
				lbl.ForeColor = color;
				lbl.Font = fnt;
				lbl.TextAlign = ContentAlignment.MiddleCenter;
				lbl.Size = new Size(Game.WIDTH, Game.HEIGHT / 9);
				lbl.Left = (Game.WIDTH - lbl.Size.Width) / 2;
				lbl.Click += Click;
				Game.mainForm.Controls.Add(lbl);
			}
		}

		private void Click(object sender, EventArgs e)
		{
			Label tempLabel = sender as Label;
			if (tempLabel == lbls[1])
			{
				Game.mainForm.Controls.Clear();
				_gsm.SetState(GameStateManager.PLAY);
			}
			else if (tempLabel == lbls[2])
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
