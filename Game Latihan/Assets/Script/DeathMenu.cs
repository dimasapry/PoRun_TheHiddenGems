using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DeathMenu : MonoBehaviour {

	public Text scoreResult;

	public ScoreManager theScoreManager;

	//private float scoreCountDeath;

	public string mainMenu;


	void Start (){


		//theScoreManager  = gameObject.GetComponent <ScoreManager> ();
	}


	void Update () {
		

		scoreResult.text = ""+ Mathf.Round(theScoreManager.scoreCount);

	}

	public void BackToMainMenu()
	{
		Application.LoadLevel(mainMenu);
	}

	public void RestartGame()
	{
		FindObjectOfType<GameManager>().Reset ();
	}
}
