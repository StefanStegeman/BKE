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

        private void LateUpdate()
        {
            transform.Rotate(xAxisDegrees * Time.deltaTime, 
                             yAxisDegrees * Time.deltaTime, 
                             zAxisDegrees * Time.deltaTime);
        }
    }
}