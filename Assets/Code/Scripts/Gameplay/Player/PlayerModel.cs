using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Noktah
{
    public class PlayerModel : MonoBehaviour
    {
        public PlayerConfig Config;
        public PlayerController Controller;
        public Rigidbody2D Rigidbody;

        public List<Collider2D> TouchingColliders;

        public bool IsGrounded => TouchingColliders.Count > 0;

        private void Start()
        {
            TouchingColliders = new List<Collider2D>();
        }
    }
}
