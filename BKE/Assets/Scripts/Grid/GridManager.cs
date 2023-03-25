using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

namespace BKE
{
    public class GridManager : MonoBehaviour//, IPointerDownHandler
    {
        /////////////////
        public AgentTester tester;
        /////////////////

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

        #region UI
        [SerializeField]
        private TMP_Text playerText;
        [SerializeField]
        private TMP_Text resultText;
        #endregion

        private int currentPlayer;
        [SerializeField]
        private AudioClip selectAudio;
        [SerializeField]
        private AudioClip errorAudio;

        private Vector2Int previousMove;

        private void Start()
        {
            grid = new Grid(size.x, size.y);
            currentPlayer = 1;
            InitializeShapeProperties();
            tester.ShowGrid(grid);
            tester.ValidMoves(grid.GetValidMoves());
            playerText.text = "Player 1";
        }

        /// <summary>
        /// Initializing all shape properties.
        /// </summary>
        private void InitializeShapeProperties()
        {
            meshOne = playerOne.GetComponent<MeshFilter>().sharedMesh;
            materialOne = playerOne.GetComponent<Renderer>().sharedMaterial;
            meshTwo = playerTwo.GetComponent<MeshFilter>().sharedMesh;
            materialTwo = playerTwo.GetComponent<Renderer>().sharedMaterial;
        }

        /// <summary>
        /// Convert Vector2Int to int.
        /// This allows to access the shapeHolders which are ordered by coordinates.
        /// </summary>
        private int CoordinatesToIndex(Vector2Int coordinates)
        {
            return grid.GetSize().x * coordinates.x + coordinates.y;
        }

        /// <summary>
        /// Change the mesh and material of the shapeholder.
        /// </summary>
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
 
        /// <summary>
        /// Switch currentPlayer variable according to the player whom's turn it is.
        /// </summary>
        private void SwitchPlayer()
        {
            if (currentPlayer == 1)
            {
                currentPlayer = 2;
                tester.MakeMove(grid, previousMove);
            }
            else
            {
                currentPlayer = 1;
            }
            playerText.text = string.Format("Player {0}", currentPlayer);
        }

        /// <summary>
        /// Handle wins, non-wins and draws.
        /// </summary>
        private void CheckWin()
        {
            if (grid.CheckWin())
            {
                resultText.text = string.Format("Player {0} has won!", currentPlayer);
                tester.GameWinner(currentPlayer);
                GameManager.Instance.GameOver();
            }
            else if (grid.AvailableMoves())
            {
                SwitchPlayer();
            }
            else
            {
                resultText.text = "It's a draw!";
                tester.GameDraw();
                GameManager.Instance.GameOver();
            }
        }

        /// <summary>
        /// Applies move if, and only if the move is possible.
        /// </summary>
        public void ApplyMove(Vector2Int coordinates)
        {
            if (grid.PossibleMove(coordinates))
            {
                AudioManager.Instance.PlaySFX(selectAudio);
                grid.SetElement(coordinates.x, coordinates.y, currentPlayer);
                previousMove = coordinates;
                ChangeShapeProperties(coordinates);
                CheckWin();
                tester.LastMove(coordinates, currentPlayer - 1);
                tester.ShowGrid(grid);
                tester.ValidMoves(grid.GetValidMoves());
            }
            else
            {
                AudioManager.Instance.PlaySFX(errorAudio);
            }
        }

        /// <summary>
        /// Resets all shapeHolders to get a clean grid.
        /// </summary>
        public void ResetGrid()
        {
            grid = new Grid(size.x, size.y);
            shapeHolders.ForEach(holder => holder.gameObject.GetComponent<MeshFilter>().sharedMesh = null);
            currentPlayer = 1; // Might be nice to add a rule to where the loser may start the next game
        }
    }
}