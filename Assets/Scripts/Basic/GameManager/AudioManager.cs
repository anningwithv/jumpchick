using UnityEngine;
using System.Collections;

namespace PlatformBasic
{
    [RequireComponent (typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager _instance;

        private AudioSource m_audioSource = null;

        void Awake()
        {
            _instance = GetComponent<AudioManager>();
        }

        void Start()
        {
            GameBasic._game.OnGameStart += OnGameStart;
            m_audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {

        }

        private void OnGameStart()
        {
            GetComponent<AudioSource>().Play();
        }

        public void Play(AudioClip clip)
        {
            m_audioSource.clip = clip;
            m_audioSource.Play();
        }
    }
}
