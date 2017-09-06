using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpChick
{
    public class PoolManager : MonoBehaviour
    {

        public static PoolManager Instance = null;
        public bool m_isPersistant = true;

        private Dictionary<string, List<Transform>> m_myPool = new Dictionary<string, List<Transform>>();
        private List<Transform> m_tempObjectList = new List<Transform>();

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
            if (m_isPersistant)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        public Transform SpawnObject(Transform prefab)
        {
            Transform objectToRelease = null;
            //if (m_myPool.ContainsKey(prefab.name))
            if(false)
            {
                m_tempObjectList.Clear();
                m_tempObjectList = new List<Transform>(m_myPool[prefab.name]);
                for (int i = 0; i < m_tempObjectList.Count; i++)
                {
                    if (m_tempObjectList[i].gameObject.activeInHierarchy == false)
                    {
                        objectToRelease = m_tempObjectList[i];
                    }
                }
                if (objectToRelease == null)
                {
                    objectToRelease = (Transform)Instantiate(prefab);
                    objectToRelease.name = prefab.name;
                    m_myPool[prefab.name].Add(objectToRelease);
                }
            }
            else
            {
                m_tempObjectList.Clear();
                objectToRelease = (Transform)Instantiate(prefab);
                objectToRelease.name = prefab.name;
                m_tempObjectList.Add(objectToRelease);
                m_myPool[prefab.name] = new List<Transform>(m_tempObjectList);
            }
            objectToRelease.parent = null;
            return objectToRelease;
        }

        public void ReleaseObject(Transform instance)
        {
            instance.parent = transform;
            instance.gameObject.SetActive(false);
        }
    }
}
