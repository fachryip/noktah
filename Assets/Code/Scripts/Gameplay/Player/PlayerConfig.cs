using System.Collections;
using UnityEngine;

namespace Noktah
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig", order = 1)]
    public class PlayerConfig : ScriptableObject
    {
        public float MoveSpeed;
        public float JumpForce;
        public float MaxSlopeDegree;
        public int JumpFrameDelay;
        public int IsGroundedFrameDelay;

        public void Reset()
        {
            MoveSpeed = 3.5f;
            JumpForce = 5.5f;
            MaxSlopeDegree = 60f;
            JumpFrameDelay = 20;
            IsGroundedFrameDelay = 10;
        }
    }
}