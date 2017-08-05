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

    void Start()
    {
        m_inputHandler = GetComponent<InputHandler>();
        m_rgd = GetComponent<Rigidbody2D>();

        RegisterInputListener();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 colliderPos = collision.contacts[0].point;
        Debug.Log("Collider position is: " + colliderPos);
        ColliderDir dir = GetColliderDir(colliderPos);
        Debug.Log("OnCollisionEnter2D, collider dir is: " + dir.ToString());
        if (dir == ColliderDir.Left || dir == ColliderDir.Right) {
            if (m_jumpDir == JumpDir.Left) {
                m_jumpDir = JumpDir.Right;
            }else if (m_jumpDir == JumpDir.Right)
            {
                m_jumpDir = JumpDir.Left;
            }
        }
    }
    private ColliderDir GetColliderDir(Vector3 colliderPos) {
        return ColliderDir.None;
    }

    //private ColliderDir GetColliderDir(Transform collider)
    //{
    //    RaycastHit2D hitBottom1 = Physics2D.Raycast(m_bottomLeft.position, Vector2.down, 0.1f);
    //    RaycastHit2D hitBottom2 = Physics2D.Raycast(m_bottomRight.position, Vector2.down, 0.1f);
    //    if (collider.transform == hitBottom1.transform || collider.transform == hitBottom2.transform)
    //    {
    //        return ColliderDir.Down;
    //    }

    //    RaycastHit2D hitUp1 = Physics2D.Raycast(m_topLeft.position, Vector2.up, 0.1f);
    //    RaycastHit2D hitUp2 = Physics2D.Raycast(m_topRight.position, Vector2.up, 0.1f);
    //    if (collider.transform == hitUp1.transform || collider.transform == hitUp2.transform)
    //    {
    //        return ColliderDir.Up;
    //    }

    //    RaycastHit2D hitLeft1 = Physics2D.Raycast(m_topLeft.position, Vector2.left, 0.1f);
    //    RaycastHit2D hitLeft2 = Physics2D.Raycast(m_bottomLeft.position, Vector2.left, 0.1f);
    //    if (collider.transform == hitLeft1.transform || collider.transform == hitLeft2.transform)
    //    {
    //        return ColliderDir.Left;
    //    }

    //    RaycastHit2D hitRight1 = Physics2D.Raycast(m_topLeft.position, Vector2.right, 0.1f);
    //    RaycastHit2D hitRight2 = Physics2D.Raycast(m_bottomLeft.position, Vector2.right, 0.1f);
    //    if (collider.transform == hitRight1.transform || collider.transform == hitRight2.transform)
    //    {
    //        return ColliderDir.Right;
    //    }

    //    return ColliderDir.None;
    //}

    private void FixedUpdate()
    {
        if (m_isJumping) {
            m_rgd.AddForce(new Vector2(GetJumpForceX(), m_jumpForceY));
        }
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
