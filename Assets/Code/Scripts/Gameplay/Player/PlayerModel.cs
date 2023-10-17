using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Noktah
{
    public class PlayerModel : MonoBehaviour
    {
        public PlayerConfig Config;
        public PlayerController Controller;
        public PlayerView View;
        public Rigidbody2D Rigidbody;

        public bool IsGrounded { get; set; }
        public bool IsJump { get; set; }
        public bool IsDie { get; set; }
        public bool CanMove { get; set; }

        private void Start()
        {
            CanMove = true;
        }
    }
}
