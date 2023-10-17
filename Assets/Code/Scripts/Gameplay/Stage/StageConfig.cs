using System.Collections;
using UnityEngine;

namespace Noktah
{
    [CreateAssetMenu(fileName = "StageConfig", menuName = "ScriptableObjects/StageConfig", order = 1)]
    public class StageConfig : ScriptableObject
    {
        public int Theme;
        public int Level;

        public void Reset()
        {
            Theme = 1;
            Level = 1;
        }
    }
}