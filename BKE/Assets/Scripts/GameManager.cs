using UnityEngine;

namespace BKE
{
    public class GameManager : MonoBehaviour
    {
        #region Managers
        [SerializeField]
        private GridManager gridManager;
        [SerializeField]
        private CanvasManager canvasManager;
        #endregion

        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            Instance = this;
        }

        /// <summary>
        /// Start a single- or multiplayer game.
        /// </summary>
        public void StartGame(bool botGame)
        {
            gridManager.enabled = true;
            canvasManager.SwitchUIElement(UIType.Playing);
            // gridManager.SetAgent(botGame);
        }

        /// <summary>
        /// Restart the game.
        /// </summary>
        public void RestartGame()
        {
            gridManager.enabled = true;
            canvasManager.SwitchUIElement(UIType.Playing);
            gridManager.ResetGame();
        }

        /// <summary>
        /// Handle GameOver.
        /// </summary>
        public void GameOver()
        {
            gridManager.enabled = false;
            canvasManager.SwitchUIElement(UIType.GameOver);
        }

        /// <summary>
        /// Pause the game.
        /// </summary>
        public void PauseGame()
        {
            canvasManager.SwitchUIElement(UIType.Paused);
        }

        /// <summary>
        /// Resume the game.
        /// </summary>
        public void ResumeGame()
        {
            canvasManager.SwitchUIElement(UIType.Playing);
        }

        /// <summary>
        /// Reset the game.
        /// </summary>
        public void ResetGame()
        {
            gridManager.enabled = false;
            canvasManager.SwitchUIElement(UIType.MainMenu);
            gridManager.ResetGame();
        }
    }
}