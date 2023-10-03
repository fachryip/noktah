using Core;
using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class GameplayModel : SingletonInScene<GameplayModel>
    {
        public ScreenTransition Transition;
        public AdditiveSceneLoader SceneLoader;

        [ReadOnly] public StageModel Stage;
        [ReadOnly] public PlayerModel Player;

        public event System.Action OnStageLoaded;

        public void StageFinishLoaded()
        {
            Stage = FindObjectOfType<StageModel>();

            OnStageLoaded?.Invoke();
        }
    }
}