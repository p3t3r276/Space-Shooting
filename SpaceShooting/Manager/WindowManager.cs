using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.Manager
{
	public class WindowManager
	{
		private Form _form;
		private bool _fullscreen = false;

		public WindowManager(float width, float height, string title, Color color, Form form, bool fullscreen)
		{
			_fullscreen = fullscreen;
			_form = form;
			_form.Text = title;
			_form.ClientSize = new Size((int)width, (int)height);
			_form.Location = new Point()
			{
				X = (Screen.PrimaryScreen.Bounds.Width - _form.Width) / 2,
				Y = (Screen.PrimaryScreen.Bounds.Height - _form.Height) / 2
			};
			_form.BackColor = color;
			_form.ShowIcon = false;
			if (_fullscreen == true)
			{
				_form.FormBorderStyle = FormBorderStyle.None;
				_form.TopMost = true;
				_form.Bounds = Screen.PrimaryScreen.Bounds;
			}
		}

		public bool FullScreen
		{
			get { return _fullscreen; }
		}

		~WindowManager()
		{
			_form.Dispose();
		}
	}
}
