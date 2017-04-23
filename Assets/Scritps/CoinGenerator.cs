using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {
    private int coinSelector;
    public ObjectPooler coinPool;
    public float distanceBetweenCoins;
    public ObjectPooler[] theObjectPoolsCoin;
    public int maxCoinAmmount;
    // Use this for initialization
    public void SpawnCoins(Vector3 startPosition) {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObject();
        coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins,startPosition.y,startPosition.z);
        coin2.SetActive(true);

        GameObject coin3 = coinPool.GetPooledObject();
        coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
        coin3.SetActive(true);
    }
    public void SpawnCoinsV2(Vector3 startPosition)
    {
        int x = Random.Range(0, 100);

        if (x < 100)
        {
            coinSelector = 0;
            if (x < 50)
            {
                coinSelector++;
                if (x < 10)
                {
                    coinSelector++;
                }
            }
        }
        for (int i = (int)Random.Range(0, maxCoinAmmount); 0 < i; i--)
        {

            //(int)Random.Range(0, theObjectPoolsCoin.Length)
            
                
       
            GameObject coin1 = theObjectPoolsCoin[coinSelector].GetPooledObject();
            coin1.transform.position = new Vector3(startPosition.x+(2*i), startPosition.y+(i/2), startPosition.z+ Random.Range(0, 5));
            coin1.SetActive(true);
        }
    }
}
