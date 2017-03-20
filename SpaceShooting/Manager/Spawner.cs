using SpaceShooting.Entity;
using System;

namespace SpaceShooting.Manager
{
	public class Spawner
	{
		private int waveStartTimer;
		private int waveStartTimerDiff;
		private int waveNumber;
		private int waveDelay = 1500;
		private bool waveStart;
		private int _enemyCount;

		private Handler _handler;
		private float _x;
		private float _y;

		private Random _rand = new Random();

		public Spawner(float x, float y, Handler handler)
		{
			_handler = handler;
			_x = x;
			_y = y;

			waveStartTimer = 0;
			waveStartTimerDiff = 0;
			waveStart = true;
			waveNumber = 0;

			_enemyCount = 0;
		}

		public void Update()
		{
			//Refresh counter
			_enemyCount = 0;

			//count enemy on the screen
			for (int i = 0; i < _handler.entitiesList.Count; i++)
			{
				Enemy temp = _handler.entitiesList[i] as Enemy;
				if (temp != null)
				{
					_enemyCount++;
				}
			}

			if (waveStartTimer == 0 && _enemyCount == 0)
			{
				waveNumber++;
				waveStart = false;
				waveStartTimer = Environment.TickCount;
			}
			else
			{
				waveStartTimerDiff = (Environment.TickCount - waveStartTimer);
				if (waveStartTimerDiff > waveDelay)
				{
					waveStart = true;
					waveStartTimer = 0;
					waveStartTimerDiff = 0;
				}
			}

			if (waveStart && _enemyCount == 0)
			{
				CreateNewEnemies();
			}
		}

		private void CreateNewEnemies()
		{
			//if (waveNumber == 1)
			//{
			//	_handler.entitiesList.Add(new BasicEnemy(_x, _y, _handler, _rand));
			//	_handler.entitiesList.Add(new BasicEnemy(_x, _y, _handler, _rand));
			//}

			//if (waveNumber == 2)
			//{
			//	_handler.entitiesList.Add(new BasicEnemy(_x, _y, _handler, _rand));
			//	_handler.entitiesList.Add(new BasicEnemy(_x, _y, _handler, _rand));
			//	_handler.entitiesList.Add(new BasicEnemy(_x, _y, _handler, _rand));
			//	_handler.entitiesList.Add(new BasicEnemy(_x, _y, _handler, _rand));
			//}

			//if (waveNumber == 3)
			//{
			//	_handler.entitiesList.Add(new BasicEnemy(_x, _y, _handler, _rand));
			//	_handler.entitiesList.Add(new SmartEnemy(_x, _y, _handler));
			//}

			if (waveNumber == 1)
			{
				_handler.entitiesList.Add(new SmartEnemy(_x, _y, _handler));
			}
		}
	}
}
