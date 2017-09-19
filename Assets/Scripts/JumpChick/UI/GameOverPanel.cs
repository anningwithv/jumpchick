using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;
using PlatformBasic;

namespace JumpChick
{
    public class GameOverPanel : MonoBehaviour, IUIPanel
    {
        public Button m_restartBtn = null;
        public Text m_score = null;

        void Start()
        {
            m_restartBtn.onClick.AddListener(delegate ()
            {
                SceneManager.LoadScene("Game");
            });
        }

        void Update()
        {

        }

        public void Show(bool show)
        {
            if (show)
            {
                gameObject.SetActive(true);
                m_score.text = UIManager.Instance.m_gamePanel.m_score.GetScore().ToString();
                GetComponent<RectTransform>().DOLocalMoveY(0, 1.0f);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);

            Util.DoWithDelay(this, 1.0f, () => {
                Show(true);
            });
        }

        public void Hide()
        {
            Show(false);
        }
    }
}
