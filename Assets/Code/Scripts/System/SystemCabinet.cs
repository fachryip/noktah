using Core;
using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class SystemCabinet : SingletonGlobal<SystemCabinet>
    {
        public StageData CurrentStage { get; private set; }

        protected override void OnAwake()
        {
            var stageConfig = GameplayModel.Singleton.StageConfig;
            CurrentStage = new StageData(stageConfig.Theme, stageConfig.Level);
        }
    }
}