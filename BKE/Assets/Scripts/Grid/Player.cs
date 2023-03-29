using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BKE
{
    public class Player
    {
        private Mesh mesh;
        private Material material;
        private int playerNumber;
        private bool isBot;

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
        public virtual bool ApplyMove(Grid grid, Vector2Int coordinates)
        {
            if (grid.ValidMove(coordinates))
            {
                grid.SetPlayer(coordinates, playerNumber);
                grid.NewChange(coordinates, (mesh, material)); 
                return true;
            }
            return false;
        }

    }
}