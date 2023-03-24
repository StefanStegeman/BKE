using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BKE
{
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

        public bool PossibleMove(int x, int y)
        {
            return grid[x, y] == 0 ? true : false;
        }

        public Vector2Int GetSize()
        {
            return new Vector2Int(width, height);
        }
    }
}