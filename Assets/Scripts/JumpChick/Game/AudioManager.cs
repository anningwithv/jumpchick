using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance = null;

	public AudioClip m_btnClickClip = null;
	public AudioClip m_moveClip = null;
	public AudioClip m_spdDownClip = null;
	public AudioClip m_deadClip = null;
    public AudioClip m_foodClip = null;

    private bool m_isSoundOn = true;

	void Awake () 
	{
        Instance = this;

        if (m_isSoundOn)
        {
            GetComponent<AudioSource>().Play();
        }
	}

	public void PlayBtnClickSound()
    {
        if (!m_isSoundOn)
            return;
		AudioSource.PlayClipAtPoint (m_btnClickClip, Camera.main.transform.position);
	}

	public void PlayMoveSound()
    {
        if (!m_isSoundOn)
            return;
        AudioSource.PlayClipAtPoint (m_moveClip, Camera.main.transform.position);
	}

	public void PlaySpdDownSound()
	{
        if (!m_isSoundOn)
            return;
        AudioSource.PlayClipAtPoint (m_spdDownClip, Camera.main.transform.position);
	}

	public void PlayDeadSound()
	{
        if (!m_isSoundOn)
            return;
        AudioSource.PlayClipAtPoint (m_deadClip, Camera.main.transform.position);
	}

    public void PlayGetFoodSound()
    {
        if (!m_isSoundOn)
            return;
        AudioSource.PlayClipAtPoint(m_foodClip, Camera.main.transform.position);
    }
}
