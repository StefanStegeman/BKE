using UnityEngine;

namespace BKE
{
    public class IdleState : State
    {
        public IdleState(CanvasManager canvasManager) : base(canvasManager){}

        public override void Enter()
        {
            base.Enter();
            canvasManager.SwitchUIElement(UIType.Idle);
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
            return "Idle";
        }
    }
}