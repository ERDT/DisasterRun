using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {
    public AudioSource mainMusic;
    public string mainMenu;
    public void RestartGame() {
        mainMusic.Stop();
        mainMusic.Play();
        FindObjectOfType<GameManager>().reset();
    }
    public void QuitToMain() {
        mainMusic.Stop();
        Application.LoadLevel(mainMenu);
    }
}
