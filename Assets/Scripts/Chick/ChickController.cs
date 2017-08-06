using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickController : MonoBehaviour {

    public enum JumpDir
    {
        Left,
        Right,
        Center
    }

    public enum ColliderDir
    {
        None,
        Left,
        Right,
        Up,
        Down
    }

    //public Transform m_topLeft = null;
    //public Transform m_topRight = null;
    //public Transform m_bottomLeft = null;
    //public Transform m_bottomRight = null;

    private InputHandler m_inputHandler = null;
    private Rigidbody2D m_rgd = null;

    private bool m_isJumping = false;

    private float m_jumpForceY = 20f;
    private float m_jumpForceX = 10f;

    private JumpDir m_jumpDir = JumpDir.Right;

    private Vector2 m_top1, m_top2, m_bottom1, m_bottom2,
        m_left1, m_left2, m_left3, m_right1, m_right2, m_right3;

    private BoxCollider2D m_collider2D = null;
    private float m_boudaryScale = 0.9f;

    private string m_checkColliderLayerName = "Brick";

    void Start()
    {
        m_inputHandler = GetComponent<InputHandler>();
        m_rgd = GetComponent<Rigidbody2D>();
        m_collider2D = GetComponent<BoxCollider2D>();

        SetBoundary();
        RegisterInputListener();
    }

    private void SetBoundary()
    {
        Vector2 center = new Vector2(transform.position.x, transform.position.y) + m_collider2D.offset;
        float width = m_collider2D.size.x * m_boudaryScale;
        float height = m_collider2D.size.y * m_boudaryScale;

        float marginX = width / 10f;
        float marginY = height / 10f;
        m_top1 = center + new Vector2(-width/2f + marginX, height/2f);
        m_top2 = center + new Vector2(width / 2f - marginX, height / 2f);
        m_bottom1 = center + new Vector2(-width / 2f + marginX, -height / 2f);
        m_bottom2 = center + new Vector2(width / 2f - marginX, -height / 2f);
        m_left1 = center + new Vector2(-width / 2f, height / 2f - marginY);
        m_left2 = center + new Vector2(-width / 2f, 0);
        m_left1 = center + new Vector2(-width / 2f, -height / 2f + marginY);
        m_right1 = center + new Vector2(width / 2f, height / 2f - marginY);
        m_right2 = center + new Vector2(width / 2f, 0);
        m_right1 = center + new Vector2(width / 2f, -height / 2f + marginY);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (m_isJumping)
        {
            m_rgd.AddForce(new Vector2(GetJumpForceX(), m_jumpForceY));
        }

        var colliderDir = GetColliderDir();
        if (colliderDir != ColliderDir.None) {
            Debug.Log("Current collider is: " + colliderDir);
            Debug.Log("Current jump dir is: " + m_jumpDir);
            if (colliderDir == ColliderDir.Right && m_jumpDir == JumpDir.Right)
            {
                m_jumpDir = JumpDir.Left;
            }
            else if (colliderDir == ColliderDir.Left && m_jumpDir == JumpDir.Left)
            {
                m_jumpDir = JumpDir.Right;
            }
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    SetBoundary();

    //    Vector2 colliderPos = collision.contacts[0].point;
    //    Debug.Log("Collider position is: " + colliderPos);
    //    ColliderDir dir = GetColliderDir(colliderPos);
    //    Debug.Log("OnCollisionEnter2D, collider dir is: " + dir.ToString());
    //    if (dir == ColliderDir.Left || dir == ColliderDir.Right) {
    //        if (m_jumpDir == JumpDir.Left) {
    //            m_jumpDir = JumpDir.Right;
    //        }else if (m_jumpDir == JumpDir.Right)
    //        {
    //            m_jumpDir = JumpDir.Left;
    //        }
    //    }
    //}
    //private ColliderDir GetColliderDir(Vector2 colliderPos)
    //{
    //    if (colliderPos.x <= m_top1.x )
    //    {
    //        return ColliderDir.Left;
    //    }
    //    if (colliderPos.x >= m_top2.x )
    //    {
    //        return ColliderDir.Right;
    //    }
    //    if (colliderPos.y <= m_bottom1.y)
    //    {
    //        return ColliderDir.Down;
    //    }
    //    if (colliderPos.y >= m_top2.y)
    //    {
    //        return ColliderDir.Up;
    //    }

    //    return ColliderDir.None;
    //}

    private ColliderDir GetColliderDir()
    {
        SetBoundary();

        float distanceX = m_collider2D.size.x * (1 - m_boudaryScale);
        float distanceY = m_collider2D.size.y * (1 - m_boudaryScale);

        RaycastHit2D hitBottom1 = Physics2D.Raycast(m_bottom1, Vector2.down, distanceY, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
        RaycastHit2D hitBottom2 = Physics2D.Raycast(m_bottom2, Vector2.down, distanceY, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
        if (hitBottom1.collider != null || hitBottom2.collider != null)
        {
            return ColliderDir.Down;
        }

        RaycastHit2D hitUp1 = Physics2D.Raycast(m_top1, Vector2.up, distanceY, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
        RaycastHit2D hitUp2 = Physics2D.Raycast(m_top2, Vector2.up, distanceY, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
        if (hitUp1.collider != null || hitUp2.collider != null)
        {
            return ColliderDir.Up;
        }

        RaycastHit2D hitLeft1 = Physics2D.Raycast(m_left1, Vector2.left, distanceX, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
        RaycastHit2D hitLeft2 = Physics2D.Raycast(m_left2, Vector2.left, distanceX, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
        RaycastHit2D hitLeft3 = Physics2D.Raycast(m_left3, Vector2.left, distanceX, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
        if (hitLeft1.collider != null || hitLeft2.collider != null || hitLeft3.collider != null)
        {
            return ColliderDir.Left;
        }

        RaycastHit2D hitRight1 = Physics2D.Raycast(m_right1, Vector2.right, distanceX, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
        RaycastHit2D hitRight2 = Physics2D.Raycast(m_right2, Vector2.right, distanceX, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
        RaycastHit2D hitRight3 = Physics2D.Raycast(m_right2, Vector2.right, distanceX, 1 << LayerMask.NameToLayer(m_checkColliderLayerName));
        if (hitRight1.collider != null || hitRight2.collider != null || hitRight3.collider != null)
        {
            return ColliderDir.Right;
        }

        return ColliderDir.None;
    }

    private float GetJumpForceX()
    {
        if (m_jumpDir == JumpDir.Left)
        {
            return -m_jumpForceX;
        }
        else if (m_jumpDir == JumpDir.Right)
        {
            return m_jumpForceX;
        }
        else {
            return 0;
        }
    }

    private void RegisterInputListener()
    {
        m_inputHandler.OnMousePressed += OnPlayerPressed;
        m_inputHandler.OnMouseReleased += OnPlayerReleased;
    }

    private void OnPlayerPressed()
    {
        m_isJumping = true;
        Debug.Log("Player pressed. jump");
    }

    private void OnPlayerReleased()
    {
        m_isJumping = false;
        Debug.Log("Player relesed. stop jump");
    }
}
