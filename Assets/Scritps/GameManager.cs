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
    private Quaternion playerStartRotation;
    private PlatformDestroyer[] platformList;
    public DeathMenu deathScreen;
	// Use this for initialization
	void Start () {
        jumpStore = thePlayer.xJump;
		platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        playerStartRotation = thePlayer.transform.rotation;
        theScoreManager = FindObjectOfType<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(true);
        //StartCoroutine("RestartGameCo");

    }

    public void reset() {
        thePlayer.xJump = jumpStore;
        thePlayer.jumped = jumpStore;
        


        //yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;


        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.rotation = playerStartRotation;


        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
        deathScreen.gameObject.SetActive(false);
    }
    /*public IEnumerator RestartGameCo()
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
        thePlayer.transform.rotation = playerStartRotation;
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/
}
