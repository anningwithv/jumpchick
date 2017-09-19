/*
 * FileName:     Food 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformBasic;
using DG.Tweening;

namespace JumpChick
{
	public class Food : MonoBehaviour
	{
        private float m_powerNum = 1f;
        private float m_scoreNum = 10f;

        void Start () 
		{
            Sequence seq = DOTween.Sequence();
            seq.Append(transform.DORotate(new Vector3(0, 0, 10), 0.5f).SetRelative());
            seq.Append(transform.DORotate(new Vector3(0, 0, -10), 0.5f).SetRelative());
            seq.SetLoops(-1);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!GameBasic._game.IsRuning())
                return;

            if (collision.gameObject.tag == Tags.PLAYER)
            {
                UIManager.Instance.m_gamePanel.OnGetFood(m_powerNum, m_scoreNum);
                AudioManager.Instance.PlayGetFoodSound();
                gameObject.SetActive(false);
            }
        }
    }

}
