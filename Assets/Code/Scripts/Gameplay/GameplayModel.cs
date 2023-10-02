using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class GameplayModel : AbstractSingleton<GameplayModel>
    {
        public ScreenTransition Transition;

        [ReadOnly] public StageModel Stage;

        private void Start()
        {
            Stage = FindObjectOfType<StageModel>();
        }
    }
}