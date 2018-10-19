using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DeathMenu : MonoBehaviour {

	public Text scoreResult;
	public Text predicateText;
	public ScoreManager theScoreManager;


	public Image imageResult;
	public Sprite foreignTourist;
	public Sprite domesticTourist;
	public Sprite localPeople;

	//private float scoreCountDeath;

	public string mainMenu;


	void Start (){


		//theScoreManager  = gameObject.GetComponent <ScoreManager> ();
	}


	void Update () {
		
		if (theScoreManager.scoreCount < 500) {
			imageResult.sprite = foreignTourist;
			predicateText.text = "FOREIGN TOURIST";
		} else if ( 500 <= theScoreManager.scoreCount && theScoreManager.scoreCount < 1000) {
			imageResult.sprite = domesticTourist;
			predicateText.text = "DOMESTIC TOURIST";
		} else if (theScoreManager.scoreCount >=1000){
			imageResult.sprite = localPeople;
			predicateText.text = "LOCAL PEOPLE";}



		scoreResult.text = "Scores: "+ Mathf.Round(theScoreManager.scoreCount);

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
