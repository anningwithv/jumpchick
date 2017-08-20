using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpChick
{
    [ExecuteInEditMode]
    public class BladeManager : MonoBehaviour
    {
        public bool m_isLeftBladeEnabled = true;
        public bool m_isRightBladeEnabled = true;
        public bool m_isTopBladeEnabled = true;
        public bool m_isBottomBladeEnabled = true;

        public List<GameObject> m_leftBlades = new List<GameObject>();
        public List<GameObject> m_rightBlades = new List<GameObject>();
        public List<GameObject> m_topBlades = new List<GameObject>();
        public List<GameObject> m_bottomBlades = new List<GameObject>();

        void Start()
        {
            if (!m_isLeftBladeEnabled) {
                foreach (GameObject obj in m_leftBlades)
                {
                    obj.SetActive(false);
                }
            }

            if (!m_isRightBladeEnabled)
            {
                foreach (GameObject obj in m_rightBlades)
                {
                    obj.SetActive(false);
                }
            }

            if (!m_isTopBladeEnabled)
            {
                foreach (GameObject obj in m_topBlades)
                {
                    obj.SetActive(false);
                }
            }

            if (!m_isBottomBladeEnabled)
            {
                foreach (GameObject obj in m_bottomBlades)
                {
                    obj.SetActive(false);
                }
            }
        }

        void Update()
        {

        }
    }
}
