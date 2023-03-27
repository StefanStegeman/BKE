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
        private int currentPlayer = 1;
        #endregion

        #region BotGame
        private Agent agent;
        private bool botGame = false;
        #endregion

        private void Start()
        {
            agent = new Agent(2);
            playerText.text = "Player 1";
            InitializeShapeProperties();
        }

        /// <summary>
        /// Enables or Disables the colliders.
        /// </summary>
        private void InteractableCollider(bool enable)
        {
            grid.InteractableCollider(enable);
        }

        /// <summary>
        /// Sets the value agent.
        /// </summary>
        public void SetAgent(bool enabled)
        {
            botGame = enabled;
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
            currentPlayerObject.ChangeProperties(DetermineShapeProperties());
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
        /// Switch back to the player
        /// </summary>
        private void AgentToPlayer()
        {
            if (agent.GetPlayer() == 1)
            {
                currentPlayer = 2;
            }
            else
            {
                currentPlayer = 1;
            }
            InteractableCollider(true);
            playerText.text = string.Format("Player {0}", currentPlayer);
        }

        /// <summary>
        /// Switch currentPlayer variable according to the player whom's turn it is.
        /// </summary>
        private void SwitchPlayer()
        {
            if (botGame && currentPlayer != agent.GetPlayer())
            {
                InteractableCollider(false);
                currentPlayer = agent.GetPlayer();
                playerText.text = string.Format("Computer", currentPlayer);
                currentPlayerObject.ChangeProperties(DetermineShapeProperties());
                StartCoroutine(ApplyAgentMove(agent.GetRandomMove(grid), Random.Range(1, 2)));
            }
            else if (currentPlayer == 1)
            {
                currentPlayer = 2;
                currentPlayerObject.ChangeProperties(DetermineShapeProperties());
                playerText.text = string.Format("Player {0}", currentPlayer);
            }
            else if (currentPlayer == 2)
            {
                currentPlayer = 1;
                currentPlayerObject.ChangeProperties(DetermineShapeProperties());
                playerText.text = string.Format("Player {0}", currentPlayer);
            }
        }

        /// <summary>
        /// Handle wins, non-wins and draws.
        /// </summary>
        private void CheckWin()
        {
            if (grid.CheckWin(currentPlayer))
            {
                grid.WinAnimation(currentPlayer);
                GameManager.Instance.GameOver();
                if (botGame && agent.GetPlayer() == currentPlayer)
                {
                    AudioManager.Instance.PlaySFX(loseAudio);
                    resultText.text = "You lose!";
                }
                else
                {
                    AudioManager.Instance.PlaySFX(winAudio);
                    resultText.text = string.Format("Player {0} has won!", currentPlayer);
                }
            }
            else if (grid.AvailableMoves() )
            {
                SwitchPlayer();
            }
            else
            {
                resultText.text = "It's a draw!";
                GameManager.Instance.GameOver();
            }
        }

        /// <summary>
        /// Determine the shape properties which need to be swapped.
        /// </summary>
        private (Mesh, Material) DetermineShapeProperties()
        {
            if (currentPlayer == 1)
            {
                return (meshOne, materialOne);
            }
            return (meshTwo, materialTwo);
        }

        /// <summary>
        /// Applies the agent move with the passed delay.
        /// </summary>
        private IEnumerator ApplyAgentMove(Vector2Int coordinates, float seconds)
        {
            currentPlayerObject.ChangeProperties((meshTwo, materialTwo));
            yield return new WaitForSeconds(seconds);
            AudioManager.Instance.PlaySFX(selectAudio);
            grid.SetPlayer(coordinates, currentPlayer);
            grid.ChangeShapeHolder(CoordinatesToIndex(coordinates), DetermineShapeProperties());
            CheckWin();
            AgentToPlayer();
        }

        /// <summary>
        /// Applies move if, and only if the move is possible.
        /// </summary>
        public void ApplyMove(Vector2Int coordinates)
        {
            if (grid.ValidMove(coordinates))
            {
                AudioManager.Instance.PlaySFX(selectAudio);
                grid.SetPlayer(coordinates, currentPlayer);
                grid.ChangeShapeHolder(CoordinatesToIndex(coordinates), DetermineShapeProperties());
                CheckWin();
            }
            else
            {
                AudioManager.Instance.PlaySFX(errorAudio);
            }
        }

        /// <summary>
        /// Resets the game.
        /// </summary>
        public void ResetGame()
        {
            currentPlayer = 1;
            currentPlayerObject.ChangeProperties(DetermineShapeProperties());
            grid.ResetGrid();
        }
    }
}