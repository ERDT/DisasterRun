﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {
    public Text scoreText;
    public PlayerController thePlayer;
    public Text highScoreText;
    public Text xJumpsText;
    public float scoreCount;
    public float highScoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("HighScore")) {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
	}

    // Update is called once per frame
    void Update() {
        if (scoreIncreasing) {
            scoreCount += (pointsPerSecond +(int)(1.0f+(thePlayer.xJump)*5))* Time.deltaTime;
        }
        if (scoreCount > highScoreCount) {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }
        
        if (thePlayer.xJump < 1)
        {
            xJumpsText.text = "Stomp!";
        }
        if (thePlayer.fly) {
            xJumpsText.text = "Fly!";
        }
        else
        {
            xJumpsText.text = "xJumps: " + (int)thePlayer.xJump;
        }
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "Highscore: " + Mathf.Round(highScoreCount);
	}
}
