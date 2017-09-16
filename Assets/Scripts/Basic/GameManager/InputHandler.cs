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


            //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            //{
            //    if (OnLeftClicked != null)
            //    {
            //        JumpChick.ChickController.Instance.OnStopMoveHorizontal();
            //    }
            //}
        }
    }
}
