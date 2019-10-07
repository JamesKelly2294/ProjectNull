using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Lightbug.GrabIt;

public class GameManager : MonoBehaviour
{
    private GameManager() {}
    public static GameManager Instance { get; private set; }

    public GameObject playerFPSController;

    public bool PlayBackgroundMusic = true;
    public bool PlayFactoryAmbience = true;

    public AudioClip ButtonClickSound;
    public AudioClip BackgroundMusic;
    public AudioClip BackgroundAmbience;

    private AudioSource loudAudioSource;
    private AudioSource musicAudioSource;
    private AudioSource ambienceAudioSource;

    public GrabIt GrabIt;

    public void RequestPlayButtonClickSound()
    {
        loudAudioSource.PlayOneShot(ButtonClickSound);
    }

    public void RequestPlayBackgroundMusic()
    {
        musicAudioSource.loop = true;
        musicAudioSource.clip = BackgroundMusic;
        musicAudioSource.volume = 0.17f;
        musicAudioSource.Play();
    }

    public void RequestPlayFactoryAmbience()
    {
        ambienceAudioSource.loop = true;
        ambienceAudioSource.clip = BackgroundAmbience;
        ambienceAudioSource.volume = 0.45f;
        ambienceAudioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        playerFPSController = GameObject.Find("FPSController").gameObject;
        GrabIt = playerFPSController.transform.Find("FirstPersonCharacter").GetComponent<GrabIt>();

        loudAudioSource = playerFPSController.AddComponent<AudioSource>();
        musicAudioSource = playerFPSController.AddComponent<AudioSource>();
        ambienceAudioSource = playerFPSController.AddComponent<AudioSource>();

        if (PlayBackgroundMusic)
        {
            RequestPlayBackgroundMusic();
        }

        if (PlayFactoryAmbience)
        {
            RequestPlayFactoryAmbience();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
