using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BKE
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        private Grid grid;
        
        private void Start()
        {
            grid = new Grid(3, 3);
        }

        public void AddBlock(Vector2Int coordinates)
        {
            if (grid.PossibleMove(coordinates.x, coordinates.y))
            {
                grid.SetElement(coordinates.x, coordinates.y, -1);
                GameObject block = GameObject.Instantiate(prefab);
                float newX = block.transform.position.x + 4 * coordinates.x;
                float newY = block.transform.position.y + 4 * coordinates.y;
                block.transform.position = new Vector3(newX, newY, block.transform.position.z);
            }
        }
    }
}