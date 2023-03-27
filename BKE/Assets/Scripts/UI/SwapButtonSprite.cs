using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BKE
{
    public class SwapButtonSprite : MonoBehaviour
    {
        [SerializeField]
        private Sprite unMuted;
        [SerializeField]
        private Sprite muted;

        private Image buttonSprite;
        private Sprite currentSprite;
        
        private void Start()
        {
            buttonSprite = gameObject.GetComponent<Image>();
            buttonSprite.sprite = unMuted;
            currentSprite = unMuted;
        }

        public void SwapSprite()
        {
            if (currentSprite == unMuted)
            {
                buttonSprite.sprite = muted;
                currentSprite = muted;
            }
            else
            {
                buttonSprite.sprite = unMuted;
                currentSprite = unMuted;
            }
        }
    }
}
