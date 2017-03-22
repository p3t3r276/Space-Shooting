using System.Collections.Generic;
using System.Drawing;

namespace SpaceShooting.Manager
{
	public class Handler
	{
		public List<Entity.Entity> entitiesList = new List<Entity.Entity>();

		public Handler()
		{
		}

		public void Render(Graphics g)
		{
			for (int i = 0; i < entitiesList.Count; i++)
			{
				Entity.Entity tempEntity = entitiesList[i];
				tempEntity.Render(g);
			}
		}

		public void Update()
		{
			for (int i = 0; i < entitiesList.Count; i++)
			{
				Entity.Entity tempEntity = entitiesList[i];
				tempEntity.Update();
			}
		}
	}
}
