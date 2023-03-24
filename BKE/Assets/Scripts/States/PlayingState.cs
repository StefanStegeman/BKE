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

        // This does not work anymore.
        // Unity can't send messages to Non GameObjects. This will have to be done in a different way.
        // public void OnFire(InputValue value)
        // {
        //     Debug.Log("VUUR!");
        //     Vector2 mousePosition = new Vector2(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue());
        //     Vector2Int gridSize = manager.grid.GetSize();
        //     int xAxis = manager.DetermineAxisIndex(Screen.width, mousePosition.x, gridSize.x);
        //     int yAxis = manager.DetermineAxisIndex(Screen.height, mousePosition.y, gridSize.y);
        //     Vector2Int coordinates = new Vector2Int(xAxis, yAxis);
            
        //     if (manager.grid.PossibleMove(coordinates.x, coordinates.y))
        //     {
        //         manager.ApplyMove(coordinates, currentPlayer);
        //     }
        // }
    }
}