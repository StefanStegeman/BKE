using UnityEngine;

namespace BKE
{
    public class PausedState : State
    {
        public PausedState(CanvasManager canvasManager) : base(canvasManager){}

        public override void Enter()
        {
            base.Enter();
            canvasManager.SwitchUIElement(UIType.Paused);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override string ToString()
        {
            return "Paused";
        }
    }
}