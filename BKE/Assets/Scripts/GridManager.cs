using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace BKE
{
    public class GridManager : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] 
        private GameObject playerOne;

        [SerializeField] 
        private GameObject playerTwo;

        [SerializeField]
        private GameObject objectsParent;

        [SerializeField]
        private Vector2Int size;

        private int currentPlayer;

        public Grid grid;

        private void Start()
        {
            grid = new Grid(size.x, size.y);
            currentPlayer = 1;
        }

        public void ApplyMove(Vector2Int coordinates, int player)
        {
            grid.SetElement(coordinates.x, coordinates.y, player);
            InstantiateShape(coordinates, player);
        }

        private GameObject SelectShape()
        {
            return currentPlayer == 1? GameObject.Instantiate(playerOne) : GameObject.Instantiate(playerTwo);
        }

        private void SwitchPlayer()
        {
            if (currentPlayer == 1)
            {
                currentPlayer = 2;
            }
            else
            {
                currentPlayer = 1;
            }
        }

        private void InstantiateShape(Vector2Int coordinates, int player)
        {
            GameObject block = SelectShape();
            float newX = block.transform.position.x + 4 * coordinates.x;
            float newY = block.transform.position.y + 4 * coordinates.y;
            block.transform.SetParent(objectsParent.GetComponent<Transform>());
            block.transform.position = new Vector3(newX, newY, block.transform.position.z);
        }

        public int DetermineAxisIndex(float screenSize, float coordinate, int gridSize)
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

        public void OnPointerDown(PointerEventData eventData)
        {
            Vector2 mousePosition = new Vector2(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue());
            Vector2Int gridSize = grid.GetSize();
            int xAxis = DetermineAxisIndex(Screen.width, mousePosition.x, gridSize.x);
            int yAxis = DetermineAxisIndex(Screen.height, mousePosition.y, gridSize.y);
            Vector2Int coordinates = new Vector2Int(xAxis, yAxis);
            
            if (grid.PossibleMove(coordinates.x, coordinates.y))
            {
                ApplyMove(coordinates, currentPlayer);
                if (grid.CheckWin())
                {
                    Debug.Log(string.Format("Player {0} has won!", currentPlayer));
                    ResetGrid();
                }
                else
                {
                    SwitchPlayer();
                }
            }
        }

        public void ResetGrid()
        {
            grid = new Grid(size.x, size.y);
            foreach (Transform child in objectsParent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            // Might be nice to add a rule to where the loser may start the next game
            currentPlayer = 1;
        }
    }
}