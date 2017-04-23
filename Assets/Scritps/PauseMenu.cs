using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public AudioSource mainMusic;
    public GameObject pauseMenu;
    public string mainMenu;
    public bool  isPaused;
    public void RestartGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().reset();
    }
    public void QuitToMain()
    {
        mainMusic.Stop();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenu);
    }
    public void ResumeGame() {
        mainMusic.Play();
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        mainMusic.Pause();
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
