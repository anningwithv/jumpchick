using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformBasic
{
    public class GameBasic : MonoBehaviour
    {
        public enum GameState
        {
            Init = 0,
            Runing = 1,
            Paused = 2,
            Successed = 3,
            Failed = 4
        }

        public static GameBasic _game = null;

        [HideInInspector] public System.Action OnGameStart = null;
        [HideInInspector] public System.Action OnGamePaused = null;
        [HideInInspector] public System.Action OnGameResumed = null;
        [HideInInspector] public System.Action OnGameSucceed = null;
        [HideInInspector] public System.Action OnGameFailed = null;

        protected GameState m_state = GameState.Init;
        public GameState State
        {
            get { return m_state; }
            set {
                switch (value) {
                    case GameState.Init:
                        break;
                    case GameState.Runing:
                        if (m_state != GameState.Runing) {
                            if (m_state == GameState.Init)
                            {
                                if (OnGameStart != null) {
                                    Debug.Log("On game run");
                                    OnGameStart.Invoke();
                                }
                            }else if (m_state == GameState.Paused) {
                                if (OnGameResumed != null)
                                {
                                    Debug.Log("On game paused");
                                    OnGameResumed.Invoke();
                                }
                            }
                        }
                        break;
                    case GameState.Paused:
                        if (m_state != GameState.Paused)
                        {
                            if (m_state == GameState.Runing)
                            {
                                if (OnGamePaused != null)
                                {
                                    Debug.Log("On game paused");
                                    OnGamePaused.Invoke();
                                }
                            }
                        }
                        break;
                    case GameState.Successed:
                        if (m_state != GameState.Successed)
                        {
                            if (m_state == GameState.Runing)
                            {
                                if (OnGameSucceed != null)
                                {
                                    Debug.Log("On game succeed");
                                    OnGameSucceed.Invoke();
                                }
                            }
                        }
                        break;
                    case GameState.Failed:
                        if (m_state != GameState.Failed)
                        {
                            if (m_state == GameState.Runing)
                            {
                                if (OnGameFailed != null)
                                {
                                    Debug.Log("On game failed");
                                    OnGameFailed.Invoke();
                                }
                            }
                        }
                        break;
                  
                }
                m_state = value;
            }
        }

        protected virtual void Awake()
        {
            if (_game == null) {
                _game = this;
            }
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {

        }

        public bool IsRuning()
        {
            return m_state == GameState.Runing;
        }

        public bool IsPaused()
        {
            return m_state == GameState.Paused;
        }
    }
}
