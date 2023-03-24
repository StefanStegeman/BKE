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
        
        public virtual void Enter()
        {
            // Debug.Log("Entered " + this.ToString());
        }

        public virtual void Update(){}
        public virtual void Exit()
        {
            // Debug.Log("Exited " + this.ToString());
        }
    }
}