using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioClip enviromentSound;
    public AudioClip victorySound;
    

    [SerializeField]private AudioSource soundEffects;
    [SerializeField]private AudioSource environmentMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else //Correccion 1
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }

    void Start() //Correccion 2
    {
        soundEffects = GetComponent<AudioSource>();
        environmentMusic.clip = enviromentSound;
        environmentMusic.loop = true;
        environmentMusic.Play();
    }



    public void PlayStarSound()
    {
        environmentMusic.Play();
    }

    public void PlaySimpleSound(AudioClip clip)
    {
        soundEffects.PlayOneShot(clip);
    }
}