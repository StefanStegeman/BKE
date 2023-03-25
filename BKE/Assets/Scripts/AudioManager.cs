using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region AudioSources
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource sfxSource;
    #endregion

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    /// <summary>
    /// Plays the AudioClip from the music AudioSource.
    /// </summary>
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    /// <summary>
    /// Stops the AudioClip from the music AudioSource.
    /// </summary>
    public void StopMusic()
    {
        musicSource.Stop();
    }

    /// <summary>
    /// Plays the AudioClip from the sfx AudioSource.
    /// </summary>
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    /// <summary>
    /// Stops the AudioClip from the sfx AudioSource.
    /// </summary>
    public void StopSFX()
    {
        sfxSource.Stop();
    }
}
