using System.Collections.Generic;
using UnityEngine;

namespace BKE
{
    public enum UIType
    {
        MainMenu,
        SelectMenu,
        Playing, 
        Paused,
        Settings,
        GameOver
    } 

    public class CanvasManager : MonoBehaviour
    {
        [SerializeField]
        private List<UIElement> uiElements;
        private UIElement currentUI;
        private UIElement previousUI;

        private void Start()
        {
            uiElements.ForEach(element => element.gameObject.SetActive(false));
            SwitchUIElement(UIType.MainMenu);
        }

        /// <summary>
        /// Switches the current UIElement.
        /// </summary>
        public void SwitchUIElement(UIType type)
        {
            if (currentUI != null)
            {
                currentUI.gameObject.SetActive(false);
                previousUI = currentUI;
            }
            UIElement element = uiElements.Find(element => element.uiType == type);
            if (element != null)
            {
                element.gameObject.SetActive(true);
                currentUI = element;
            }
        }

        /// <summary>
        /// Reverts to the previous UIElement.
        /// </summary>
        public void RevertUIElement(UIType newUI)
        {
            currentUI.gameObject.SetActive(false);
            previousUI.gameObject.SetActive(true);
            (currentUI, previousUI) = (previousUI, currentUI);
        }

        /// <summary>
        /// Switch to the SelectMenu UIType.
        /// </summary>
        public void SelectMenu(bool singlePlayer)
        {
            SwitchUIElement(UIType.SelectMenu);
        }

        /// <summary>
        /// Switch to the Settings UIType.
        /// </summary>
        public void SettingsMenu()
        {
            SwitchUIElement(UIType.Settings);
        }
    }
}