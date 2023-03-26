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

        private void Start()
        {
            startingHeight = transform.position.y;
        }

        private void LateUpdate()
        {
            Vector3 position = transform.position;
            float newHeight = startingHeight + height * Mathf.Sin(Time.time * speed);
            transform.position = new Vector3(position.x, newHeight, position.z);
        }
    }
}