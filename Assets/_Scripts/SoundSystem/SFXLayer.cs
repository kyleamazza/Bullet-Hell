using UnityEngine;
using System.Collections;

// SFX Layer Script
// SFXLayers interact with the Audio Manager so that there aren't any more than
// a certain amount of SFX playing at the same time in a given space

public class SFXLayer : MonoBehaviour
{
    private AudioSource _audioSource;

    private int _currentClipPriority;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public bool NewSoundClipIsHigherPriority(int priority)
    {
        return _currentClipPriority >= priority;
    }

    public bool SoundIsCurrentlyPlaying()
    {
        return _audioSource.isPlaying;
    }

    public void SetClip(AudioClip currentlyPlayingClip, float volume, int priority, float pitchLow, float pitchHigh)
    {
        _audioSource.clip = currentlyPlayingClip;
        _audioSource.pitch = Random.Range(pitchLow, pitchHigh);
        _audioSource.volume = volume;
        _audioSource.Play();
        _currentClipPriority = priority;
    }
}