using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Every time you add a new audio source, add a new audio name to this enum
public enum AudioName
{
    laserShot
}

public class SoundManager : MonoBehaviour {

    public static SoundManager instance = null;

    [System.Serializable]
    public struct AudioParameter
    {
        public AudioName audioName;
        public AudioClip audioClip;
        [Range(0.0f, 1.0f)]
        public float volume;
        [Range(1, 3)]
        public int priority;

        // For pitch variation
        [Range(0.0f, 2.0f)]
        public float pitchLow;
        [Range(0.0f, 2.0f)]
        public float pitchHigh;
    }
    
    private SFXLayer[] _audioSourceLayer;

    public AudioParameter[] AllAudioParameters;
    public Dictionary<AudioName, AudioParameter> AudioDictionary = new Dictionary<AudioName, AudioParameter>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < AllAudioParameters.Length; i++)
        {
            AudioDictionary.Add(AllAudioParameters[i].audioName, AllAudioParameters[i]);
        }

        _audioSourceLayer = GetComponentsInChildren<SFXLayer>();

    }

    // Plays an audio clip with the given parameters
    public void PlayAudioParameter(AudioName audioName)
    {
        AudioParameter audio = AudioDictionary[audioName];

        PlayAudio(audio.audioClip
                 , audio.volume
                 , audio.priority
                 , _audioSourceLayer
                 , audio.pitchLow
                 , audio.pitchHigh);
    }

    void PlayAudio(AudioClip audioClip, float volume, int priority, SFXLayer[] AudioSources, float pitchLow, float pitchHigh)
    {
        // Find non-playing audio sources to play audio
        foreach (SFXLayer audioSource in AudioSources)
        {
            if (!audioSource.SoundIsCurrentlyPlaying())
            {
                audioSource.SetClip(audioClip, volume, priority, pitchLow, pitchHigh);
                return;
            }
        }

        // If there are no audio sources that are not-playing, find one that the current SFX can override
        foreach (SFXLayer audioSource in AudioSources)
        {
            if (audioSource.NewSoundClipIsHigherPriority(priority))
            {
                audioSource.SetClip(audioClip, volume, priority, pitchLow, pitchHigh);
                return;
            }
        }
    }
}
