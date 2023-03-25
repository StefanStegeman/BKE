using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace BKE
{
    public class AgentTester : MonoBehaviour
    {
        [SerializeField]
        private string path = "Assets/Scripts/Grid/Agent/Testing/Testing.txt";

        [SerializeField]
        private Agent agent;

        
        public void MakeMove(Grid gameState, Vector2Int lastMove)
        {
            Vector2Int move = agent.Move(gameState, lastMove);
        }

        private string ConvertListToString(List<Vector2Int> list)
        {
            string result = "";
            list.ForEach(element => result += string.Format("({0}, {1}), ", element.x, element.y));
            return result;
        }

        public void GameWinner(int player)
        {
            WriteString(string.Format("Player {0} has won the game!", player));
        }

        public void GameDraw()
        {
            WriteString("The gmame ended up in a draw!");
        }

        public void ShowGrid(Grid grid)
        {
            WriteString("Grid:");
            WriteString(grid.ToString());
        }

        public void ValidMoves(List<Vector2Int> moves)
        {
            WriteString(string.Format("ValidMoves: {0}", ConvertListToString(moves)));
        }

        public void LastMove(Vector2Int move, int player)
        {
            WriteString(string.Format("Player {0} just made a move on {1}", player, move));
        }

        private void WriteString(string text)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(text);
            }
        }
    }
}