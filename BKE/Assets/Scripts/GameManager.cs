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
        #endregion

        #region Managers
        [SerializeField]
        private GridManager gridManager;
        [SerializeField]
        private CanvasManager canvasManager;
        #endregion

        private void Start()
        {
            idleState = new IdleState(canvasManager);
            playingState = new PlayingState(gridManager, canvasManager);
            pausedState = new PausedState(canvasManager);
            ChangeState(idleState);
        }

        public void ChangeState(State state)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }
            currentState = state;
            state.Enter();
        }

        public void StartGame()
        {
            ChangeState(playingState);
        }

        public void PauseGame()
        {
            ChangeState(pausedState);
        }

        public void QuitGame()
        {
            ChangeState(idleState);
        }
    }
}