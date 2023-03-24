using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace BKE
{
    public class GridManager : MonoBehaviour//, IPointerDownHandler
    {
        #region Shape properties
        [SerializeField] 
        private GameObject playerOne;
        [SerializeField] 
        private GameObject playerTwo;

        private Mesh meshOne;
        private Mesh meshTwo;
        private Material materialOne;
        private Material materialTwo;
        #endregion

        #region Grid
        [SerializeField]
        private Vector2Int size;
        [SerializeField]
        private List<ShapeHolder> shapeHolders;

        private Grid grid;
        #endregion

        private int currentPlayer;

        private void Start()
        {
            grid = new Grid(size.x, size.y);
            currentPlayer = 1;
            InitializeShapeProperties();
        }

        private void InitializeShapeProperties()
        {
            meshOne = playerOne.GetComponent<MeshFilter>().sharedMesh;
            materialOne = playerOne.GetComponent<Renderer>().sharedMaterial;
            meshTwo = playerTwo.GetComponent<MeshFilter>().sharedMesh;
            materialTwo = playerTwo.GetComponent<Renderer>().sharedMaterial;
        }

        private int CoordinatesToIndex(Vector2Int coordinates)
        {
            return grid.GetSize().x * coordinates.x + coordinates.y;
        }

        private void ChangeShapeProperties(Vector2Int coordinates)
        {
            if (currentPlayer == 1)
            {
                shapeHolders[CoordinatesToIndex(coordinates)].SwapMesh(meshOne);
                shapeHolders[CoordinatesToIndex(coordinates)].SwapMaterial(materialOne);
            }
            else
            {
                shapeHolders[CoordinatesToIndex(coordinates)].SwapMesh(meshTwo);
                shapeHolders[CoordinatesToIndex(coordinates)].SwapMaterial(materialTwo);
            }
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

        private void CheckWin()
        {
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

        public void ApplyMove(Vector2Int coordinates)
        {
            if (grid.PossibleMove(coordinates))
            {
                grid.SetElement(coordinates.x, coordinates.y, currentPlayer);
                ChangeShapeProperties(coordinates);
                CheckWin();
            }
        }

        public void ResetGrid()
        {
            grid = new Grid(size.x, size.y);
            shapeHolders.ForEach(holder => holder.gameObject.GetComponent<MeshFilter>().sharedMesh = null);
            currentPlayer = 1; // Might be nice to add a rule to where the loser may start the next game
        }
    }
}