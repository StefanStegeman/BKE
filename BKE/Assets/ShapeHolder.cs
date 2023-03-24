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

        public void SwapMesh(Mesh mesh)
        {
            gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
        }

        public void SwapMaterial(Material material)
        {
            gameObject.GetComponent<Renderer>().sharedMaterial = material;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            gridManager.ApplyMove(coordinates);
        }
    }
}