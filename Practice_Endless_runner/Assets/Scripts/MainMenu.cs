using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string playGameLevel;

    public AudioSource buttonSound;

    // Use this for initialization
    void Start()
    {
        buttonSound = GameObject.Find("PushButtonSound").GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        buttonSound.Play();
        Application.LoadLevel(playGameLevel);
    }

    public void QuitGame()
    {
        buttonSound.Play();
        Application.Quit();
    }
}
