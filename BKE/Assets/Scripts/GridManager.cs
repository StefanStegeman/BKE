using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BKE
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        public Grid grid;

        private void Start()
        {
            grid = new Grid(3, 3);
        }

        public void ApplyMove(Vector2Int coordinates, int player)
        {
            grid.SetElement(coordinates.x, coordinates.y, player);
            InstantiateShape(coordinates, player);
        }

        private void InstantiateShape(Vector2Int coordinates, int player)
        {
            GameObject block = GameObject.Instantiate(prefab);
            float newX = block.transform.position.x + 4 * coordinates.x;
            float newY = block.transform.position.y + 4 * coordinates.y;
            block.transform.position = new Vector3(newX, newY, block.transform.position.z);
        }

        public int DetermineAxisIndex(float screenSize, float coordinate, int gridSize)
        {
            if (coordinate < screenSize / gridSize)
            {
                return 0;
            }
            if (coordinate > screenSize / gridSize * 2)
            {
                return 2;
            }
            return 1;
        }
    }
}