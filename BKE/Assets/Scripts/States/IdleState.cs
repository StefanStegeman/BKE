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

        public override void Enter()
        {
            base.Enter();
            gridManager.ResetGrid();
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