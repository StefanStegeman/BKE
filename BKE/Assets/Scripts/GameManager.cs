using UnityEngine;

namespace BKE
{
    public class GameManager : MonoBehaviour
    {
        #region GameStates
        private State currentState;
        private IdleState idleState;
        private PlayingState playingState;
        #endregion

        [SerializeField]
        private GridManager gridManager;

        private void Start()
        {
            idleState = new IdleState(gridManager);
            playingState = new PlayingState(gridManager);
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
    }
}