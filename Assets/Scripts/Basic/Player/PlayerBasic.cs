using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformBasic
{
    public class PlayerBasic : MonoBehaviour
    {
        protected InputHandler m_inputHandler = null;
        //protected PlayerColliderCheck m_playerColliderCheck = null;
        protected Rigidbody2D m_rgd = null;

        protected virtual void Start()
        {
            m_inputHandler = GetComponent<InputHandler>();
            //m_playerColliderCheck = GetComponent<PlayerColliderCheck>();
            m_rgd = GetComponent<Rigidbody2D>();

            RegisterInputListener();
            //RegisterColliderListener();
        }

        void Update()
        {

        }

        private void RegisterInputListener()
        {
            m_inputHandler.OnMousePressed += OnPlayerPressed;
            m_inputHandler.OnMouseReleased += OnPlayerReleased;
        }

        //private void RegisterColliderListener()
        //{
        //    m_playerColliderCheck.OnColldierDown += OnColliderDown;
        //    m_playerColliderCheck.OnColliderUp += OnColliderUp;
        //    m_playerColliderCheck.OnColliderLeft += OnColliderLeft;
        //    m_playerColliderCheck.OnColliderRight += OnColliderRight;
        //}

        protected virtual void OnPlayerPressed()
        {
        }

        protected virtual void OnPlayerReleased()
        {
        }

        //protected virtual void OnColliderDown()
        //{
        //}

        //protected virtual void OnColliderUp()
        //{
        //}

        //protected virtual void OnColliderLeft()
        //{
        //}

        //protected virtual void OnColliderRight()
        //{
        //}
    }
}
