using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformBasic
{
    public class Parallax : MonoBehaviour
    {
        public float m_parallaxScale = 0.5f;
        private CameraFollow m_cameraFollow = null;
        private Vector3 m_cameraLastPos;

        void Start()
        {
            m_cameraFollow = Camera.main.GetComponent<CameraFollow>();
            if (m_cameraFollow != null) {
                m_cameraFollow.OnCameraMove += OnCameraMove;
            }
            m_cameraLastPos = Camera.main.transform.position;
        }

        void Update()
        {

        }

        private void OnCameraMove(Vector3 cameraPos) {
            float deltaY = cameraPos.y - m_cameraLastPos.y;
            transform.Translate(new Vector3(0, m_parallaxScale * deltaY, 0));
            m_cameraLastPos = cameraPos;
        }
    }
}
