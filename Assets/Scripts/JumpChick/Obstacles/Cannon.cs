using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace JumpChick
{
    public class Cannon : MonoBehaviour
    {
        public GameObject m_missile = null;
        public Transform m_missilePos = null;
        public int m_dirction = 1;
        public float m_fireInterval = 1f;
        public float m_missileSpd = 1f;

        private bool m_startToFire = false;

        void Start()
        {
            ActiveWhenPlayerNear awpn = GetComponent<ActiveWhenPlayerNear>();
            awpn.OnPlayerNear += OnPlayerNear;
        }

        private void OnPlayerNear()
        {
            m_startToFire = true;

            StartCoroutine(Fire());
        }

        private IEnumerator Fire()
        {
            while (m_startToFire)
            {
                yield return new WaitForSeconds(m_fireInterval);
                SpawnMissile();
            }
        }

        private void SpawnMissile()
        {
            GameObject missile = GameObject.Instantiate(m_missile, m_missilePos.position, Quaternion.identity) as GameObject;
            missile.transform.DOMoveX(10f * m_dirction, 10f / m_missileSpd).SetRelative().OnComplete(
                () => {
                    Destroy(missile);
                }
            );
        }
    }
}
