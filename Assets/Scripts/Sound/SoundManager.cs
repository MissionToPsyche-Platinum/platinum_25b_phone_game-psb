using System;
using UnityEngine;
using UnityEngine.Audio;
// This script manages all the audio clips

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    //stores all the sound clips
    public Sound[] soundlist;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    // Awake is called before the game starts
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
         
        DontDestroyOnLoad(gameObject);
        // gives each Sound item an AudioSource, audio file,
        //  and volume slider from Sound class
        if(soundlist != null)
            foreach (Sound item in soundlist)
            {
                item.source = gameObject.AddComponent<AudioSource>();
                item.source.clip = item.clip;
                item.source.volume = item.volume;
                item.source.loop = item.loop;
            }
    }

    // Plays audio clip when called, used in other scripts when
    // clip is needed
    public void PlaySound(string name)
    {
        if (soundlist != null)
        {
            Sound s = Array.Find(soundlist, sound => sound.clipName == name);
            if (ReferenceEquals(s, null))
            {
                //Debug.LogWarning(name + " does not exist");
                return;
            }
            s.source.Play();
        }
    }

    // Plays audio clip when called, used in other scripts when
    // clip is needed
    public void StopSound(string name)
    {
        if (soundlist != null)
        {
            Sound s = Array.Find(soundlist, sound => sound.clipName == name);
            if (ReferenceEquals(s, null))
            {
                return;
            }
            s.source.Stop();
        }
    }
}
