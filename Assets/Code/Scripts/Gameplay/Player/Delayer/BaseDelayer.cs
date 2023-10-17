using System.Collections;
using UnityEngine;

namespace Noktah
{
    public abstract class BaseDelayer
    {
        protected DelayType Type;
        protected int MaxFrame;
        protected int Frame;

        public bool IsActive { get; protected set; }

        public BaseDelayer(DelayType type, int maxFrame)
        {
            Type = type;
            MaxFrame = maxFrame;
            Frame = 0;
            IsActive = false;
        }

        public void Update()
        {
            if (IsActive)
            {
                UpdateFunc();
            }
        }

        protected abstract void UpdateFunc();

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
            Frame = 0;
        }
    }
}