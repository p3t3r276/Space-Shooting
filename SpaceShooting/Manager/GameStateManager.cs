using SpaceShooting.GameState;
using System.Drawing;

namespace SpaceShooting.Manager
{
	public class GameStateManager
	{
		private GameState.GameState[] gameStates;
		private int currentState;
		private int previousState;

		public const int NUM_STATES = 4;
		public const int INTRO = 0;
		public const int MENU = 1;
		public const int PLAY = 2;
		public const int GAMEOVER = 3;

		public GameStateManager()
		{
			gameStates = new GameState.GameState[NUM_STATES];
			SetState(PLAY);

		}

		public void SetState(int i)
		{
			previousState = currentState;
			UnloadState(previousState);
			currentState = i;

			if (i == INTRO)
			{
			}
			else if (i == MENU)
			{
			}
			else if (i == PLAY)
			{
				gameStates[i] = new PlayState(this);
			}
			else if (i == GAMEOVER)
			{
			}
		}

		public void UnloadState(int i)
		{
			gameStates[i] = null;
		}

		public void Update()
		{
			if (gameStates[currentState] != null)
			{
				gameStates[currentState].Update();
			}
		}

		public void Draw(Graphics g)
		{
			if (gameStates[currentState] != null)
			{
				gameStates[currentState].Render(g);
			}
		}
	}
}
