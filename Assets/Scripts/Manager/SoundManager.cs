using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioSource effectSource;
    public AudioSource musicSource;

    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

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

    public void PlaySingle(AudioClip clip)
    {
        instance.effectSource.clip = clip;
        instance.effectSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        instance.effectSource.pitch = randomPitch;
        instance.effectSource.clip = clips[randomIndex];
        instance.effectSource.Play();
    }
}