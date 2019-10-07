using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager() {}
    public static GameManager Instance { get; private set; }

    public AudioSource LoudAudioSource; // lol what a hack
    public AudioSource QuietAudioSource;
    public AudioClip ButtonClickSound;

    public void RequestPlayButtonClickSound()
    {
        LoudAudioSource.PlayOneShot(ButtonClickSound);
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
