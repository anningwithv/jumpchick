using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace PlatformBasic
{
    public class PlayerHealth : MonoBehaviour
    {
        public UnityAction OnDead = null;
        public UnityAction OnHurt = null;

        private float m_hp = 1f;
        private float m_maxHp = 4f;
        private bool m_canBeHurt = true;

        public float HP
        {
            get { return m_hp; }
            set {
                m_hp = Mathf.Clamp(value, 0, m_maxHp);
            }
        }

        void Start()
        {
            m_hp = m_maxHp;
        }

        void Update()
        {

        }

        public void OnDamaged(float damage)
        {
            if (m_canBeHurt == false)
                return;

            HP -= damage;

            if (HP <= 0)
            {
                if (OnDead != null)
                {
                    OnDead.Invoke();
                }
            }
            else
            {
                if (OnHurt != null)
                {
                    OnHurt.Invoke();
                }
            }

            m_canBeHurt = false;
            Util.DoWithDelay(this, 1.0f, () =>
            {
                m_canBeHurt = true;
            });
        }

        public void OnHealed(float hp)
        {
            HP += hp;
        }

        private void ShowTintEffect()
        {
           
        }

    }
}
