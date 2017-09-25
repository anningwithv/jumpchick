/*
 * FileName:     MenuPanel 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace JumpChick
{
	public class MenuPanel : MonoBehaviour
	{
        public Image m_fadeImage = null;
        public Text m_insertCoinText = null;

        private bool m_isLoading = false;
        private bool m_isLoadDone = false;

        private LoadSceneAsync m_loadScene = null;

        void Start () 
		{
            m_loadScene = GetComponent<LoadSceneAsync>();

            Sequence seq = DOTween.Sequence();
            seq.Append(m_insertCoinText.DOFade(0f, 0.5f));
            seq.Append(m_insertCoinText.DOFade(1f, 0.5f));
            seq.SetLoops(-1);
        }

        void Update () 
		{
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        FadeAndLoad();
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    FadeAndLoad();
                }
            }

            if (m_isLoadDone && m_loadScene.IsSceneReady())
            {
                m_loadScene.EnterGame();
            }
		}

        private void FadeAndLoad()
        {
            if (m_isLoading)
                return;

            m_isLoading = true;

            m_loadScene.StartLoadGame();

            m_fadeImage.DOFade(1.0f, 1.0f).OnComplete(() =>
            {
                m_isLoadDone = true;
            });
        }
	}

}
