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

        public override void Enter()
        {
            base.Enter();
            gridManager.enabled = true;
            canvasManager.SwitchUIElement(UIType.Playing);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Exit()
        {
            base.Exit();
            gridManager.enabled = false;
        }

        public override string ToString()
        {
            return "Playing";
        }
    }
}