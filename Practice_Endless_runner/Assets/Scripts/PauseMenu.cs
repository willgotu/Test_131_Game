using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public string mainMenuLevel;

    public GameObject pauseMenu;

    public AudioSource buttonSound;
    public AudioSource introMusic;
    public AudioSource backgroundMusic;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        buttonSound.Play();
        backgroundMusic.Pause();
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        buttonSound.Play();
        backgroundMusic.Play();
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        buttonSound.Play();
        backgroundMusic.Stop();
        introMusic.Play();
        backgroundMusic.PlayDelayed(1.5f);
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        buttonSound.Play();
        // Application.LoadLevel(mainMenuLevel);
        SceneManager.LoadScene("Main Menu");
    }
}
