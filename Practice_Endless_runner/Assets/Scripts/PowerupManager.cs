﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {

    private bool doublePoints;
    private bool safeMode;

    private bool powerupActive;

    private float powerupLengthCounter;

    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;

    private float normalPointsPerSecond;
    private float spikeRate;


    private PlatformDestroyer[] spikeList;

    private GameManager theGameManager;

    public AudioSource powerupSound;

    // Use this for initialization
    void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        theGameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if (theGameManager.powerupReset)
            {
                powerupLengthCounter = 0;
                theGameManager.powerupReset = false;
            }

            if (doublePoints)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2;
                theScoreManager.shouldDouble = true;
            }

            if (safeMode)
            {
                thePlatformGenerator.randomSpikeThreshold = 0;
            }

            if(powerupLengthCounter <= 0)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                theScoreManager.shouldDouble = false;
                thePlatformGenerator.randomSpikeThreshold = spikeRate;
                powerupActive = false;
            }
        }
	}

    public void ActivatePowerUp(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerupLengthCounter = time;

        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        spikeRate = thePlatformGenerator.randomSpikeThreshold;

        powerupSound.Play();

        if (safeMode)
        {
            spikeList = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < spikeList.Length; i++)
            {
                if (spikeList[i].gameObject.name.Contains("Spikes"))
                {
                    spikeList[i].gameObject.SetActive(false);
                }
            }
        }

        powerupActive = true;
    }
}
