using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BKE
{
    /*
        Currently only supports even grid sizes. 3x4 will not work e.g.
    */
    public class Grid
    {
        private int width;
        private int height;
        private int[,] grid;
        private int moves;

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new int[width, height];
            ResetMoves();
        }

        /// <summary>
        /// Reset the move counter.
        /// </summary>
        public void ResetMoves()
        {
            moves = 0;
        }

        /// <summary>
        /// Checks whether there are still moves available.
        /// </summary>
        public bool AvailableMoves()
        {
            return moves == grid.Length ? false : true;
        }

        /// <summary>
        /// Gets player from the grid.
        /// </summary>
        public int GetElement(int x, int y)
        {
            return grid[x, y];
        }

        /// <summary>
        /// Sets player in the grid.
        /// </summary>
        public void SetElement(int x, int y, int value)
        {
            moves++;
            grid[x, y] = value;
        }

        /// <summary>
        /// Checks whether coordinate is free or already occupied by a player.
        /// </summary>
        public bool PossibleMove(Vector2Int coordinates)
        {
            return grid[coordinates.x, coordinates.y] == 0 ? true : false;
        }

        /// <summary>
        /// Returns size of the grid.
        /// </summary>
        public Vector2Int GetSize()
        {
            return new Vector2Int(width, height);
        }

        /// <summary>
        /// Checks whether any win conditions are true.
        /// </summary>
        public bool CheckWin()
        {
            if (CheckHorizontal() || CheckVertical() || CheckDiagonal())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whether a player wins vertically.
        /// </summary>
        private bool CheckVertical()
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, 0] != 0 && grid[x, 0] == grid[x, 1] && grid[x, 0] == grid[x, 2])
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether a player wins horizontally.
        /// </summary>
        private bool CheckHorizontal()
        {
            for (int y = 0; y < width; y++)
            {
                if (grid[0, y] != 0 && grid[0, y] == grid[1, y] && grid[0, y] == grid[2, y])
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether a player wins diagonally.
        /// </summary>
        private bool CheckDiagonal()
        {
            if (CheckLeftDiagonal() || CheckRightDiagonal())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whether a player wins on the left diagonal.
        /// </summary>
        private bool CheckLeftDiagonal()
        {
            if (grid[0,0] == 0)
            {
                return false;
            }

            int player = grid[0,0];
            for (int i = 0; i < width; i++)
            {
                if (grid[i, i] != player)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks whether a player wins on the right diagonal.
        /// </summary>
        private bool CheckRightDiagonal()
        {
            if (grid[0, 2] == 0)
            {
                return false;
            }

            int player = grid[0, 2];
            for (int i = 0; i < width; i++)
            {
                if (grid[i, 2-i] != player)
                {
                    return false;
                }
            }
            return true;
        }
    }
}