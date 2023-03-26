using UnityEngine;

namespace BKE
{
    public class ShapeManager : MonoBehaviour
    {
        [SerializeField]
        private RotateShape rotation;
        [SerializeField]
        private LevitateShape levitatetion;

        /// <summary>
        /// Enable rotatetion
        /// </summary>
        public void EnableRotation()
        {
            rotation.enabled = true;
        }

        /// <summary>
        /// Disable rotatetion
        /// </summary>
        public void DisableRotation()
        {
            rotation.enabled = false;
        }

        /// <summary>
        /// Enable levitation
        /// </summary>
        public void EnableLevitation()
        {
            levitatetion.enabled = true;
        }

        /// <summary>
        /// Disable levitation
        /// </summary>
        public void DisableLevitation()
        {
            levitatetion.enabled = false;
        }

        /// <summary>
        /// Enable rotation and levitation
        /// </summary>
        public void EnableAll()
        {
            EnableRotation();
            EnableLevitation();
        }

        /// <summary>
        /// Disable rotation and levitation
        /// </summary>
        public void DisableAll()
        {
            DisableRotation();
            DisableLevitation();
        }

        /// <summary>
        /// Change the mesh and material of the shape.
        /// </summary>
        public void ChangeProperties(Mesh mesh, Material material)
        {
            gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
            gameObject.GetComponent<Renderer>().sharedMaterial = material;
        }
    }
}