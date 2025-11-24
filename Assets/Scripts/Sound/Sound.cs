using UnityEngine;
using UnityEngine.Audio;
// Sound Base class for use in SoundManager

[System.Serializable]
public class Sound
{
    public string clipName;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume;
    public bool loop;
    
    // Not needed in inspector since the AudioSource is
    // already added
    [HideInInspector] public AudioSource source;
}
