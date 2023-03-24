using UnityEngine;

namespace BKE
{
    public class PausedState : State
    {
        public PausedState(CanvasManager canvasManager) : base(canvasManager){}

        /// <summary>
        /// Switches the UIElement to the proper UIType on entering the state.
        /// </summary>
        public override void Enter()
        {
            base.Enter();
            canvasManager.SwitchUIElement(UIType.Paused);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            return "Paused";
        }
    }
}