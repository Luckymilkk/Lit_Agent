using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void Play(string CurName)
    {
        foreach(Sound sound in sounds)
        {
            if(sound.name == CurName)
            {
                sound.source.Play();
            }
        }
    }

    public void Stop(string CurName)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.name == CurName)
            {
                sound.source.Stop();
            }
        }
    }
}
