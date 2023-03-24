using UnityEngine;

namespace BKE{
    public class Singleton<T> : MonoBehaviour where T : Component 
    {
        protected static T instance;

        public static T Instance 
        { 
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject newInstance = new GameObject();
                        instance = newInstance.AddComponent<T>();
                    }
                }
                return instance;
            } 
        }

        public virtual void Awake()
        {
            if (!Application.isPlaying){ return; }
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this as T;
                DontDestroyOnLoad(transform.gameObject);
                enabled = true;
            }
        }

        public virtual void OnDestroy()
        {
            if (instance != null && instance == this)
            {
                instance = null;
            }
        }
    }
}