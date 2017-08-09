using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformBasic;

namespace JumpChick
{
    public class GameController : GameBasic
    {
        public static GameController _instance = null;

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
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
