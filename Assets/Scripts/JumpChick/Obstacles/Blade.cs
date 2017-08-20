using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace JumpChick
{
    public class Blade : MonoBehaviour
    {
        public enum Type
        {
            Normal = 1,
            Rotate = 2
        }

        public Type m_type = Type.Normal;

        void Start()
        {
            if (m_type == Type.Rotate)
            {
                transform.DORotate(new Vector3(0, 0, 360), 0.4f).SetRelative().SetEase(Ease.Linear).SetLoops(-1);
            }
        }

        void Update()
        {

        }
    }
}
