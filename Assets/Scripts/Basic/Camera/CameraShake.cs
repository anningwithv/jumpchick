/*
 * FileName:     CameraShake 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace PlatformBasic
{
	public class CameraShake : MonoBehaviour
	{

		void Start () 
		{
            GameBasic._game.OnGameFailed += Shake;
            FindObjectOfType<PlayerHealth>().OnHurt += ShakeTiny;
		}

        private void Shake()
        {
            transform.DOShakePosition(1.0f, 0.7f);
        }

        private void ShakeTiny()
        {
            transform.DOShakePosition(0.9f, 0.6f);
        }
    }

}
