using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlatformBasic
{
    public class PlayerHealth : MonoBehaviour
    {
        public UnityAction OnDead = null;

        private float m_hp = 1f;
        private float m_maxHp = 1f;

        public float HP
        {
            get { return m_hp; }
            set {
                m_hp = Mathf.Clamp(value, 0, m_maxHp);
            }
        }

        void Start()
        {

        }

        void Update()
        {

        }

        public void OnDamaged(float damage) {
            HP -= damage;
            if (HP <= 0) {
                if (OnDead != null) {
                    OnDead.Invoke();
                }
            }
        }

        public void OnHealed(float hp) {
            HP += hp;
        }
    }
}
