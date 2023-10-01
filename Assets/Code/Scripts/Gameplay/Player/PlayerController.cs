using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Noktah
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerModel Model;

        private Vector2 _velocity;
        private bool _isJump;
        private ContactPoint2D _contact;

        private void Update()
        {
            if (Input.GetButtonDown(ConstInput.FIRE1) && !_isJump)
            {
                if (Model.IsGrounded)
                {
                    _isJump = true;
                }
            }
        }

        private void FixedUpdate()
        {
            if (Mathf.Abs(Model.Rigidbody.velocity.x) != Model.Config.MoveSpeed)
            {
                _velocity.x = (Model.Rigidbody.velocity.x < 0 ? -1 : 1) * Model.Config.MoveSpeed;
            }

            if (_isJump)
            {
                _isJump = false;
                _velocity.y = Model.Config.JumpForce;
            }
            else
            {
                _velocity.y = Model.Rigidbody.velocity.y;
            }

            Model.Rigidbody.velocity = _velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _contact = collision.GetContact(0);
            var angle = Vector2.Angle(-Vector2.up, _contact.point - (Vector2)Model.transform.position);

            if (angle <= Model.Config.MaxSlopeDegree)
            {
                if (!Model.TouchingColliders.Contains(collision.collider))
                {
                    Model.TouchingColliders.Add(collision.collider);
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            Model.TouchingColliders.Remove(collision.collider);
        }

        private void OnDrawGizmos()
        {
            if (Model.IsGrounded)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(Model.transform.position, Model.transform.position - Model.transform.up);
            }
        }
    }
}