using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace BKE
{    
    public class Agent : MonoBehaviour
    {
        private int playerNumber = 2;
        private int seconds = 2;

        private IEnumerator CalculateBestMove()
        {
            float timePassed = 0;
            while (timePassed < 3)
            {
                timePassed += Time.deltaTime;
                yield return null;
            }
        }

        public Vector2Int Move(Grid gameState, Vector2Int lastMove)
        {
            Grid state = gameState;
            Node root = new Node(lastMove, state);

            StartCoroutine(CalculateBestMove());
            return new Vector2Int(0, 0);
        }
    }
}