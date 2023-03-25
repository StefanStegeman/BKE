using UnityEngine;
using System.Collections.Generic;

namespace BKE
{
    public class Node
    {
        public Vector2Int move;
        public Grid state;
        public Node parent;
        public List<Node> children;
        public List<Vector2Int> validMoves;
        private int N;
        private float Q;

        public Node(Vector2Int move, Grid state)
        {
            this.move = move;
            this.state = state;
            parent = null;
            children = new List<Node>();
            validMoves = state.GetValidMoves();
            N = 1;
            Q = 0;
        }

        public Node(Vector2Int move, Grid state, Node parent)
        {
            this.move = move;
            this.state = state;
            this.parent = parent;
            children = new List<Node>();
            validMoves = state.GetValidMoves();
            N = 1;
            Q = 0;
        }
    }
}