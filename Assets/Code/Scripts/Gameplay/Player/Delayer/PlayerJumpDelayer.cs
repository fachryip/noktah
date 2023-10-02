using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class PlayerJumpDelayer : BaseDelayer
    {
        private PlayerModel _model;

        public PlayerJumpDelayer(PlayerModel model) : base(DelayType.Jump, model.Config.JumpFrameDelay)
        {
            _model = model;
        }

        protected override void UpdateFunc()
        {
            if (++Frame <= MaxFrame)
            {
                if (_model.IsGrounded)
                {
                    _model.IsJump = true;
                    SetActive(false);
                }
            }
            else
            {
                SetActive(false);
            }
        }
    }
}