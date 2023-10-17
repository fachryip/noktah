using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class StageData
    {
        public int World;
        public int Level;

        public string Name => World + "-" + Level;

        public StageData(int world, int level)
        {
            World = world;
            Level = level;
        }
    }
}