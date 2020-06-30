using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static public SoundManager instance = null;
    public AudioSource backgroundMusicSource;
    public AudioSource backgroundAmbienceSource;
    public AudioSource soundEffectSource;

    public AudioClip accelerationClip;
    public AudioClip runningClip;
    public AudioClip decelerationClip;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Accelerate()
    {
        backgroundAmbienceSource.clip = accelerationClip;
        backgroundAmbienceSource.loop = false;
        backgroundAmbienceSource.Play();
        Invoke("Running", accelerationClip.length);
    }

    public void Running()
    {
        backgroundAmbienceSource.clip = runningClip;
        backgroundAmbienceSource.loop = true;
        backgroundAmbienceSource.Play();
    }

    public void Decelerate()
    {
        CancelInvoke();
        backgroundAmbienceSource.clip = decelerationClip;
        backgroundAmbienceSource.loop = false;
        backgroundAmbienceSource.Play();
    }
}
