using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace BKE
{    
    public class Agent
    {
        private int player;

        public Agent(int player)
        {
            SetPlayer(player);
        }

        /// <summary>
        /// Selects random coordinates of a valid move.
        /// </summary>
        public Vector2Int GetRandomMove(Grid grid)
        {
            List<Vector2Int> validMoves = grid.GetValidMoves();
            return validMoves[Random.Range(0, validMoves.Count - 1)];
        }

        /// <summary>
        /// Sets the player id/ number.
        /// </summary>
        public void SetPlayer(int player)
        {
            this.player = player;
        }

        /// <summary>
        /// Gets the player id/ number.
        /// </summary>
        public int GetPlayer()
        {
            return player;
        }
    }
}