using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BKE
{
    // This class currently only supports even grid sizes.
    // Sizes like 3x4 will not work *yet*.
    public class Grid
    {
        private int width;
        private int height;
        private int[,] grid;
        public int moves;

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new int[width, height];
            moves = 0;
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
        public int GetPlayer(Vector2Int coordinates)
        {
            return grid[coordinates.x, coordinates.y];
        }

        /// <summary>
        /// Sets player in the grid.
        /// </summary>
        public void SetPlayer(Vector2Int coordinates, int value)
        {
            moves++;
            grid[coordinates.x, coordinates.y] = value;
        }

        /// <summary>
        /// Returns a list of all claimed coordinates of the given player
        /// </summary>
        public List<int> GetCoordinates(int player)
        {
            List<int> coordinates = new List<int>();
            for (int rowNumber = 0; rowNumber < height; rowNumber++)
            {
                int[] row = GetRow(grid, rowNumber);
                for (int element = 0; element < width; element++)
                {
                    if (grid[element, rowNumber] == player)
                    {
                        coordinates.Add(CoordinatesToIndex(element, rowNumber));
                    }
                }
            }
            return coordinates;
        }

        /// <summary>
        /// Checks whether coordinate is free or already occupied by a player.
        /// </summary>
        public bool ValidMove(Vector2Int coordinates)
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
        public bool CheckWin(int player)
        {
            if (CheckHorizontal(player) || CheckVertical(player) || CheckDiagonal(player))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the specified column of the grid
        /// </summary>
        private int[] GetColumn(int[,] collection, int columnNumber)
        {
            return Enumerable.Range(0, collection.GetLength(0)).Select(element => collection[element, columnNumber]).ToArray();
        }

        /// <summary>
        /// Returns the specified row of the grid
        /// </summary>
        private int[] GetRow(int[,] collection, int rowNumber)
        {
            return Enumerable.Range(0, collection.GetLength(1)).Select(element => collection[rowNumber, element]).ToArray();
        }

        /// <summary>
        /// Checks whether a player wins vertically.
        /// </summary>
        private bool CheckVertical(int player)
        {
            for (int rowNumber = 0; rowNumber < height; rowNumber++)
            {
                int[] row = GetRow(grid, rowNumber);
                if (row.Count(element => element == player) == width)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether a player wins horizontally.
        /// </summary>
        private bool CheckHorizontal(int player)
        {
            for (int columnNumber = 0; columnNumber < height; columnNumber++)
            {
                int[] column = GetColumn(grid, columnNumber);
                if (column.Count(element => element == player) == width)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether a player wins diagonally.
        /// </summary>
        private bool CheckDiagonal(int player)
        {
            if (CheckLeftDiagonal(player) || CheckRightDiagonal(player))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whether a player wins on the left diagonal.
        /// </summary>
        private bool CheckLeftDiagonal(int player)
        {
            int[] leftDiagonal = new int[] { grid[0, 0], grid[1, 1], grid[2, 2] };
            return leftDiagonal.Count(element => element == player) == 3 ? true : false;
        }

        /// <summary>
        /// Checks whether a player wins on the right diagonal.
        /// </summary>
        private bool CheckRightDiagonal(int player)
        {
            int[] rightDiagonal = new int[] { grid[0, 2], grid[1, 1], grid[2, 0] };
            return rightDiagonal.Count(element => element == player) == 3 ? true : false;
        }

        /// <summary>
        /// Convert 2D coordinates to 1D index.
        /// This allows to access the shapeHolders which are ordered by coordinates.
        /// </summary>
        private int CoordinatesToIndex(int x, int y)
        {
            return x + height * y;
        }

        public List<Vector2Int> GetValidMoves()
        {
            List<Vector2Int> validMoves = new List<Vector2Int>();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (grid[x, y] == 0)
                    {
                        validMoves.Add(new Vector2Int(x, y));
                    }
                }
            }
            return validMoves;
        }

        public override string ToString()
        {
            return string.Format("[{0}] [{1}] [{2}]\n[{3}] [{4}] [{5}]\n[{6}] [{7}] [{8}]", grid[0,0], grid[1,0], grid[2,0], grid[0,1], grid[1,1], grid[2,1], grid[0,2], grid[1,2], grid[2,2]);
        }
    }
}