using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformBasic;

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

        private Transform m_target = null;

        void Start()
        {
            m_target = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
        }

        void Update()
        {
            if (m_end.position.y - m_target.position.y > 30)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }

        public float GetEndPos()
        {
            return m_end.position.y;
        }
    }
}
