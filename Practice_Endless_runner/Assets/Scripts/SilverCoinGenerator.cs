using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoinGenerator : MonoBehaviour {
    public ObjectPooler coinPool;

    public float distanceBetweenCoins;
    public float heightOfCoins;

    public void SpawnSilverCoins(Vector3 startPosition)
    {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = new Vector3(startPosition.x, startPosition.y + heightOfCoins, startPosition.z);
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObject();
        coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y + heightOfCoins, startPosition.z);
        coin2.SetActive(true);
    }
}
