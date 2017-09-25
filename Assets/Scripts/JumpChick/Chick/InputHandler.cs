using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpChick
{
    public class InputHandler : MonoBehaviour
    {

        private float m_lastAcce = 0;

        void Start()
        {

        }

        void Update()
        {

            //if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            //{
            //    if (Input.acceleration.x <= 0)
            //    {
            //        //if(m_lastAcce > 0)
            //            JumpChick.ChickController.Instance.OnMoveLeft(Mathf.Abs(Input.acceleration.x));
            //    }
            //    else
            //    {
            //        //if (m_lastAcce <= 0)
            //            JumpChick.ChickController.Instance.OnMoveRight(Mathf.Abs(Input.acceleration.x));
            //    }
            //    m_lastAcce = Input.acceleration.x;

            //    if (Input.touchCount > 0)
            //    {
            //        if (Input.GetTouch(0).phase == TouchPhase.Began)
            //        {
            //            JumpChick.ChickController.Instance.OnPlayerPressed();
            //        }
            //        else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            //        {
            //            JumpChick.ChickController.Instance.OnPlayerReleased();
            //        }
            //    }
            //}
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    JumpChick.ChickController.Instance.OnFallFast();
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    JumpChick.ChickController.Instance.OnFallNormal();
                }

                if (Input.GetKey(KeyCode.A))
                {
                    ChickController.Instance.OnMoveLeft();
                }

                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                {
                    ChickController.Instance.OnStopMoveHorizontal();
                }

                if (Input.GetKey(KeyCode.D))
                {
                    ChickController.Instance.OnMoveRight();
                }
            }
        }
    }
}
