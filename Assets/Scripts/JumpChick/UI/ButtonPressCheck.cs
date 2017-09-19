/*
 * FileName:     ButtonPressCheck 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace JumpChick
{
	public class ButtonPressCheck : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [HideInInspector]
        public bool m_isPressedDown = false;

        [HideInInspector]
        public bool m_isLongPressed = false;

        public System.Action OnPressDown = null;
        public System.Action OnPressUp = null;

        void Start()
        {

        }

        void Update()
        {

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Btn " + transform.name + " is pressed down");
            m_isPressedDown = true;

            if (OnPressDown != null)
            {
                OnPressDown.Invoke();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("Btn " + transform.name + " is pressed up");
            m_isPressedDown = false;

            if (OnPressUp != null)
            {
                OnPressUp.Invoke();
            }
        }

	}

}
