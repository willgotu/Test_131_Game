using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinGenerator : MonoBehaviour {
    public ObjectPooler coinPool;

    public float distanceBetweenCoins;
    public float heightOfCoins;

    public void SpawnGoldCoins(Vector3 startPosition)
    {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y + heightOfCoins, startPosition.z);
        coin1.SetActive(true);
    }
}
