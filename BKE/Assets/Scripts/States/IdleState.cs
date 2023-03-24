using UnityEngine;

namespace BKE
{
    public class IdleState : State
    {
        private GridManager manager;

        public IdleState(GridManager manager) : base()
        {
            this.manager = manager;
        } 

        public override void Enter()
        {
            base.Enter();
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