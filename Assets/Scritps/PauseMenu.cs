using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenu;
    public string mainMenu;
    public void RestartGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().reset();
    }
    public void QuitToMain()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenu);
    }
    public void ResumeGame() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
