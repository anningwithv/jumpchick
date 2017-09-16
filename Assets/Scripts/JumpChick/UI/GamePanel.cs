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

namespace JumpChick
{
	public class GamePanel : MonoBehaviour,IUIPanel
	{
        public Score m_score = null;
        public Button m_leftBtn = null;
        public Button m_rightBtn = null;
        public ButtonPressCheck m_speedDownBtn = null;
        public Image m_powerProgress = null;

        private float m_maxPower = 30f;
        private float m_curPoswer = 0f;
        private bool m_isUsingPower = false;
        private float m_powerUsedSpd = 10f;

        void Start () 
		{
            m_leftBtn.onClick.AddListener(delegate() {
                ChickController.Instance.OnMoveLeft();
            });

            m_rightBtn.onClick.AddListener(delegate () {
                ChickController.Instance.OnMoveRight();
            });

            m_speedDownBtn.OnPressDown += SpeedDownBtnDown;
            m_speedDownBtn.OnPressUp += SpeedDownBtnUp;

            m_curPoswer = m_maxPower;
        }
		
		void Update () 
		{
            if (m_isUsingPower)
            {
                m_curPoswer -= m_powerUsedSpd * Time.deltaTime;
                m_curPoswer = Mathf.Clamp(m_curPoswer, 0, m_maxPower);
                UpdatePowerProgress();
            }

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SpeedDownBtnDown();
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    SpeedDownBtnUp();
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    ChickController.Instance.OnMoveLeft();
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    ChickController.Instance.OnMoveRight();
                }
            }
        }

        private void SpeedDownBtnDown()
        {
            if (!CanUsePower())
            {
                return;
            }

            m_isUsingPower = true;
            ChickController.Instance.OnPlayerPressed();
        }

        private void SpeedDownBtnUp()
        {
            if (m_isUsingPower)
            {
                m_isUsingPower = false;
                ChickController.Instance.OnPlayerReleased();
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
