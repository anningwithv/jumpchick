using UnityEngine;
using System.Collections;
using PlatformBasic;

namespace JumpChick
{
    public class Score : MonoBehaviour
    {
        private float m_score = 0;
        [HideInInspector]
        public float m_scoreScale = 0.5f;
        [HideInInspector]
        public float m_chargeNum = 0f;
        [HideInInspector]
        public float m_maxChargeNum = 10.0f;

        private int m_diamondNum = 0;
        private int m_comboNum = 0;

        private GameObject m_player = null;
        private float m_playerMaxY;

        private float m_playerGlideRemoveChargeSpeed = 4.0f;

        void Start()
        {
            m_player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
            m_playerMaxY = m_player.transform.position.y;

            //m_diamondNum = DataHelper.getDiamond ();
            GameBasic._game.OnGameFailed += OnGameOver;
        }

        void Update()
        {
            if (!GameBasic._game.IsRuning())
                return;

            UpdateScore();
            UpdateScoreScale();
            UpdateChargeNum();
        }

        private void UpdateScore()
        {
            if (m_player.transform.position.y > m_playerMaxY)
            {
                m_score += (m_player.transform.position.y - m_playerMaxY) * m_scoreScale;
                m_playerMaxY = m_player.transform.position.y;
            }
        }

        private void OnGameOver()
        {
            DataHelper.SaveScore((int)m_score);
            DataHelper.SaveDiamond(m_diamondNum);

            //LeaderboardManager.ReportScore (DataHelper.getScore ());
            Debug.Log("score -- on game over");
        }

        public int GetScore()
        {
            return (int)m_score;
        }

        public int GetComboNum()
        {
            return m_comboNum;
        }

        public int GetDiamond()
        {
            return m_diamondNum;
        }

        public float GetChargeScale()
        {
            return m_chargeNum / m_maxChargeNum;
        }

        private void UpdateChargeNum()
        {
            if (m_scoreScale <= 1.0f)
                m_chargeNum -= Time.deltaTime * 0.5f;
            else if (m_scoreScale > 1.0f && m_scoreScale <= 2.0f)
                m_chargeNum -= Time.deltaTime * 1.5f;
            else
                m_chargeNum -= Time.deltaTime * 3.0f;

            if (m_chargeNum < 0)
            {
                m_chargeNum = 0;
            }
        }

        private void UpdateScoreScale()
        {
            m_scoreScale = (int)(m_chargeNum / m_maxChargeNum) + 1;
        }

        public void AddComboNum()
        {
            m_comboNum += 1;
        }

        public void ClearComboNum()
        {
            m_comboNum = 0;
        }

        public void addChargeNum(float num)
        {
            m_chargeNum += num;
            if (m_chargeNum > 3 * m_maxChargeNum)
            {
                m_chargeNum = 3 * m_maxChargeNum;
            }
            if (m_chargeNum < 0)
                m_chargeNum = 0;
        }

        public void AddDiamond(int num)
        {
            m_diamondNum += num;
            DataHelper.SaveDiamond(m_diamondNum);
        }
    }
}
