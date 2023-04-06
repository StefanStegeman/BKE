using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace BKE
{    
    public class Agent : Player
    {
        public Agent(Mesh mesh, Material material, int playerNumber): 
            base(mesh, material, playerNumber)
            { 
                isBot = true; 
            }

        /// <summary>
        /// Selects random coordinates of a valid move.
        /// </summary>
        public Vector2Int GetRandomMove(Grid grid)
        {
            List<Vector2Int> validMoves = grid.GetValidMoves();
            return validMoves[Random.Range(0, validMoves.Count - 1)];
        }

        /// </summary>
        /// Override of the ApplyMove function.
        /// </summary>
        public override IEnumerator ApplyMove(Grid grid, float time, AudioClip selectAudio, System.Action checkWin)
        {
            grid.InteractableCollider(false);
            yield return new WaitForSeconds(time);
            Vector2Int coordinates = GetRandomMove(grid);
            grid.SetPlayer(coordinates, playerNumber);
            AudioManager.Instance.PlaySFX(selectAudio);
            grid.ChangeShapeHolder(coordinates, (mesh, material));
            checkWin();
            grid.InteractableCollider(true);
        }
    }
}