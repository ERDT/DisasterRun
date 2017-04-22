using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    public GameObject thePlatform;
    public Transform generationPoint;
    //public GameObject[] thePlatforms;
    private float[] platformWidths;
    private int platformSelector;
    public float distanceBetween;
    public float distanceBoost;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    private float minHight;
    public Transform maxHightPoint;
    private float maxHight;
    public float maxHightChange;
    private float platformWidth;
    private float hightChange;
    
    public ObjectPooler[] theObjectPools;
	
        // Use this for initialization
	void Start () {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];
        minHight = transform.position.y;
        maxHight = maxHightPoint.position.y;
        for (int i = 0 ;i < theObjectPools.Length ;i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

    }
	
	// Update is called once per frame
	void Update () {
       
       
        if (transform.position.x < generationPoint.position.x) {

            distanceBetweenMax = distanceBetweenMax + distanceBoost;
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);


            platformSelector = Random.Range(0, theObjectPools.Length);

            hightChange = transform.position.y + Random.Range(maxHightChange,-maxHightChange);
            if (hightChange > maxHight) {
                hightChange = maxHight;
            }
            if (hightChange < minHight)
            {
                hightChange = minHight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, hightChange, transform.position.z);
           
            //Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);


        }
    }
}
