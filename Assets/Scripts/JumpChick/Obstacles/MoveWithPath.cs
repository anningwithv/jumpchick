using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveWithPath : MonoBehaviour
{
    public List<Transform> m_pathPointList = new List<Transform>();
    public float m_moveSpd = 1.0f;
    
	void Start ()
    {
        Vector3[] posList = new Vector3[m_pathPointList.Count];
        for (int i = 0; i < m_pathPointList.Count; i++)
        {
            posList[i] = m_pathPointList[i].position;
        }

        Sequence seq = DOTween.Sequence();

        transform.DOPath(posList, 3.0f, PathType.Linear).SetLoops(-1);

        seq.SetLoops(-1);
	}

	void Update ()
    {
		
	}
}
