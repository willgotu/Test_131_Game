﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject thePlatform; // Used to set a platform
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms; // Used to store platforms
    private int platformSelector;
    private float[] platformWidths; // Used to store platform widths
    
    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CopperCoinGenerator theCopperCoinGenerator;
    private SilverCoinGenerator theSilverCoinGenerator;
    private GoldCoinGenerator theGoldCoinGenerator;

    public float randomCopperCoinThreshold;
    public float randomSilverCoinThreshold;
    public float randomGoldCoinThreshold;

    // Use this for initialization
    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length]; 

        /* Goes through all platforms */
        for(int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCopperCoinGenerator = FindObjectOfType<CopperCoinGenerator>();
        theSilverCoinGenerator = FindObjectOfType<SilverCoinGenerator>();
        theGoldCoinGenerator = FindObjectOfType<GoldCoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            
            /* Used to select a radnom sized platform */
            platformSelector = Random.Range(0, theObjectPools.Length);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }

            else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            //Instantiate(/*thePlatform*/ thePlatforms[platformSelector], transform.position, transform.rotation); 

            /* Used to generate platforms in the game world */
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 150f) < randomCopperCoinThreshold)
            {
                theCopperCoinGenerator.SpawnCopperCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            if (Random.Range(0f, 300f) < randomSilverCoinThreshold)
            {
                theSilverCoinGenerator.SpawnSilverCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }


            if (Random.Range(0f, 500f) < randomGoldCoinThreshold)
            {
                theGoldCoinGenerator.SpawnGoldCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

          
        }
    }
}