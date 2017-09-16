﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformBasic;
using DG.Tweening;

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
            Fall,
            FallSlow,
            Dead
        }

        private bool m_isFallingSlow = false;

        private float m_jumpForceY = 20f;
        private float m_jumpForceX = 10f;
        private float m_speedY = 0f;
        private float m_maxFallSpeedY = -7f;
        private float m_maxFallSlowSpeedY = -2f;
        private float m_deltaSpeedY = 12f;
        private float m_speedX = 0f;
        private float m_maxSpeedX = 6f;
        private float m_moveRangeX = 2.6f;

        private Animator m_anim = null;

        private State m_state;
        public State state
        {
            get { return m_state; }
            set { m_state = value; }
        }

        public static ChickController Instance = null;

        private void Awake()
        {
            Instance = this;
        }

        protected override void Start()
        {
            base.Start();
            Init();
        }

        private void Init()
        {
            state = State.Idle;

            m_anim = GetComponent<Animator>();

            RegisterListener();
        }

        private void RegisterListener()
        {
            var input = FindObjectOfType<InputHandler>();
            input.OnLeftClicked += OnMoveLeft;
            input.OnRightClicked += OnMoveRight;

            var health = GetComponent<PlayerHealth>();
            health.OnDead += OnPlayerDead;
        }

        private void OnPlayerDead()
        {
            if (state != State.Dead)
            {
                state = State.Dead;
                transform.DOMoveY(4f, 1.0f).SetRelative();
                transform.DOScale(2.0f, 1.0f);
            }

        }

        private void Update()
        {
            if (!GameController._instance.IsRuning())
                return;

            UpdateSpeed();
        }

        void LateUpdate()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            transform.Translate(new Vector3(m_speedX * Time.deltaTime, m_speedY * Time.deltaTime, 0), Space.World);
        }

        private void UpdateSpeed()
        {
            // update spped y
            if (m_isFallingSlow)
            {
                if (m_speedY < m_maxFallSlowSpeedY) {
                    m_speedY += Time.deltaTime * m_deltaSpeedY;
                }
            }
            else
            {
                if (m_speedY > m_maxFallSpeedY)
                {
                    m_speedY -= Time.deltaTime * m_deltaSpeedY;
                }
            }

            //if (m_speedY < targetSpd)
            //{
            //    m_speedY += Time.deltaTime * m_deltaSpeedY;
            //    m_speedY = targetSpd;
            //}

            // update speed X
            if (transform.position.x <= -m_moveRangeX && m_speedX < 0) {
                m_speedX = 0;
            }
            if (transform.position.x >= m_moveRangeX && m_speedX > 0)
            {
                m_speedX = 0;
            }
        }

        void FixedUpdate()
        {

        }

        public override void OnPlayerPressed()
        {
            m_isFallingSlow = true;
            ShowSlowEffect(m_isFallingSlow);
            m_anim.SetBool("FallSlow", true);
            Debug.Log("Player pressed. jump");
        }

        public override void OnPlayerReleased()
        {
            m_isFallingSlow = false;
            ShowSlowEffect(m_isFallingSlow);
            m_anim.SetBool("FallSlow", false);
            //Debug.Log("Player relesed. stop jump");
        }

        public void OnMoveLeft()
        {
            m_speedX = -m_maxSpeedX;
        }

        public void OnMoveRight()
        {
            m_speedX = m_maxSpeedX;
        }

        public void OnStopMoveHorizontal()
        {
            m_speedX = 0;
        }

        private void ShowSlowEffect(bool show)
        {
            if (show)
            {
                //transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 0.2f);
            }
            else {
                //transform.DOScale(new Vector3(1.0f, 1.0f, 1f), 0.2f);
            }
        }
        //protected override void OnColliderDown()
        //{
        //    m_speedY = m_maxSpeedY;
        //}

        //protected override void OnColliderUp()
        //{
        //    m_speedY = -m_maxSpeedY;
        //}

        //protected override void OnColliderLeft()
        //{
        //    if (m_jumpDir == JumpDir.Left)
        //    {
        //        m_jumpDir = JumpDir.Right;
        //        m_speedX = m_maxSpeedX;
        //    }
        //}

        //protected override void OnColliderRight()
        //{
        //    if (m_jumpDir == JumpDir.Right)
        //    {
        //        m_jumpDir = JumpDir.Left;
        //        m_speedX = -m_maxSpeedX;
        //    }
        //}
    }
}
