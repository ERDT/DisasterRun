using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public string gameLevel1;
    public void playGame() {
        Application.LoadLevel(gameLevel1);
    }
    public void quitGame() {
        Application.Quit();
    }
}
