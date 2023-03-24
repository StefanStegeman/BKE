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

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new int[width, height];
        }

        public int GetElement(int x, int y)
        {
            return grid[x, y];
        }

        public void SetElement(int x, int y, int value)
        {
            grid[x, y] = value;
        }

        public bool PossibleMove(Vector2Int coordinates)
        {
            return grid[coordinates.x, coordinates.y] == 0 ? true : false;
        }

        public Vector2Int GetSize()
        {
            return new Vector2Int(width, height);
        }

        public bool CheckWin()
        {
            if (CheckHorizontal() || CheckVertical() || CheckDiagonal())
            {
                return true;
            }
            return false;
        }

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

        private bool CheckDiagonal()
        {
            if (CheckLeftDiagonal() || CheckRightDiagonal())
            {
                return true;
            }
            return false;
        }

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

        private bool CheckRightDiagonal()
        {
            if (grid[0, 2] == 0)
            {
                return false;
            }

            int player = grid[2, 2];
            for (int x = 2; x > -1; x--)
            {
                for (int y = 0; y < 2; y++)
                {
                    if (grid[x, y] != player)
                    {
                        return false;
                    }

                }
            }
            return true;
        }
    }
}