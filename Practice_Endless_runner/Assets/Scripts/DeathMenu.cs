using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;

    public AudioSource buttonSound;
    public AudioSource backgroundMusic;

    //public PlayerController thePlayerController;

    public void RestartGame()
    {
        buttonSound.Play();
        backgroundMusic.Play();
        FindObjectOfType<GameManager>().Reset();
        
    }

    public void QuitToMain()
    {
        buttonSound.Play();
        Application.LoadLevel(mainMenuLevel);
    }
}
