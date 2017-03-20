using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CMusicManager : MonoBehaviour
{
    public AudioClip[] LevelMusicChangeArray;

    private AudioSource m_AudioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.volume = CPlayerPrefsManager.GetMasterVolume();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene newScene, LoadSceneMode sceneMode)
    {
        AudioClip loadedSceneClip = LevelMusicChangeArray[newScene.buildIndex];

        Debug.Log("Playing clip: " + loadedSceneClip);

        // Don't play the same clip from the beginning
        if (m_AudioSource.clip != null &&
            m_AudioSource.clip == loadedSceneClip) return;

        if (loadedSceneClip)
        {
            m_AudioSource.clip = loadedSceneClip;
            m_AudioSource.loop = true;
            m_AudioSource.Play();
        }
    }

    public void SetVolume(float newVolume)
    {
        m_AudioSource.volume = newVolume;
    }
}
