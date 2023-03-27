using UnityEngine;

namespace BKE
{
    public class ShapeManager : MonoBehaviour
    {
        [SerializeField]
        private RotateShape rotation;
        [SerializeField]
        private LevitateShape levitation;

        /// <summary>
        /// Enable rotation and levitation
        /// </summary>
        public void EnableAll()
        {
            rotation.EnableRotation();
            levitation.EnableLevitation();
        }

        /// <summary>
        /// Disable rotation and levitation
        /// </summary>
        public void DisableAll()
        {
            rotation.DisableRotation();
            levitation.DisableLevitation();
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