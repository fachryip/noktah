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
            CurrentStage = new StageData(0, 0);
        }
    }
}