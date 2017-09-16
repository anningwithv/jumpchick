/*
 * FileName:     UIManager 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformBasic;

namespace JumpChick
{
    public class UIManager : MonoBehaviour
    {
        public enum PanelType
        {
            GamePanel,
            GameOverPanel
        }

        public GamePanel m_gamePanel = null;
        public GameOverPanel m_gameOverPanel = null;

        private Dictionary<PanelType, IUIPanel> m_panelList = new Dictionary<PanelType, IUIPanel>();

        public static UIManager Instance = null;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            GameBasic._game.OnGameFailed += OnGameOver;

            m_panelList.Add(PanelType.GamePanel, m_gamePanel);
            m_panelList.Add(PanelType.GameOverPanel, m_gameOverPanel);

            ShowPanel(PanelType.GamePanel);
        }

        void Update()
        {

        }

        private void OnGameOver()
        {
            ShowPanel(PanelType.GameOverPanel);
        }

        public void ShowPanel(PanelType type)
        {
            foreach (var go in m_panelList)
            {
                if (go.Key == type)
                {
                    go.Value.Show();
                }
                else {
                    go.Value.Hide();
                }
            }
        }
	}

}
