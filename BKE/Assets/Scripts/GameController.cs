using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BKE
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        private Grid grid;
        
        private void Start()
        {
            grid = new Grid(3, 3);
        }

        private void OnFire(InputValue value)
        {
            Vector2 mousePosition = new Vector2(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue());
            Vector2Int gridSize = grid.GetSize();
            int xAxis = DetermineAxisIndex(Screen.width, mousePosition.x, gridSize.x);
            int yAxis = DetermineAxisIndex(Screen.height, mousePosition.y, gridSize.y);
            AddBlock(new Vector2Int(xAxis, yAxis));
        }

        private int DetermineAxisIndex(float screenSize, float coordinate, int gridSize)
        {
            if (coordinate < screenSize / gridSize)
            {
                return 0;
            }
            if (coordinate > screenSize / gridSize * 2)
            {
                return 2;
            }
            return 1;
        }

        public void AddBlock(Vector2Int coordinates)
        {
            if (grid.PossibleMove(coordinates.x, coordinates.y))
            {
                grid.SetElement(coordinates.x, coordinates.y, -1);
                GameObject block = GameObject.Instantiate(prefab);
                float newX = block.transform.position.x + 4 * coordinates.x;
                float newY = block.transform.position.y + 4 * coordinates.y;
                block.transform.position = new Vector3(newX, newY, block.transform.position.z);
            }
        }
    }
}