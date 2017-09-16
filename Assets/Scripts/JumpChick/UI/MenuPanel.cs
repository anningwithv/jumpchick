/*
 * FileName:     MenuPanel 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace JumpChick
{
	public class MenuPanel : MonoBehaviour
	{
        public Button m_restartBtn = null;

        void Start () 
		{
            m_restartBtn.onClick.AddListener(delegate ()
            {
                SceneManager.LoadScene("Game");
            });
        }
		
		void Update () 
		{
			
		}
	}

}
