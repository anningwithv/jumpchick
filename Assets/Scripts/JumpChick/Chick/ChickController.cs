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

        private bool m_isFallingFast = false;
        [HideInInspector]
        public bool m_isHurt = false;

        private float m_jumpForceY = 20f;
        private float m_jumpForceX = 10f;
        private float m_speedY = 0f;
        private float m_maxFallSpeedY = -6f;
        private float m_maxFallSlowSpeedY = -12f;
        private float m_deltaSpeedY = 12f;
        private float m_speedX = 0f;
        private float m_maxSpeedX = 6.5f;
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
            var health = GetComponent<PlayerHealth>();
            health.OnDead += OnPlayerDead;
            health.OnHurt += OnHurt;
        }

        private void OnPlayerDead()
        {
            if (state != State.Dead)
            {
                state = State.Dead;

                m_anim.SetBool("IsDead", true);

                transform.DOMoveY(4f, 1.0f).SetRelative();
                transform.DOScale(2.0f, 1.0f);

                AudioManager.Instance.PlayDeadSound();
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
            if (m_isHurt)
            {
                m_speedY = 0f;
                m_speedX = 0f;
                return;
            }

            // update spped y
            if (m_isFallingFast)
            {
                if (m_speedY > m_maxFallSlowSpeedY) {
                    m_speedY -= Time.deltaTime * m_deltaSpeedY;
                }
                else if (m_speedY < m_maxFallSlowSpeedY)
                {
                    m_speedY += Time.deltaTime * m_deltaSpeedY;
                }
            }
            else
            {
                if (m_speedY > m_maxFallSpeedY)
                {
                    m_speedY -= Time.deltaTime * m_deltaSpeedY;
                }
                else if (m_speedY < m_maxFallSpeedY)
                {
                    m_speedY += Time.deltaTime * m_deltaSpeedY;
                }
            }

            // update speed X
            if (transform.position.x <= -m_moveRangeX && m_speedX < 0) {
                m_speedX = 0;
            }
            if (transform.position.x >= m_moveRangeX && m_speedX > 0)
            {
                m_speedX = 0;
            }
        }

        private bool IsInRangeLeft()
        {
            return transform.position.x > -m_moveRangeX;
        }

        private bool IsInRangeRight()
        {
            return transform.position.x < m_moveRangeX;
        }

        void FixedUpdate()
        {

        }

        private void OnHurt()
        {
            m_isHurt = true;
            m_isFallingFast = false;

            //m_anim.SetBool("IsHurt", m_isHurt);

            Util.DoWithDelay(this, 0.5f, () =>
            {
                m_isHurt = false;
                //m_anim.SetBool("IsHurt", m_isHurt);
            });

            Sequence seq = DOTween.Sequence();
            seq.Append(transform.DOScale(0.7f, 0.1f));
            seq.Append(transform.DOScale(1.0f, 0.1f));
            seq.SetLoops(2);
        }

        private Sequence seq = null;
        private void ShowScaleEffect(bool show)
        {
            if (show)
            {
                seq = DOTween.Sequence();
                seq.Append(transform.DOScale(0.95f, 0.05f));
                seq.Append(transform.DOScale(1.0f, 0.05f));
                seq.SetLoops(-1);
            }
            else
            {
                DOTween.Kill(seq);
            }
        }

        public void OnFallFast()
        {
            m_isFallingFast = true;
            ShowScaleEffect(m_isFallingFast);
            m_anim.SetBool("FallSlow", true);
            Debug.Log("Player pressed. jump");
        }

        public void OnFallNormal()
        {
            m_isFallingFast = false;
            ShowScaleEffect(m_isFallingFast);
            m_anim.SetBool("FallSlow", false);
            //transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            //Debug.Log("Player relesed. stop jump");
        }

        public bool IsMovingLeft()
        {
            return m_speedX < 0 || (m_speedX ==0 && transform.position.x <= -m_moveRangeX);
        }

        public void OnMoveLeft()
        {
            if (IsInRangeLeft())
            {
                m_speedX = -m_maxSpeedX;

                //AudioManager.Instance.PlayMoveSound();
            }
        }

        public void OnMoveRight()
        {
            if (IsInRangeRight())
            {
                m_speedX = m_maxSpeedX;
                //AudioManager.Instance.PlayMoveSound();
            }
        }

        public void OnStopMoveHorizontal()
        {
            m_speedX = 0;
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
