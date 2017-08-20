using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformBasic;

namespace JumpChick
{
    public class GameController : GameBasic
    {
        public static GameController _instance = null;

        [HideInInspector]public GameObject m_player = null;

        protected override void Awake()
        {
            base.Awake();

            if (_instance == null)
                _instance = this;
        }

        protected override void Start()
        {
            base.Start();

            State = GameState.Runing;

            RegisterListener();
        }

        private void RegisterListener()
        {
            m_player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
            if (m_player != null)
            {
                PlayerHealth ph = m_player.GetComponent<PlayerHealth>();
                if (ph != null)
                {
                    ph.OnDead += OnPlayerDead;
                }
            }
            else
            {
                Debug.LogError("Can't find player");
            }

        }

        protected override void Update()
        {
            base.Update();
        }

        private void OnPlayerDead()
        {
            Debug.Log("Player is dead");
            State = GameState.Failed;
        }
    }
}
