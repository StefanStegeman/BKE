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
        private UIElement currentUI;
        private UIElement previousUI;
        
        [SerializeField]
        private List<UIElement> uiElements;

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

        public void SelectMenu(bool singlePlayer)
        {
            SwitchUIElement(UIType.SelectMenu);
        }

        public void SettingsMenu()
        {
            SwitchUIElement(UIType.Settings);
        }
    }
}