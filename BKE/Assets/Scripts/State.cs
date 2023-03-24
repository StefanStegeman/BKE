using UnityEngine;

namespace BKE
{
    public abstract class State
    {
        public virtual void Enter()
        {
            Debug.Log("Entered " + this.ToString());
        }

        public virtual void Update(){}
        public virtual void Exit()
        {
            Debug.Log("Exited " + this.ToString());
        }
    }
}