using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private GameplayModel Model;

        private void Start()
        {
            var currentStage = SystemCabinet.GetInstance().CurrentStage;
            Model.SceneLoader.Load(currentStage.Name, Model.StageFinishLoaded);
        }
    }
}