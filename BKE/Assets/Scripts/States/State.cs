using UnityEngine;

namespace BKE
{
    public abstract class State
    {
        protected CanvasManager canvasManager;
        
        public State(CanvasManager canvasManager)
        {
            this.canvasManager = canvasManager;
        }
        
        /// <summary>
        /// Handles the logic required upon entering the state.
        /// </summary>
        public virtual void Enter()
        {
            // Debug.Log("Entered " + this.ToString());
        }

        /// <summary>
        /// Handles the logic which needs to be run every Update call.
        /// </summary>
        public virtual void Update(){}

        /// <summary>
        /// Handles the logic required upon exiting the state.
        /// </summary>
        public virtual void Exit()
        {
            // Debug.Log("Exited " + this.ToString());
        }
    }
}