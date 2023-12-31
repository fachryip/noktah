﻿using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

namespace Core
{
    public abstract class SingletonGlobal<T> : SingletonInGlobal where T : MonoBehaviour
    {
        #region  Fields
        [CanBeNull]
        private static T _instance;

        [NotNull]
        // ReSharper disable once StaticMemberInGenericType
        private static readonly object Lock = new object();

        [SerializeField]
        private bool _persistent = true;
        #endregion

        #region  Properties
        [NotNull]
        private static T Instance
        {
            get
            {
                if (Quitting)
                {
                    Debug.LogWarning($"[{nameof(SingletonInGlobal)}<{typeof(T)}>] Instance will not be returned because the application is quitting.");
                    // ReSharper disable once AssignNullToNotNullAttribute
                    return null;
                }
                lock (Lock)
                {
                    if (_instance != null)
                        return _instance;
                    var instances = FindObjectsOfType<T>();
                    var count = instances.Length;
                    if (count > 0)
                    {
                        if (count == 1)
                            return _instance = instances[0];
                        Debug.LogWarning($"[{nameof(SingletonInGlobal)}<{typeof(T)}>] There should never be more than one {nameof(SingletonInGlobal)} of type {typeof(T)} in the scene, but {count} were found. The first instance found will be used, and all others will be destroyed.");
                        for (var i = 1; i < instances.Length; i++)
                            Destroy(instances[i]);
                        return _instance = instances[0];
                    }

                    Debug.Log($"[{nameof(SingletonInGlobal)}<{typeof(T)}>] An instance is needed in the scene and no existing instances were found, so a new instance will be created.");
                    return _instance = new GameObject($"({nameof(SingletonInGlobal)}){typeof(T)}")
                               .AddComponent<T>();
                }
            }
        }
        #endregion

        #region  Methods
        private void Awake()
        {
            if (_persistent)
                DontDestroyOnLoad(gameObject);
            OnAwake();
        }

        protected virtual void OnAwake() { }

        public static T GetInstance()
        {
            return Instance;
        }
        #endregion
    }

    public abstract class SingletonInGlobal : MonoBehaviour
    {
        #region  Properties
        public static bool Quitting { get; private set; }
        #endregion

        #region  Methods
        private void OnApplicationQuit()
        {
            Quitting = true;
        }
        #endregion
    }
}