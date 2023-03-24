using UnityEngine;

namespace BKE
{
    public class GameManager : MonoBehaviour
    {
        #region GameStates
        private State currentState;
        private IdleState idleState;
        private PlayingState playingState;
        private PausedState pausedState;
        private GameOverState gameOverState;
        #endregion

        #region Managers
        [SerializeField]
        private GridManager gridManager;
        [SerializeField]
        private CanvasManager canvasManager;
        #endregion

        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            Instance = this;
        }

        private void Start()
        {
            idleState = new IdleState(gridManager, canvasManager);
            playingState = new PlayingState(gridManager, canvasManager);
            pausedState = new PausedState(canvasManager);
            gameOverState = new GameOverState(gridManager, canvasManager);
            ChangeState(idleState);
        }

        private void Update()
        {
            currentState.Update();
        }

        /// <summary>
        /// Changes the current GameState.
        /// </summary>
        public void ChangeState(State state)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }
            currentState = state;
            state.Enter();
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            ChangeState(playingState);
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        public void PauseGame()
        {
            ChangeState(pausedState);
        }

        /// <summary>
        /// Terminates the game.
        /// </summary>
        public void QuitGame()
        {
            ChangeState(idleState);
        }

        /// <summary>
        /// Handles the game over state.
        /// </summary>
        public void GameOver()
        {
            ChangeState(gameOverState);
        }
    }
}