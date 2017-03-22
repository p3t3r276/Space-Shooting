using SpaceShooting.HUD;
using SpaceShooting.Manager;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.GameStates
{
	class GameOverState : GameState
	{
		Label[] lbls;

		public GameOverState(GameStateManager gsm, Handler handler) : base(gsm, handler)
		{
			lbls = new Label[3];
			Font fnt = new Font("Arial", 50f, FontStyle.Bold, GraphicsUnit.Pixel);

			lbls[0] = new Label()
			{
				Text = "OOPS! YOU LOST",
				Top = 100
			};

			lbls[1] = new Label()
			{
				Text = "Play Again",
				Top = lbls[0].Top + 200
			};

			lbls[2] = new Label()
			{
				Text = "Main Menu",
				Top = lbls[1].Top + 150
			};

			foreach (Label lbl in lbls)
			{
				lbl.ForeColor = Color.White;
				lbl.BackColor = Color.Transparent;
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
				Hud.Reset();
				_gsm.SetState(GameStateManager.PLAY);
			}
			else if (tempLabel == lbls[2])
			{
				Game.mainForm.Controls.Clear();
				_gsm.SetState(GameStateManager.MENU);
			}
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
