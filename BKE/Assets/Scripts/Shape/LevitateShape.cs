using UnityEngine;

namespace BKE
{
    public class LevitateShape : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private float height;
        private float startingHeight;
        private Vector3 originalPosition;

        private void Start()
        {
            startingHeight = transform.position.y;
            originalPosition = transform.position;
        }

        private void LateUpdate()
        {
            Vector3 position = transform.position;
            float newHeight = startingHeight + height * Mathf.Sin(Time.time * speed);
            transform.position = new Vector3(position.x, newHeight, position.z);
        }

        /// <summary>
        /// Enable levitation
        /// </summary>
        public void EnableLevitation()
        {
            enabled = true;
        }

        /// <summary>
        /// Disable levitation
        /// </summary>
        public void DisableLevitation()
        {
            enabled = false;
        }

        /// <summary>
        /// Resets the position of the GameObject
        /// </summary>
        public void ResetPosition()
        {
            DisableLevitation();
            transform.position = originalPosition;
        }
    }
}