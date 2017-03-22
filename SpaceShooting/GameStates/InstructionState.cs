using SpaceShooting.Manager;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.GameStates
{
	public class InstructionState : GameState
	{
		Label[] lbls;
		Font fnt, fnt2;

		public InstructionState(GameStateManager gsm, Handler handler) : base(gsm, handler)
		{
			lbls = new Label[3];
			fnt = new Font("Arial", 50f, FontStyle.Bold, GraphicsUnit.Pixel);
			fnt2 = new Font("Arial", 30f, FontStyle.Bold, GraphicsUnit.Pixel);

			lbls[0] = new Label()
			{
				Text = "INSTRUCTION",
				Top = 100
			};

			lbls[1] = new Label()
			{
				Text = "Use WASD to move around. \r\n\r\nUse Left Mouse button to shoot. You get COINS for each enemy killed. \r\n\r\nUse SpaceBar to access Store. Here, you can buy ammo and health using the COINS you have.",
				Top = lbls[0].Top + 100
			};

			lbls[2] = new Label()
			{
				Text = "BACK",
				Top = Game.HEIGHT - 100
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

			lbls[1].Font = fnt2;
			lbls[1].Height = Game.HEIGHT / 2;
			lbls[1].Width = 800;
			lbls[1].Left = (Game.WIDTH - 800) / 2;
			lbls[1].TextAlign = ContentAlignment.MiddleLeft;
		}

		private void Click(object sender, EventArgs e)
		{
			Label tempLabel = sender as Label;
			if (tempLabel == lbls[2])
			{
				Game.mainForm.Controls.Clear();
				_gsm.SetState(GameStateManager.MENU);
			}
		}

		public override void Render(Graphics g)
		{

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
