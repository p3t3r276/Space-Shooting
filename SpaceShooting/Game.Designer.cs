namespace SpaceShooting
{
	partial class Game
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 260);
			this.Name = "Game";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Game_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Game_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Game_MouseUp);
			this.ResumeLayout(false);

		}

		#endregion
	}
}

