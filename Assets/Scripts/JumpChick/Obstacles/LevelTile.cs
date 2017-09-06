using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpChick
{
    public class LevelTile : MonoBehaviour
    {
        public enum LevelType
        {
            Easy,
            Normal,
            Hard
        }

        public Transform m_start = null;
        public Transform m_end = null;
        public LevelType m_type = LevelType.Easy;

        void Start()
        {

        }

        void Update()
        {

        }

        public float GetEndPos()
        {
            return m_end.position.y;
        }
    }
}
