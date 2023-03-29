using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BKE
{
    public class Player
    {
        protected Mesh mesh;
        protected Material material;
        protected int playerNumber;
        protected bool isBot;

        public Player(Mesh mesh, Material material, int playerNumber)
        {
            this.mesh = mesh;
            this.material = material;
            this.playerNumber = playerNumber;
            isBot = false;
        }

        public Player(Mesh mesh, Material material, int playerNumber, bool isBot)
        {
            this.mesh = mesh;
            this.material = material;
            this.playerNumber = playerNumber;
            this.isBot = isBot;
        }

        public (Mesh, Material) GetProperties()
        {
            return (mesh, material);
        }

        public int GetPlayerNumber()
        {
            return playerNumber;
        }

        public bool IsBot()
        {
            return isBot;
        }

        /// <summary>
        /// Applies move if, and only if the move is possible.
        /// Returns false if insuccesful.
        /// </summary>
        public bool ApplyMove(Grid grid, Vector2Int coordinates)
        {
            if (grid.ValidMove(coordinates))
            {
                grid.SetPlayer(coordinates, playerNumber);
                grid.ChangeShapeHolder(coordinates, (mesh, material)); 
                return true;
            }
            return false;
        }

        public virtual IEnumerator ApplyMove(Grid grid, float time, System.Action checkWin) { yield return null; }
    }
}