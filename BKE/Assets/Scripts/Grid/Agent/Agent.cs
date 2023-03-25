using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace BKE
{    
    public class Agent : MonoBehaviour
    {
        private int playerNumber = 2;
        private int seconds = 2;
        private Vector2Int bestMove;

        private IEnumerator CalculateBestMove(Grid state, Vector2Int lastMove, Node node)
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
            if (root.validMoves.Contains(new Vector2Int(1,1)))
            {
                return new Vector2Int(1,1);
            }
            System.Random random = new System.Random();
            // StartCoroutine(CalculateBestMove(state, lastMove, root));
            return root.validMoves[random.Next(root.validMoves.Count)];
        }
    }
}