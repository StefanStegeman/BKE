using UnityEngine;

namespace BKE
{
    public class IdleState : State
    {
        private GridManager gridManager;

        public IdleState(GridManager gridManager, CanvasManager canvasManager) : base(canvasManager)
        {
            this.gridManager = gridManager;
        }

        /// <summary>
        /// Switches the UIElement to the proper UIType, and resets the grid on entering the state.
        /// </summary>
        public override void Enter()
        {
            base.Enter();
            canvasManager.SwitchUIElement(UIType.MainMenu);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            return "Idle";
        }
    }
}