using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioSource effectSource;
    public AudioSource musicSource;

    //public float lowPitchRange = 0.95f;
    //public float highPitchRange = 1.05f;

    private void Awake()
    {
        Debug.Log("Awake Sound");
        if (!instance)
        {
            Debug.Log("Dont Destroy");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (this != instance)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //public void PlaySingle(AudioClip clip)
    //{
    //    instance.effectSource.clip = clip;
    //    instance.effectSource.Play();
    //}

    //public void RandomizeSfx(params AudioClip[] clips)
    //{
    //    int randomIndex = Random.Range(0, clips.Length);
    //    float randomPitch = Random.Range(lowPitchRange, highPitchRange);

    //    instance.effectSource.pitch = randomPitch;
    //    instance.effectSource.clip = clips[randomIndex];
    //    instance.effectSource.Play();
    //}

    public void AddEffect(AudioClip clip)
    {
        //AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);//new Vector3(0.0f, 0.0f, 0.0f));
        instance.effectSource.PlayOneShot(clip, 1.0f);
    }

    public void AddEffect(AudioClip clip, float volume)
    {
        instance.effectSource.PlayOneShot(clip, volume);
    }

    public void KillEffects()
    {
        instance.effectSource.Stop();
    }

    public void PauseEffects()
    {
        instance.effectSource.Pause();
    }

    public void ResumeEffect()
    {
        //AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);//new Vector3(0.0f, 0.0f, 0.0f));
        instance.effectSource.UnPause();
    }

    public void SetEffectVolume(float volume)
    {
        instance.effectSource.volume = volume;
    }

    public void MuteEffect()
    {
        instance.effectSource.mute = true;
    }

    public void UnMuteEffect()
    {
        instance.effectSource.mute = false;
    }

    public void PlayMusic()
    {
        instance.musicSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        instance.musicSource.clip = clip;
        instance.musicSource.Play();
    }

    public void StopMusic()
    {
        instance.musicSource.Stop();
    }

    public void PauseMusic()
    {
        instance.musicSource.Pause();
    }

    public void ResumeMusic()
    {
        instance.musicSource.UnPause();
    }

    public void SetMusicVolume(float volume)
    {
        instance.musicSource.volume = volume;
    }

    public void MuteMusic()
    {
        instance.musicSource.mute = true;
    }

    public void UnMuteMusic()
    {
        instance.musicSource.mute = false;
    }

    public void Play()
    {
        PlayMusic();
    }

    public void Stop()
    {
        KillEffects();
        StopMusic();
    }

    public void Pause()
    {
        PauseEffects();
        PauseMusic();
    }

    public void Resume()
    {
        ResumeEffect();
        ResumeMusic();
    }

    public void Mute()
    {
        MuteEffect();
        MuteMusic();
    }

    public void UnMute()
    {
        UnMuteEffect();
        UnMuteMusic();
    }

    public void SetVolume(float volume)
    {
        SetEffectVolume(volume);
        SetMusicVolume(volume);
    }

    public void SetLoop(bool loop)
    {
        instance.musicSource.loop = loop;
    }
}