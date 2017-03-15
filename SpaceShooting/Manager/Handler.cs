using System.Collections.Generic;

namespace SpaceShooting.Manager
{
	public class Handler
	{
		public List<Entity.Entity> entitiesList = new List<Entity.Entity>();

		public Handler()
		{
		}

		public void Add(Entity.Entity e)
		{
			entitiesList.Add(e);
		}

		public void Remove(Entity.Entity e)
		{
			entitiesList.Remove(e);
		}

		public void Clear() => entitiesList.Clear();
	}
}
