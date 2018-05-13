using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string playGameLevel;

    public AudioSource buttonSound;
    public AudioSource introMusic;
    public AudioSource backgroundMusic;

    // Use this for initialization
    void Start()
    {
        introMusic.Play();
        backgroundMusic.PlayDelayed(6.9f);
        buttonSound = GameObject.Find("PushButtonSound").GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        buttonSound.Play();
        //Application.LoadLevel(playGameLevel);
        SceneManager.LoadScene("Endless");

    }

    public void QuitGame()
    {
        buttonSound.Play();
        Application.Quit();
    }
}
