using UnityEngine;
using UnityEngine.InputSystem;

namespace BKE
{
    public class PlayingState : State
    {
        private int currentPlayer;
        private GridManager gridManager;

        public PlayingState(GridManager gridManager, CanvasManager canvasManager) : base(canvasManager)
        {
            this.gridManager = gridManager;
            currentPlayer = 1;
        } 

        /// <summary>
        /// Enables the gridManager script, and switches to the proper UIType on entering the state.
        /// </summary>
        public override void Enter()
        {
            base.Enter();
            gridManager.enabled = true;
            canvasManager.SwitchUIElement(UIType.Playing);
        }

        /// <summary>
        /// Disables the gridManager script on exiting the state.
        /// </summary>
        public override void Exit()
        {
            base.Exit();
            gridManager.enabled = false;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            return "Playing";
        }
    }
}