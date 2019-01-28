using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {

    [SerializeField]
    private AudioMixer mixer;

    [SerializeField]
    private AudioClip menuMusic;
    [SerializeField]
    private AudioClip gameMusic;
    [SerializeField]
    private AudioClip uiClickSound;
    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private AudioClip itemCollectSound;
    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private AudioClip gameOverSound;
    [SerializeField]
    private AudioClip gameCompleteSound;

    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource sfxSource;

	// Use this for initialization
	void Start () {

        
    }

    public void StartGameMusic()
    {
        musicSource.Stop();
        musicSource.loop = true;
        musicSource.clip = gameMusic;
        musicSource.Play();
    }

    public void StartMenuMusic()
    {
        musicSource.Stop();
        musicSource.loop = true;
        musicSource.clip = menuMusic;
        musicSource.Play();
    }

    public void PlayGameCompleteSound()
    {
        sfxSource.PlayOneShot(gameCompleteSound);
    }

    public void PlayGameOverSound()
    {
        sfxSource.PlayOneShot(gameOverSound);
    }

    public void PlayDeathSound()
    {
        sfxSource.PlayOneShot(deathSound);
    }

    public void PlayItemCollectSound()
    {
        sfxSource.PlayOneShot(itemCollectSound);
    }

    public void PlayJumpSound()
    {
        sfxSource.PlayOneShot(jumpSound);
    }

    public void PlayUIClickSound()
    {
        sfxSource.PlayOneShot(uiClickSound);
    }

    public float GetMasterVolume()
    {
        float value = 0;
        mixer.GetFloat("MasterVolume",out value);
        return value.DecibelToLinear();
    }
    public float GetMusicVolume()
    {
        float value = 0;
        mixer.GetFloat("MusicVolume", out value);
        return value.DecibelToLinear();
    }
    public float GetSFXVolume()
    {
        float value = 0;
        mixer.GetFloat("SFXVolume", out value);
        
        return value.DecibelToLinear();
    }

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat("MasterVolume", value.LinearToDecibel());
    }
    public void SetMusicVolume(float value)
    {
        value = value.Remap(0,1,0,1);
        mixer.SetFloat("MusicVolume", value.LinearToDecibel());
    }

    public void SetSFXVolume(float value)
    {
        mixer.SetFloat("SFXVolume", value.LinearToDecibel());
    }
}
