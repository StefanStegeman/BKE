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
        private List<GameObject> shapes;
        private List<ShapeHolder> shapeHolders = new List<ShapeHolder>();
        private List<RotateShape> shapeRotators = new List<RotateShape>();

        private Grid grid;
        #endregion

        #region UI
        [SerializeField]
        private TMP_Text playerText;
        [SerializeField]
        private TMP_Text resultText;
        #endregion

        private int currentPlayer = 1;
        [SerializeField]
        private AudioClip selectAudio;
        [SerializeField]
        private AudioClip errorAudio;
        
        [SerializeField]
        private ShapeManager shapeManager;

        private Vector2Int previousMove;
        private Agent agent;
        private bool botGame = false;

        private void Start()
        {
            grid = new Grid(size.x, size.y);
            agent = new Agent(2);
            playerText.text = "Player 1";
            InitializeShapeHolders();
            InitializeShapeProperties();
        }

        /// <summary>
        /// Initialize shape- holders and rotators.
        /// </summary>
        private void InitializeShapeHolders()
        {
            foreach (GameObject shape in shapes)
            {
                shapeHolders.Add(shape.GetComponent<ShapeHolder>());
                shapeRotators.Add(shape.GetComponent<RotateShape>());
            }
            shapeRotators.ForEach(element => element.DisableRotation());
        }

        private void OnEnable()
        {
            shapeManager.EnableAll();
        }

        private void OnDisable()
        {
            shapeManager.DisableAll();
        }

        /// <summary>
        /// Enables or Disables the collider.
        /// </summary>
        private void InteractableCollider(bool enable)
        {
            shapes.ForEach(element => element.GetComponent<Collider>().enabled = enable);
        }

        /// <summary>
        /// Start the game with or without agent.
        /// </summary>
        public void StartGame(bool botGame)
        {
            enabled = true;
            this.botGame = botGame;
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
            shapeManager.ChangeProperties(meshOne, materialOne);
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
        /// Change the mesh and material of the shapeholder and current shape.
        /// </summary>
        private void ChangeShapeProperties(Vector2Int coordinates) // Change name to ChangeHolderProperties
        {
            if (currentPlayer == 1)
            {
                shapeHolders[CoordinatesToIndex(coordinates)].SwapMesh(meshOne);
                shapeHolders[CoordinatesToIndex(coordinates)].SwapMaterial(materialOne);
                shapeManager.ChangeProperties(meshTwo, materialTwo);
            }
            else
            {
                shapeHolders[CoordinatesToIndex(coordinates)].SwapMesh(meshTwo);
                shapeHolders[CoordinatesToIndex(coordinates)].SwapMaterial(materialTwo);
                shapeManager.ChangeProperties(meshOne, materialOne);
            }
        }

        /// <summary>
        /// Switch back to the player
        /// </summary>
        private void SwitchToPlayer()
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
                StartCoroutine(ApplyAgentMove(agent.GetRandomMove(grid), Random.Range(1, 2)));
            }
            else if (currentPlayer == 1)
            {
                currentPlayer = 2;
                playerText.text = string.Format("Player {0}", currentPlayer);
            }
            else if (currentPlayer == 2)
            {
                currentPlayer = 1;
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
                resultText.text = string.Format("Player {0} has won!", currentPlayer);
                List<int> winningCoordinates = grid.GetCoordinates(currentPlayer);
                winningCoordinates.ForEach(index => shapeRotators[index].EnableRotation());
                GameManager.Instance.GameOver();
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
        /// Applies the agent move with the passed delay.
        /// </summary>
        private IEnumerator ApplyAgentMove(Vector2Int coordinates, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            AudioManager.Instance.PlaySFX(selectAudio);
            grid.SetPlayer(coordinates, currentPlayer);
            ChangeShapeProperties(coordinates);
            CheckWin();
            SwitchToPlayer();
        }

        /// <summary>
        /// Applies move if, and only if the move is possible.
        /// </summary>
        public void ApplyMove(Vector2Int coordinates)
        {
            if (grid.ValidMove(coordinates))
            {
                AudioManager.Instance.PlaySFX(selectAudio);
                previousMove = coordinates;
                grid.SetPlayer(coordinates, currentPlayer);
                ChangeShapeProperties(coordinates);
                CheckWin();
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
            shapeRotators.ForEach(rotator => rotator.ResetRotation());
            shapeManager.ChangeProperties(meshOne, materialOne);
            currentPlayer = 1;
        }
    }
}