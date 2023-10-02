using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Noktah
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerModel Model;

        private Vector2 _velocity;
        private ContactPoint2D _contact;
        private List<Collider2D> _touchingColliders;
        private PlayerJumpDelayer _jumpDelay;
        private BaseDelayer _isGroundedDelay;

        private void Start()
        {
            _touchingColliders = new List<Collider2D>();
            _jumpDelay = new PlayerJumpDelayer(Model);
            _isGroundedDelay = new PlayerGroundedDelayer(Model);
        }

        private void Update()
        {
            if (Input.GetButtonDown(ConstInput.FIRE1) && !Model.IsJump)
            {
                _jumpDelay.SetActive(true);
            }
        }

        private void FixedUpdate()
        {
            if (Mathf.Abs(Model.Rigidbody.velocity.x) != Model.Config.MoveSpeed)
            {
                _velocity.x = (Model.Rigidbody.velocity.x < 0 ? -1 : 1) * Model.Config.MoveSpeed;
            }

            _jumpDelay.Update();
            _isGroundedDelay.Update();

            if (Model.IsJump)
            {
                Model.IsJump = false;
                Model.IsGrounded = false;
                _isGroundedDelay.SetActive(false);
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
                if (!_touchingColliders.Contains(collision.collider))
                {
                    Model.IsGrounded = true;
                    _isGroundedDelay.SetActive(false);
                    _touchingColliders.Add(collision.collider);
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _touchingColliders.Remove(collision.collider);
            if (_touchingColliders.Count == 0 && Model.IsGrounded)
            {
                _isGroundedDelay.SetActive(true);
            }
            //Model.IsGrounded = _touchingColliders.Count > 0;
        }

        private void JumpDelayUpdate()
        {
            
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