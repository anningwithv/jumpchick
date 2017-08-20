using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PlatformBasic;

namespace JumpChick
{
    public class ActiveWhenPlayerNear : MonoBehaviour
    {
        public float m_activeDistance = -1;

        public UnityAction OnPlayerNear = null;

        private bool m_hasTriggered = false;
        private Transform m_target = null;

        void Start()
        {
            if (m_activeDistance == -1)
            {
                m_activeDistance = CameraAutoSize.sCameraSize;
            }

            m_target = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
        }

        void Update()
        {
            if(transform.position.y - m_target.position.y < m_activeDistance)
            {
                if (m_hasTriggered == false && OnPlayerNear != null)
                {
                    m_hasTriggered = true;
                    OnPlayerNear.Invoke();
                }
            }
        }
    }
}
