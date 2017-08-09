using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformBasic
{ 
    public class PlayerColliderCheck : MonoBehaviour {

        [HideInInspector]public System.Action OnColliderLeft = null;
        [HideInInspector] public System.Action OnColliderRight = null;
        [HideInInspector] public System.Action OnColliderUp = null;
        [HideInInspector] public System.Action OnColldierDown = null;

        private Vector2 m_top1, m_top2, m_bottom1, m_bottom2,
            m_left1, m_left2, m_left3, m_right1, m_right2, m_right3;

        private BoxCollider2D m_collider2D = null;
        private float m_boudaryScale = 0.9f;

        private string m_checkColliderLayerName = "Brick";

        void Start() {
            m_collider2D = GetComponent<BoxCollider2D>();
            SetBoundary();
        }

        void Update() {

        }

        void FixedUpdate()
        {
            CheckCollider();
        }

        private void SetBoundary()
        {
            Vector2 center = new Vector2(transform.position.x, transform.position.y) + m_collider2D.offset;
            float width = m_collider2D.size.x * m_boudaryScale;
            float height = m_collider2D.size.y * m_boudaryScale;

            float marginX = width / 10f;
            float marginY = height / 10f;
            m_top1 = center + new Vector2(-width / 2f + marginX, height / 2f);
            m_top2 = center + new Vector2(width / 2f - marginX, height / 2f);
            m_bottom1 = center + new Vector2(-width / 2f + marginX, -height / 2f);
            m_bottom2 = center + new Vector2(width / 2f - marginX, -height / 2f);
            m_left1 = center + new Vector2(-width / 2f, height / 2f - marginY);
            m_left2 = center + new Vector2(-width / 2f, 0);
            m_left3 = center + new Vector2(-width / 2f, -height / 2f + marginY);
            m_right1 = center + new Vector2(width / 2f, height / 2f - marginY);
            m_right2 = center + new Vector2(width / 2f, 0);
            m_right3 = center + new Vector2(width / 2f, -height / 2f + marginY);
        }

        private void CheckCollider()
        {
            SetBoundary();

            float distanceX = m_collider2D.size.x * (1 - m_boudaryScale);
            float distanceY = m_collider2D.size.y * (1 - m_boudaryScale);

            RaycastHit2D hitBottom1 = Physics2D.Raycast(m_bottom1, Vector2.down, distanceY, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
            RaycastHit2D hitBottom2 = Physics2D.Raycast(m_bottom2, Vector2.down, distanceY, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
            if (hitBottom1.collider != null || hitBottom2.collider != null)
            {
                //Debug.Log("Collider down");
                if (OnColldierDown != null) {
                    OnColldierDown.Invoke();
                }
            }

            RaycastHit2D hitUp1 = Physics2D.Raycast(m_top1, Vector2.up, distanceY, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
            RaycastHit2D hitUp2 = Physics2D.Raycast(m_top2, Vector2.up, distanceY, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
            if (hitUp1.collider != null || hitUp2.collider != null)
            {
                //Debug.Log("Collider up");
                if (OnColliderUp != null)
                {
                    OnColliderUp.Invoke();
                }
            }

            RaycastHit2D hitLeft1 = Physics2D.Raycast(m_left1, Vector2.left, distanceX, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
            RaycastHit2D hitLeft2 = Physics2D.Raycast(m_left2, Vector2.left, distanceX, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
            RaycastHit2D hitLeft3 = Physics2D.Raycast(m_left3, Vector2.left, distanceX, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
            if (hitLeft1.collider != null || hitLeft2.collider != null || hitLeft3.collider != null)
            {
                //Debug.Log("Collider left");
                if (OnColliderLeft != null)
                {
                    OnColliderLeft.Invoke();
                }
            }

            RaycastHit2D hitRight1 = Physics2D.Raycast(m_right1, Vector2.right, distanceX, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
            RaycastHit2D hitRight2 = Physics2D.Raycast(m_right2, Vector2.right, distanceX, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
            RaycastHit2D hitRight3 = Physics2D.Raycast(m_right2, Vector2.right, distanceX, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
            if (hitRight1.collider != null || hitRight2.collider != null || hitRight3.collider != null)
            {
                //Debug.Log("Collider right");
                if (OnColliderRight != null)
                {
                    OnColliderRight.Invoke();
                }
            }
        }
    }
}
