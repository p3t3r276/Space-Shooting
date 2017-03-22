using SpaceShooting.GameStates;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceShooting.Manager
{
	public class GameStateManager
	{
		private GameState[] gameStates;
		private int currentState;
		private int previousState;
		private Handler _handler;

		public const int NUM_STATES = 5;
		public const int MENU = 0;
		public const int PLAY = 1;
		public const int GAMEOVER = 2;
		public const int GAMEFINISH = 3;
		public const int INSTRUCTION = 4;

		private bool paused;
		private PauseState pauseState;

		public GameStateManager(Handler handler)
		{
			_handler = new Handler();

			paused = false;
			pauseState = new PauseState(this, _handler);


			gameStates = new GameState[NUM_STATES];
			SetState(MENU);
		}

		public void SetState(int i)
		{
			previousState = currentState;
			UnloadState(previousState);
			currentState = i;

			if (i == MENU)
			{
				gameStates[i] = new MenuState(this, _handler);
			}
			else if (i == PLAY)
			{
				gameStates[i] = new PlayState(this, _handler);
			}
			else if (i == GAMEOVER)
			{
				gameStates[i] = new GameOverState(this, _handler);
			}
			else if (i == GAMEFINISH)
			{
				gameStates[i] = new GameFinishState(this, _handler);
			}
			else if (i == INSTRUCTION)
			{
				gameStates[i] = new InstructionState(this, _handler);
			}
		}

		public void UnloadState(int i)
		{
			gameStates[i] = null;
		}

		public void Update()
		{
			if (paused)
			{
				pauseState.Update();
			}
			else if (gameStates[currentState] != null)
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
			if (paused)
			{
				pauseState.KeyDown(e);
			}
			else if (gameStates[currentState] != null)
			{
				gameStates[currentState].KeyDown(e);
			}
		}

		public void Render(Graphics g)
		{
			if (paused)
			{
				pauseState.Render(g);
			}
			else if (gameStates[currentState] != null)
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

		public bool Paused
		{
			get { return paused; }
			set { paused = value; }
		}
	}
}
