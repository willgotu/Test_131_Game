using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;

    public AudioSource buttonSound;
    public AudioSource introMusic;
    public AudioSource backgroundMusic;

    //public PlayerController thePlayerController;

    public void RestartGame()
    {
        buttonSound.Play();
        introMusic.Play();
        backgroundMusic.PlayDelayed(1.5f);
        FindObjectOfType<GameManager>().Reset();
        
    }

    public void QuitToMain()
    {
        buttonSound.Play();
        //Application.LoadLevel(mainMenuLevel);
        SceneManager.LoadScene("Main Menu");
    }
}
