using System.Collections;
using UnityEngine;

namespace Noktah
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig", order = 1)]
    public class PlayerConfig : ScriptableObject
    {
        public float Speed;

        public void Reset()
        {
            Speed = 3.5f;
        }
    }
}