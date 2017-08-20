using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformBasic
{
    public class GameConfig
    {
        public enum MoveDir
        {
            Up = 0,
            Down = 1
        }

        public static MoveDir _moveDir = MoveDir.Down;
    }
}
