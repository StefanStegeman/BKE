using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BKE
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private GameController controller;

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                controller.AddBlock(DetermineElement(Input.mousePosition));
            }
        }

        private Vector2Int DetermineElement(Vector3 mousePosition)
        {
            return new Vector2Int
            {
                x = DetermineIndex(Screen.width, mousePosition.x), 
                y = DetermineIndex(Screen.height, mousePosition.y)
            };
        }

        private int DetermineIndex(float size, float axis)
        {
            if (axis < size / 3.0f)
            {
                return 0;
            }
            if (axis > size / 3.0f * 2)
            {
                return 2;
            }
            return 1;
        }
    }
}