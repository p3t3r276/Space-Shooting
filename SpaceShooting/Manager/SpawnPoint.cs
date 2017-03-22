namespace SpaceShooting.Manager
{
	public class SpawnPoint
	{
		private float _x;
		private float _y;

		public SpawnPoint(float x, float y)
		{
			_x = x;
			_y = y;
		}

		public float X
		{
			get { return _x; }
		}

		public float Y
		{
			get { return _y; }
		}
	}
}
