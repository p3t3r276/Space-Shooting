using SpaceShooting.Manager;

namespace SpaceShooting.Entity
{
	public abstract class Enemy : Entity
	{
		public Enemy(float x, float y, Handler handler) : base(x, y, handler)
		{
		}
	}
}
