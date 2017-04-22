using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class GoldCoinPoints : MonoBehaviour {
    private AudioSource coinSound;
    public int scoreToGive;
    private ScoreManager theScoreManager;
    // Use this for initialization
    void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();
        coinSound = GameObject.Find("GoldCoinSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerPrototype") {
            theScoreManager.addScore(scoreToGive);
            if (coinSound.isPlaying)
            {
                coinSound.Stop();
                coinSound.Play();
            }
            else {
                coinSound.Play();
            }
            
            gameObject.SetActive(false);
        }
    }
}
