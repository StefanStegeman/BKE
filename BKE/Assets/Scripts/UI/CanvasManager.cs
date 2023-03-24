using System.Collections.Generic;
using UnityEngine;

namespace BKE
{
    public enum UIType
    {
        Idle,
        Playing, 
        Paused,
        Settings
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
            SwitchUIElement(UIType.Idle);
        }

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

        public void RevertUIElement(UIType newUI)
        {
            currentUI.gameObject.SetActive(false);
            previousUI.gameObject.SetActive(true);
            (currentUI, previousUI) = (previousUI, currentUI);
        }
    }
}