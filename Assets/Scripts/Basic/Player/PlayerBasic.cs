using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformBasic
{
    public class PlayerBasic : MonoBehaviour
    {
        protected Rigidbody2D m_rgd = null;

        protected virtual void Start()
        {
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

        }

        //private void RegisterColliderListener()
        //{
        //    m_playerColliderCheck.OnColldierDown += OnColliderDown;
        //    m_playerColliderCheck.OnColliderUp += OnColliderUp;
        //    m_playerColliderCheck.OnColliderLeft += OnColliderLeft;
        //    m_playerColliderCheck.OnColliderRight += OnColliderRight;
        //}

        public virtual void OnPlayerPressed()
        {
        }

        public virtual void OnPlayerReleased()
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
