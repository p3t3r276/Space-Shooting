using SpaceShooting.HUD;
using SpaceShooting.Manager;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.GameStates
{
	public class GameFinishState : GameState
	{
		Label[] lbls;

		public GameFinishState(GameStateManager gsm, Handler handler) : base(gsm, handler)
		{
			lbls = new Label[3];
			Font fnt = new Font("Arial", 55f, FontStyle.Bold, GraphicsUnit.Pixel);
			int top = 250;

			lbls[0] = new Label()
			{
				Text = "CONGRATULATIONS!!!",
				Top = top - 100
			};

			lbls[1] = new Label()
			{
				Text = "Play Again",
				Top = top
			};

			lbls[2] = new Label()
			{
				Text = "Main Menu",
				Top = lbls[1].Top + 100
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
				Hud.AMMO = 100;
				Hud.COINS = 0;
				Hud.HEALTH = 10;
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
