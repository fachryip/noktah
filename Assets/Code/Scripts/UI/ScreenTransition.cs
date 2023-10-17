using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class ScreenTransition : MonoBehaviour
    {
        [SerializeField] private Animator Animator;

        public void SetFade()
        {
            Animator.Play("Fade");
        }
    }
}