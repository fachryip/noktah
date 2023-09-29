using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerModel Model;

        private Vector2 _velocity;

        private void FixedUpdate()
        {
            if (Mathf.Abs(Model.Rigidbody.velocity.x) != Model.Config.Speed)
            {
                _velocity.x = (Model.Rigidbody.velocity.x < 0 ? -1 : 1) * Model.Config.Speed;
                _velocity.y = Model.Rigidbody.velocity.y;
                Model.Rigidbody.velocity = _velocity;
            }
        }
    }
}