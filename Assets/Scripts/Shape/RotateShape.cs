using UnityEngine;

namespace BKE
{
    public class RotateShape : MonoBehaviour
    {
        [SerializeField]
        private float xAxisDegrees;
        [SerializeField]
        private float yAxisDegrees;
        [SerializeField]
        private float zAxisDegrees;
        private Quaternion originalRotation;

        private void Start()
        {
            originalRotation = transform.rotation;
        }

        private void LateUpdate()
        {
            transform.Rotate(xAxisDegrees * Time.deltaTime, 
                             yAxisDegrees * Time.deltaTime, 
                             zAxisDegrees * Time.deltaTime);
        }

        /// <summary>
        /// Enable rotation
        /// </summary>
        public void EnableRotation()
        {
            enabled = true;
        }

        /// <summary>
        /// Disable rotation
        /// </summary>
        public void DisableRotation()
        {
            enabled = false;
        }

        /// <summary>
        /// Resets the rotation of the GameObject
        /// </summary>
        public void ResetRotation()
        {
            DisableRotation();
            transform.rotation = originalRotation;
        }
    }
}