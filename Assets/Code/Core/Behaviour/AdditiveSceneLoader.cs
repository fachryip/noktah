using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class AdditiveSceneLoader : MonoBehaviour
    {
        public void Load(string name, Action onFinish)
        {
            StartCoroutine(LoadRoutine(name, onFinish));
        }

        private IEnumerator LoadRoutine(string name, Action onFinish)
        {
            Debug.Log("Load Scene " + name);

            var operation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
            while (!operation.isDone)
            {
                yield return null;
            }

            onFinish?.Invoke();
        }
    }
}