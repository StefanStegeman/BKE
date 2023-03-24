using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BKE
{
    public class ShapeHolder : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        private Vector2Int coordinates;
        
        [SerializeField]
        private GridManager gridManager;

        /// <summary>
        /// Swaps the current mesh.
        /// </summary>
        public void SwapMesh(Mesh mesh)
        {
            gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
        }

        /// <summary>
        /// Swaps the current material.
        /// </summary>
        public void SwapMaterial(Material material)
        {
            gameObject.GetComponent<Renderer>().sharedMaterial = material;
        }

        /// <summary>
        /// Applies a move when the shapeHolder has detected a mouse click.
        /// </summary>
        public void OnPointerDown(PointerEventData eventData)
        {
            gridManager.ApplyMove(coordinates);
        }
    }
}