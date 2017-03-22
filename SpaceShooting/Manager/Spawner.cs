using SpaceShooting.Entity;
using System;

namespace SpaceShooting.Manager
{
	public class Spawner
	{
		private Handler _handler;
		private Random _rand;

		Wave[] waves;

		Wave currentWave;
		int currentWaveNumber;

		private SpawnPoint[] _spawnPoints;

		private int enemiesRemainingToSpawn;
		private int enemiesRemainingAlive;
		private float nextSpawnTime;

		private bool _allWavesCompeleted;

		public Spawner(Handler handler, SpawnPoint[] spawnPoints)
		{
			_handler = handler;
			_spawnPoints = spawnPoints;

			_rand = new Random();

			_allWavesCompeleted = false;

			//define the waves
			waves = new Wave[2];
			waves[0] = new Wave()
			{
				enemyCount = 5,
				timeBetweenSpawn = 1
			};

			waves[1] = new Wave()
			{
				enemyCount = 10,
				timeBetweenSpawn = .75f
			};

			NextWave();
		}

		public void Update()
		{
			if (enemiesRemainingToSpawn >= 0 && Environment.TickCount > nextSpawnTime)
			{
				enemiesRemainingToSpawn--;
				nextSpawnTime = Environment.TickCount + currentWave.timeBetweenSpawn * 1000;

				//spawn enemy
				SpawnPoint spawnPoint = _spawnPoints[_rand.Next(0, _spawnPoints.Length)];
				_handler.entitiesList.Add(new Enemy(spawnPoint.X, spawnPoint.Y, _handler));
			}

			CountEnemyRemainingAlive();
			CheckAllWavesCompleted();

			if (enemiesRemainingAlive == 0 && !_allWavesCompeleted)
			{
				NextWave();
			}
		}

		private void NextWave()
		{
			currentWaveNumber++;
			if (currentWaveNumber - 1 < waves.Length)
			{
				currentWave = waves[currentWaveNumber - 1];

				enemiesRemainingToSpawn = currentWave.enemyCount - 1;
				enemiesRemainingAlive = enemiesRemainingToSpawn;
			}
		}

		//Kiểm tra số Enemy hiện có
		private int CountEnemyRemainingAlive()
		{
			//Reset bộ đếm
			enemiesRemainingAlive = 0;

			for (int i = 0; i < _handler.entitiesList.Count; i++)
			{
				Enemy temp = _handler.entitiesList[i] as Enemy;
				if (temp != null)
				{
					enemiesRemainingAlive++;
				}
			}
			return enemiesRemainingAlive;
		}

		public bool CheckAllWavesCompleted()
		{
			if (enemiesRemainingAlive == 0 && !_allWavesCompeleted && currentWaveNumber == waves.Length)
			{
				_allWavesCompeleted = true;
			}

			return _allWavesCompeleted;
		}

		public bool AllWaveCompleted
		{
			get { return _allWavesCompeleted; }
		}
	}
}
