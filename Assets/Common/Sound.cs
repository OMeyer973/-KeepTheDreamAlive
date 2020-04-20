using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instance { get; private set; }

    public AudioSource ingameMusic;

    void Awake()
    {
        if (Instance == null) { 
            Instance = this; 
        } else { 
            Debug.Log("Warning: multiple " + this + " in scene!"); 
        }
    }

    public void PlayInGameMusic()
    {
        ingameMusic.Play();
    }

    public void PauseInGameMusic()
    {
        ingameMusic.Pause();
    }
}
