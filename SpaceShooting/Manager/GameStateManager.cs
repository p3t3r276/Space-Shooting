using SpaceShooting.GameState;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.Manager
{
	public class GameStateManager
	{
		private GameState.GameState[] gameStates;
		private int currentState;
		private int previousState;
		private Handler _handler;

		public const int NUM_STATES = 4;
		public const int INTRO = 0;
		public const int MENU = 1;
		public const int PLAY = 2;
		public const int GAMEOVER = 3;

		public GameStateManager(Handler handler)
		{
			_handler = new Handler();
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
				gameStates[i] = new PlayState(this, _handler);
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

		public void KeyUp(KeyEventArgs e)
		{
			if (gameStates[currentState] != null)
			{
				gameStates[currentState].KeyUp(e);
			}
		}

		public void KeyDown(KeyEventArgs e)
		{
			if (gameStates[currentState] != null)
			{
				gameStates[currentState].KeyDown(e);
			}
		}

		public void Render(Graphics g)
		{
			if (gameStates[currentState] != null)
			{
				gameStates[currentState].Render(g);
			}
		}

		public void MouseDown(MouseEventArgs e)
		{
			if (gameStates[currentState] != null)
			{
				gameStates[currentState].MouseDown(e);
			}
		}

		public void MouseUp(MouseEventArgs e)
		{
			if (gameStates[currentState] != null)
			{
				gameStates[currentState].MouseUp(e);
			}
		}
	}
}
