/*
 * FileName:     DestroyWithDelay 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformBasic
{
	public class DestroyWithDelay : MonoBehaviour
	{
        public float m_delay = 8f;

		void Start () 
		{
            Destroy(gameObject, m_delay);
		}
	}

}
