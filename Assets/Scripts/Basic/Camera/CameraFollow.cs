using UnityEngine;
using System.Collections;

namespace PlatformBasic
{
    public class CameraFollow : MonoBehaviour
    {
        public float m_smooth = 5.0f;
        public float m_toTargetDistance = 2f;

        private Transform m_target;

        void Start()
        {
            m_target = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
        }

        void Update()
        {
            if (!GameBasic._game.IsRuning())
            {
                return;
            }

            if (m_target == null)
            {
                Debug.LogError("Can't find target!");
                return;
            }

            if (NeedToMoveCamera())
            {
                MoveCamera();
            }
        }

        private bool NeedToMoveCamera()
        {
            //Debug.Log (" current distance is； " + (m_target.position.y - transform.position.y ));
            if (transform.position.y - m_target.position.y < m_toTargetDistance)
            {
                //Debug.Log ("need move camera");
                return true;
            }
            return false;
        }

        private void MoveCamera()
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,
                m_target.position.y + m_toTargetDistance, transform.position.z), m_smooth * Time.deltaTime);
        }

        //private void OnPlayerRevive()
        //{
        //    transform.position = new Vector3(transform.position.x,
        //        GetLastSafePos().y + m_toTargetDistance, transform.position.z);
        //    //Debug.Log ("player revive, camera move");
        //}

        //private Vector3 GetLastSafePos()
        //{
        //    var obsManager = GameObject.FindGameObjectWithTag(Tags.OBSTACLES_MANAGER).GetComponent<ObstacleManager>();
        //    var safePos = obsManager.getPlayerInObstacles().m_safePos.position;
        //    return safePos;
        //}
    }
}
