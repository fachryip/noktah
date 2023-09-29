using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class SetRigidbodyVelocity : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D Rigidbody;
        [SerializeField] private Vector2 Velocity;

        [ContextMenu("Set")]
        public void Set()
        {
            Rigidbody.velocity = Velocity;
        }
    }
}