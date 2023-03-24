using UnityEngine;

namespace BKE
{
    public class GameOverState : State
    {
        private GridManager gridManager;

        public GameOverState(GridManager gridManager, CanvasManager canvasManager) : base(canvasManager)
        {
            this.gridManager = gridManager;
        }

        /// <summary>
        /// Switches the UIElement to the proper UIType on entering the state.
        /// </summary>
        public override void Enter()
        {
            base.Enter();
            canvasManager.SwitchUIElement(UIType.GameOver);
        }

        /// <summary>
        /// Resets the grid on exiting the state.
        /// </summary>
        public override void Exit()
        {
            base.Exit();
            gridManager.ResetGrid();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            return "Game Over";
        }
    }
}