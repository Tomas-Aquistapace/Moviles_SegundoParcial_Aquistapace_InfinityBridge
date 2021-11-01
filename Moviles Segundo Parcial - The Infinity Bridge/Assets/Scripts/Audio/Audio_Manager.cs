using UnityEngine.Audio;
using System;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public AudioMixerGroup music_AudioMixer;
    public float musicValue = 0.5f;
    public AudioMixerGroup sfx_AudioMixer;
    public float sfxValue = 0.5f;

    public Audio_Sound[] sounds;

    public static Audio_Manager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }

        // ---------

        DontDestroyOnLoad(this.gameObject);

        foreach (Audio_Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            switch (s.audioGroup)
            {
                case Audio_Sound.AudioGroup.Music:
                    s.source.outputAudioMixerGroup = music_AudioMixer;

                    break;
                case Audio_Sound.AudioGroup.SFX:
                    s.source.outputAudioMixerGroup = sfx_AudioMixer;

                    break;
            }

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        
    }

    public void Play(string name)
    {
        Audio_Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogError("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Audio_Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
