using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {

	private bool doublePoints;
	private bool heartPlus;
	private bool maxHealth;



	public bool powerupActive;

	public float powerupLengthCounter;

	private ScoreManager theScoreManager;
	private PlayerController thePlayer;

	private float normalPointPerSecond;
	private int normalHeart;

	// Use this for initialization
	void Start () {

		theScoreManager = FindObjectOfType<ScoreManager> ();
		thePlayer = FindObjectOfType<PlayerController> ();


	}


	// Update is called once per frame
	void Update () {

		if (powerupActive)
		
		{
			powerupLengthCounter -= Time.deltaTime;

		/*	if(normalHeart > 3)
			{
				normalHeart = 2;
			}

			if(normalHeart <=0)
			{
				normalHeart = 0;
			}*/


			if (doublePoints) {
				theScoreManager.pointsPerSecond = normalPointPerSecond * 3f;
			}

			if (heartPlus && normalHeart<3) {
				thePlayer.health = normalHeart + 1;

			}
				
			if (powerupLengthCounter <= 0) {
				theScoreManager.pointsPerSecond = normalPointPerSecond;

				powerupActive = false;

			}
		}

	



		
	}


	public void ActivatePowerup (bool pointsPowerupManager, bool heartPowerupManager, float time )

	{
		doublePoints = pointsPowerupManager;
		heartPlus = heartPowerupManager;
		powerupLengthCounter = time;

		normalPointPerSecond = theScoreManager.pointsPerSecond;
		normalHeart = thePlayer.health;

		powerupActive = true;

	}


}
