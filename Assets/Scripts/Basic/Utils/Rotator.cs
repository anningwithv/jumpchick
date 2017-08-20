using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace PlatformBasic
{
    public class Rotator : MonoBehaviour
    {
        public float m_rotateSpd = 360f;
        void Start()
        {
            transform.DORotate(new Vector3(0, 0, 360), 360/m_rotateSpd).SetRelative().SetEase(Ease.Linear).SetLoops(-1);

        }

    }
}
