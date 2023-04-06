using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

namespace BKE
{
    public class GridManager : MonoBehaviour
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
        private Grid grid;
        #endregion

        #region UI
        [SerializeField]
        private TMP_Text playerText;
        [SerializeField]
        private TMP_Text resultText;
        #endregion


        #region AudioClips
        [SerializeField]
        private AudioClip selectAudio;
        [SerializeField]
        private AudioClip errorAudio;
        [SerializeField]
        private AudioClip winAudio;
        [SerializeField]
        private AudioClip loseAudio;
        #endregion
        
        #region Current Player
        [SerializeField]
        private ShapeManager currentPlayerObject;
        private Player currentPlayer;
        private List<Player> players;
        #endregion

        private void Start()
        {
            players = new List<Player>();
        }

        /// <summary>
        /// Enables or Disables the colliders.
        /// </summary>
        private void InteractableCollider(bool enable)
        {
            grid.InteractableCollider(enable);
        }

        /// <summary>
        /// Initializes the grid and players.
        /// </summary>
        public void InitializeGame(bool singlePlayer)
        {
            InitializeShapeProperties();
            InitializePlayers(singlePlayer);
            playerText.text = "Player 1";
            currentPlayerObject.ChangeProperties(DetermineShapeProperties());
        }

        /// <summary>
        /// Initializes the players.
        /// </summary>
        private void InitializePlayers(bool singlePlayer)
        {
            if (singlePlayer)
            {
                players = new List<Player>(){new Player(meshOne, materialOne, 1), new Agent(meshTwo, materialTwo, 2)};
            }
            else
            {
                players = new List<Player>(){new Player(meshOne, materialOne, 1), new Player(meshTwo, materialTwo, 2)};
            }
            currentPlayer = players[0];
        }

        /// <summary>
        /// Initializing all shape properties.
        /// </summary>
        private void InitializeShapeProperties()
        {
            meshOne = playerOne.GetComponent<MeshFilter>().sharedMesh;
            meshTwo = playerTwo.GetComponent<MeshFilter>().sharedMesh;
            materialOne = playerOne.GetComponent<Renderer>().sharedMaterial;
            materialTwo = playerTwo.GetComponent<Renderer>().sharedMaterial;
        }

        /// <summary>
        /// Convert Vector2Int to int.
        /// This allows to access the shapeHolders which are ordered by coordinates.
        /// </summary>
        private int CoordinatesToIndex(Vector2Int coordinates)
        {
            return coordinates.x + grid.GetSize().y * coordinates.y;
        }

        /// <summary>
        /// Resets the game.
        /// </summary>
        public void ResetGame()
        {
            currentPlayer = players[0];
            currentPlayerObject.ChangeProperties(DetermineShapeProperties());
            grid.ResetGrid();
        }

        /// <summary>
        /// Applies the move of the current player.
        /// </summary>
        public void ApplyMove(Vector2Int coordinates)
        {
            if (currentPlayer.ApplyMove(grid, coordinates))
            {
                AudioManager.Instance.PlaySFX(selectAudio);
                CheckWin();
            }
            else
            {
                AudioManager.Instance.PlaySFX(errorAudio);
            }
        }

        /// <summary>
        /// Handle wins, non-wins and draws.
        /// </summary>
        private void CheckWin()
        {
            int currentPlayerNumber = currentPlayer.GetPlayerNumber();
            if (grid.CheckWin(currentPlayerNumber))
            {
                grid.WinAnimation(currentPlayerNumber);
                GameManager.Instance.GameOver();
                if (currentPlayer.IsBot())
                {
                    resultText.text = string.Format("Computer won!", currentPlayerNumber);
                    AudioManager.Instance.PlaySFX(loseAudio);
                }
                else
                {
                    resultText.text = string.Format("Player {0} has won!", currentPlayerNumber);
                    AudioManager.Instance.PlaySFX(winAudio);
                }
            }
            else if (grid.AvailableMoves())
            {
                SwitchPlayer();
                if (currentPlayer.IsBot())
                {
                    playerText.text = "Computer";
                    currentPlayerObject.ChangeProperties(currentPlayer.GetProperties());
                    StartCoroutine(currentPlayer.ApplyMove(grid, Random.Range(1, 2), selectAudio, CheckWin));
                }
            }
            else
            {
                resultText.text = "It's a draw!";
                GameManager.Instance.GameOver();
            }
        }
        
        /// <summary>
        /// Switch currentPlayer variable according to the player whom's turn it is.
        /// </summary>
        private void SwitchPlayer()
        {
            if (currentPlayer == players[0])
            {
                currentPlayer = players[1];
            }
            else
            {
                currentPlayer = players[0];
            }
            currentPlayerObject.ChangeProperties(currentPlayer.GetProperties());
            playerText.text = string.Format("Player {0}", currentPlayer.GetPlayerNumber());
        }

        /// <summary>
        /// Determine the shape properties which need to be swapped.
        /// </summary>
        private (Mesh, Material) DetermineShapeProperties()
        {
            if (currentPlayer.GetPlayerNumber() == 1)
            {
                return (meshOne, materialOne);
            }
            return (meshTwo, materialTwo);
        }
    }
}