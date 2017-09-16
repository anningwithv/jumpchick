using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;

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
                m_score.text = DataHelper.GetScore().ToString();
                GetComponent<RectTransform>().DOMoveY(-1245, 1.0f).SetRelative();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        public void Show()
        {
            Show(true);
        }

        public void Hide()
        {
            Show(false);
        }
    }
}
