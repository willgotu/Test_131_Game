using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpPoints : MonoBehaviour {

    public int scoreToGive;

    private ScoreManager theScoreManager;

    private AudioSource CoinPickUpSound;

	// Use this for initialization
	void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();

        CoinPickUpSound = GameObject.Find("CoinPickUpSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);

            if (CoinPickUpSound.isPlaying)
            {
                CoinPickUpSound.Stop();
                CoinPickUpSound.Play();
            }
            else
            {
                CoinPickUpSound.Play();
            }
        }
    }
}
