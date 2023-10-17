using System.Collections;
using UnityEngine;

namespace Core
{
    public abstract class SingletonInScene<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Singleton;

        protected virtual void OnEnable()
        {
            if (Singleton == null)
            {
                SetSingleton();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnDestroy()
        {
            if (Singleton == this)
            {
                Singleton = null;
            }
        }

        protected virtual void SetSingleton()
        {
            Singleton = gameObject.GetComponent<T>();
        }
    }
}