using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformBasic;

namespace JumpChick
{
    public class ChickController : PlayerBasic
    {

        public enum JumpDir
        {
            Left,
            Right,
            Center
        }

        public enum ColliderDir
        {
            None,
            Left,
            Right,
            Up,
            Down
        }

        public enum State
        {
            Idle,
            Jump,
            Fall,
            Dead
        }

        private bool m_isJumping = false;

        //private float m_jumpForceY = 20f;
        //private float m_jumpForceX = 10f;
        private float m_speedY = 0f;
        private float m_maxSpeedY = 8f;
        private float m_deltaSpeedY = 12f;
        private float m_speedX = 0f;
        private float m_maxSpeedX = 4f;

        private JumpDir m_jumpDir = JumpDir.Right;

        private State m_state;
        public State state
        {
            get { return m_state; }
            set { m_state = value; }
        }

        protected override void Start()
        {
            base.Start();
            Init();
        }

        private void Init()
        {
            state = State.Idle;
        }


        void LateUpdate()
        {
            if (m_isJumping)
            {
                state = State.Jump;
                if (m_speedY < 0f)
                {
                    m_speedY = 0f;
                }
                UpdateSpeedY(1f);
                if (m_speedX == 0f)
                {
                    m_speedX = m_maxSpeedX;
                }
            }
            else
            {
                state = State.Fall;
                UpdateSpeedY(-1f);
            }

            UpdatePosition();
        }

        private void UpdatePosition()
        {
            transform.Translate(new Vector3(m_speedX * Time.deltaTime, m_speedY * Time.deltaTime, 0), Space.World);
        }

        private void UpdateSpeedY(float dir)
        {
            m_speedY += dir * m_deltaSpeedY * Time.deltaTime;
            m_speedY = Mathf.Clamp(m_speedY, -m_maxSpeedY, m_maxSpeedY);
        }

        void FixedUpdate()
        {
 
        }

        protected override void OnPlayerPressed()
        {
            m_isJumping = true;
            Debug.Log("Player pressed. jump");
        }

        protected override void OnPlayerReleased()
        {
            m_isJumping = false;
            Debug.Log("Player relesed. stop jump");
        }

        protected override void OnColliderDown()
        {
            m_speedY = m_maxSpeedY;
        }

        protected override void OnColliderUp()
        {
            m_speedY = -m_maxSpeedY;
        }

        protected override void OnColliderLeft()
        {
            if (m_jumpDir == JumpDir.Left)
            {
                m_jumpDir = JumpDir.Right;
                m_speedX = m_maxSpeedX;
            }
        }

        protected override void OnColliderRight()
        {
            if (m_jumpDir == JumpDir.Right)
            {
                m_jumpDir = JumpDir.Left;
                m_speedX = -m_maxSpeedX;
            }
        }
    }
}
