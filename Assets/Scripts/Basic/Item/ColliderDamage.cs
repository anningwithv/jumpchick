using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformBasic
{
    public class ColliderDamage : MonoBehaviour
    {
        public float m_damage = 1f;

        private void Start()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerHealth>() != null)
            {
                collision.gameObject.GetComponent<PlayerHealth>().OnDamaged(m_damage);
            }
        }
    }
}
