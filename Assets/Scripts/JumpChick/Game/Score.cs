using UnityEngine;
using System.Collections;
using PlatformBasic;
using UnityEngine.UI;

namespace JumpChick
{
    public class Score : MonoBehaviour
    {
        public Text m_scoreText = null;

        private float m_score = 0;

        private float m_scoreIncressSpd = 10f;

        void Start()
        {
            GameBasic._game.OnGameFailed += OnGameOver;
        }

        void Update()
        {
            if (!GameBasic._game.IsRuning())
                return;

            UpdateScore();
        }

        private void UpdateScore()
        {
            m_score += m_scoreIncressSpd * Time.deltaTime;
            m_scoreText.text = "SCORE:" + GetScore();
        }

        private void OnGameOver()
        {
            DataHelper.SaveScore((int)m_score);

            Debug.Log("score -- on game over");
        }

        public int GetScore()
        {
            return (int)m_score;
        }

        public void AddScore(float score)
        {
            m_score += score;
        }
    }
}
