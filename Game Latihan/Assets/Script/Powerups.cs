using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

	public bool doublePoints;

	public bool heartPlus;

	public float powerupLength;

	private PowerupManager thePowerupManager;


	// Use this for initialization
	void Start () {

		thePowerupManager = FindObjectOfType<PowerupManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D (Collision2D others)

	{
		if (others.gameObject.tag == "Player") 
		{
			thePowerupManager.ActivatePowerup (doublePoints, heartPlus, powerupLength);
		}
		gameObject.SetActive (false);
	}

}
