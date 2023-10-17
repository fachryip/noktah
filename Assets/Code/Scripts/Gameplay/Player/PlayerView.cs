using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer Renderer;

        public void SetVisibility(bool isVisible)
        {
            Renderer.enabled = isVisible;
        }
    }
}