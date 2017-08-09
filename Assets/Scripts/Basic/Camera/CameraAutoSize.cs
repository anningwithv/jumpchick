using UnityEngine;
using System.Collections;

namespace PlatformBasic
{
    public class CameraAutoSize : MonoBehaviour
    {
        public static float sCameraSize = 0;

        private float m_cameraWidth;

        void Awake()
        {
            SetCameraSize();
        }

        private void SetCameraSize()
        {
            m_cameraWidth = 6.4f / (1136f/640f);
            //float cameraSize = GetComponent<Camera>().orthographicSize;
            float aspectRatio = (float)Screen.width / (float)Screen.height;

            float cameraHeight = m_cameraWidth / aspectRatio;
            GetComponent<Camera>().orthographicSize = cameraHeight;
            sCameraSize = cameraHeight;

            //Debug.Log ("set camera size");
        }
    }
}
