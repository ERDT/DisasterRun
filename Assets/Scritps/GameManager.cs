using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private float jumpStore;
    private ScoreManager theScoreManager;
    public Transform platformGenerator;
    private Vector3 platformStartPoint;
    public PlayerController thePlayer;
    private Vector3 playerStartPoint;
    private PlatformDestroyer[] platformList;
	// Use this for initialization
	void Start () {
        jumpStore = thePlayer.xJump;
		platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");   
    }
    public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.xJump = jumpStore;
        thePlayer.jumped = jumpStore;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        
        platformList = FindObjectsOfType <PlatformDestroyer>();
        for(int i = 0;i < platformList.Length ; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;

        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.Rotate(0, 0, 0);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }
}
