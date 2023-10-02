using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class PlayerGroundedDelayer : BaseDelayer
    {
        private PlayerModel _model;

        public PlayerGroundedDelayer(PlayerModel model) : base (DelayType.IsGround, model.Config.IsGroundedFrameDelay)
        {
            _model = model;
        }

        protected override void UpdateFunc()
        {
            if (++Frame > MaxFrame)
            {
                //Debug.Log("Grounded Delay Frame " + Frame);
                _model.IsGrounded = false;
                SetActive(false);
            }
        }
    }
}