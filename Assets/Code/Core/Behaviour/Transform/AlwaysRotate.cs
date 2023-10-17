using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class AlwaysRotate : MonoBehaviour
    {
        [SerializeField] private Vector3 Direction;

        private void FixedUpdate()
        {
            transform.Rotate(Direction);
        }
    }
}