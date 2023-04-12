using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    #region AudioSources
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource sfxSource;
    #endregion

    #region VolumeSliders
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider sfxSlider;
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

    /// <summary>
    /// Mutes or unmutes the AudioSource.
    /// </summary>
    public void MuteAudioSource(AudioSource source)
    {
        source.mute = !source.mute;
    }

    public void ChangeMusicVolumeLevel()
    {
        musicSource.volume = musicSlider.value;
    }

    public void ChangeSFXVolumeLevel()
    {
        sfxSource.volume = sfxSlider.value;
    }
}
