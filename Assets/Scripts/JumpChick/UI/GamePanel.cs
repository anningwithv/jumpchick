/*
 * FileName:     GamePanel 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlatformBasic;

namespace JumpChick
{
	public class GamePanel : MonoBehaviour,IUIPanel
	{
        public Score m_score = null;
        public ButtonPressCheck m_leftBtn = null;
        public ButtonPressCheck m_rightBtn = null;
        public ButtonPressCheck m_speedDownBtn = null;
        public Button m_leftBtn1 = null;
        public Button m_rightBtn1 = null;
        public List<GameObject> m_heartList = new List<GameObject>();

        public Image m_powerProgress = null;

        private float m_maxPower = 30f;
        private float m_curPoswer = 0f;
        private bool m_isIncreasingPower = false;
        private float m_powerUsedSpd = 10f;

        private PlayerHealth m_playerHealth = null;

        void Start () 
		{
            m_leftBtn.OnPressDown += LeftBtnDown;
            m_leftBtn.OnPressUp += LeftBtnUp;

            m_rightBtn.OnPressDown += RightBtnDown;
            m_rightBtn.OnPressUp += RightBtnUp;

            m_playerHealth = FindObjectOfType<PlayerHealth>();
            m_playerHealth.OnHurt += SetHeartImage;
            m_playerHealth.OnDead += SetHeartImage;

            SetHeartImage();
        }

        private void SetHeartImage()
        {
            int health = (int)m_playerHealth.HP;
            for (int i = 0; i < m_heartList.Count; i++)
            {
                if (i + 1 > health)
                {
                    m_heartList[i].SetActive(false);
                }
            }
        }

		void Update () 
		{
            if (m_isIncreasingPower)
            {
                m_curPoswer += m_powerUsedSpd * Time.deltaTime;
                m_curPoswer = Mathf.Clamp(m_curPoswer, 0, m_maxPower);
                UpdatePowerProgress();
            }
        }

        //private void LeftBtnDown()
        //{
        //    if (m_rightBtn.m_isPressedDown)
        //    {
        //        SpeedDownBtnDown();
        //        return;
        //    }
        //    ChickController.Instance.OnMoveLeft();
        //}

        //private void LeftBtnUp()
        //{
        //    if (m_isUsingPower && m_rightBtn.m_isPressedDown)
        //    {
        //        Util.DoWithDelay(this, 0.1f, () =>
        //        {
        //            if (m_rightBtn.m_isPressedDown)
        //            {
        //                ChickController.Instance.OnMoveRight();
        //            }
        //        });
        //    }

        //    SpeedDownBtnUp();
        //}

        //private void RightBtnDown()
        //{
        //    if (m_leftBtn.m_isPressedDown)
        //    {
        //        SpeedDownBtnDown();
        //        return;
        //    }

        //    ChickController.Instance.OnMoveRight();
        //}

        //private void RightBtnUp()
        //{
        //    if (m_isUsingPower && m_leftBtn.m_isPressedDown)
        //    {
        //        Util.DoWithDelay(this, 0.1f, () =>
        //        {
        //            if (m_leftBtn.m_isPressedDown)
        //            {
        //                ChickController.Instance.OnMoveLeft();
        //            }
        //        });
        //    }

        //    SpeedDownBtnUp();
        //    //ChickController.Instance.OnStopMoveHorizontal();
        //}

        //private void SpeedDownBtnDown()
        //{
        //    if (!CanUsePower())
        //    {
        //        return;
        //    }

        //    m_isUsingPower = true;
        //    ChickController.Instance.OnStopMoveHorizontal();
        //    ChickController.Instance.OnPlayerPressed();
        //}

        //private void SpeedDownBtnUp()
        //{
        //    if (m_isUsingPower)
        //    {
        //        m_isUsingPower = false;
        //        ChickController.Instance.OnPlayerReleased();
        //    }
        //}

        private void LeftBtnDown()
        {
            if (m_rightBtn.m_isPressedDown)
            {
                SpeedDownBtnDown();
                return;
            }
            ChickController.Instance.OnMoveLeft();
        }

        private void LeftBtnUp()
        {
            if (m_isIncreasingPower && m_rightBtn.m_isPressedDown)
            {
                Util.DoWithDelay(this, 0.1f, () =>
                {
                    if (m_rightBtn.m_isPressedDown)
                    {
                        ChickController.Instance.OnMoveRight();
                    }
                });

                SpeedDownBtnUp();
            }
            else {
                ChickController.Instance.OnStopMoveHorizontal();
            }
        }

        private void RightBtnDown()
        {
            if (m_leftBtn.m_isPressedDown)
            {
                SpeedDownBtnDown();
                return;
            }

            ChickController.Instance.OnMoveRight();
        }

        private void RightBtnUp()
        {
            if (m_isIncreasingPower && m_leftBtn.m_isPressedDown)
            {
                Util.DoWithDelay(this, 0.1f, () =>
                {
                    if (m_leftBtn.m_isPressedDown)
                    {
                        ChickController.Instance.OnMoveLeft();
                    }
                });

                SpeedDownBtnUp();
            }
            else
            {
                ChickController.Instance.OnStopMoveHorizontal();
            }
        }

        private void SpeedDownBtnDown()
        {
            //if (!CanUsePower())
            //{
            //    return;
            //}

            m_isIncreasingPower = true;
            ChickController.Instance.OnStopMoveHorizontal();
            ChickController.Instance.OnFallFast();
        }

        private void SpeedDownBtnUp()
        {
            if (m_isIncreasingPower)
            {
                m_isIncreasingPower = false;
                ChickController.Instance.OnFallNormal();
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void OnGetFood(float power, float score)
        {
            // add power
            m_curPoswer += power;
            m_curPoswer = Mathf.Clamp(m_curPoswer, 0, m_maxPower);
            UpdatePowerProgress();

            // add score
            m_score.AddScore(score);
        }

        private void UpdatePowerProgress()
        {
            m_powerProgress.fillAmount = m_curPoswer / m_maxPower;
        }

        private bool CanUsePower()
        {
            return m_curPoswer > 0f;
        }
    }

}
