using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformBasic
{
    public class RecycableItem : MonoBehaviour
    {
        public Transform m_top;
        public Transform m_bottom;

        private Transform m_target;
        private float m_height;
        private float m_toBottomHeight;
        private float m_toTopHeight;

        void Start()
        {
            m_target = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
            m_height = m_top.position.y - m_bottom.position.y;
            m_toBottomHeight = transform.position.y - m_bottom.position.y;
            m_toTopHeight = m_top.position.y - transform.position.y;
        }

        void Update()
        {
            if (!GameBasic._game.IsRuning())
            {
                return;
            }

            if (m_target == null)
            {
                Debug.LogError("Can't find target");
                return;
            }

            if (NeedToMoveBoard())
            {
                MoveBoard();
            }
        }

        private bool NeedToMoveBoard()
        {
            bool needMoveBoard = false;

            if (GameConfig._moveDir == GameConfig.MoveDir.Up)
            {
                needMoveBoard = m_target.position.y - m_top.position.y > CameraAutoSize.sCameraSize + 1;
            }
            else {
                needMoveBoard = m_bottom.position.y - m_target.position.y > CameraAutoSize.sCameraSize + 5;
            }

            if(needMoveBoard)
                return true;

            return false;
        }

        private void MoveBoard()
        {
            if (GameConfig._moveDir == GameConfig.MoveDir.Up)
            {
                float y = GetTopBoardY();
                transform.position = new Vector3(transform.position.x, y + m_toBottomHeight, transform.position.z);
            }
            else {
                float y = GetBottomBoardY();
                transform.position = new Vector3(transform.position.x, y - m_toTopHeight, transform.position.z);
            }
        }

        private float GetTopBoardY()
        {
            GameObject o = gameObject;
            GameObject[] objs = GameObject.FindGameObjectsWithTag(transform.tag);
            foreach (var obj in objs) {
                if (obj.transform.position.y > o.transform.position.y) {
                    o = obj;
                }
            }
            float y = o.GetComponent<RecycableItem>().m_top.position.y;
            return y;
        }

        private float GetBottomBoardY()
        {
            GameObject o = gameObject;
            GameObject[] objs = GameObject.FindGameObjectsWithTag(transform.tag);
            foreach (var obj in objs)
            {
                if (obj.transform.position.y < o.transform.position.y)
                {
                    o = obj;
                }
            }
            float y = o.GetComponent<RecycableItem>().m_bottom.position.y;
            return y;
        }
    }
}
