using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformBasic
{
    public class InputHandler : MonoBehaviour
    {

        public System.Action OnMousePressed = null;
        public System.Action OnMouseReleased = null;

        public System.Action OnLeftClicked = null;
        public System.Action OnRightClicked = null;

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (OnMousePressed != null)
                {
                    OnMousePressed.Invoke();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (OnMouseReleased != null)
                {
                    OnMouseReleased.Invoke();
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (OnLeftClicked != null)
                {
                    OnLeftClicked.Invoke();
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (OnRightClicked != null)
                {
                    OnRightClicked.Invoke();
                }
            }
        }
    }
}
