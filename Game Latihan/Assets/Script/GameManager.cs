using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	public Vector3 platformStartPoint;

	public Transform platformGeneratorAir;
	public Vector3 platformStartPointAir;

	public Transform platformGeneratorBayanganAir;
	public Vector3 platformStartPointBayanganAir;

	public Transform platformGeneratorKota;
	public Vector3 platformStartPointKota;

	public Transform platformGeneratorAwan;
	public Vector3 platformStartPointAwan;

	public PlayerController thePlayer;
	public Vector3 playerStartPoint;

	public Transform platformGeneratorSuasanaKota;
	public Vector3 platformStartPointSuasanaKota;

	private PlatformDestroyer[] platformList;

	private ScoreManager theScoreManager;

	public GameObject heartObjectCanvas;
	public GameObject scoreObjectCanvas;
	public DeathMenu theDeathScreen;
	public GameObject pauseButton;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		platformStartPointAir = platformGeneratorAir.position;
		platformStartPointAwan = platformGeneratorAwan.position;
		platformStartPointBayanganAir = platformGeneratorBayanganAir.position;
		platformStartPointKota = platformGeneratorKota.position;
		playerStartPoint = thePlayer.transform.position;
		platformStartPointSuasanaKota = platformGeneratorSuasanaKota.position;
		theScoreManager = FindObjectOfType <ScoreManager> ();
	}

	public void RestartGame (){

		//StartCoroutine ("RestartGameCo");
		pauseButton.SetActive (false);
		theScoreManager.scoreIncrease = false;
		thePlayer.gameObject.SetActive (false);
		theDeathScreen.gameObject.SetActive (true);
		heartObjectCanvas.gameObject.SetActive (false);
		scoreObjectCanvas.gameObject.SetActive (false);
	}


	public void Reset()
	{

		pauseButton.SetActive (true);
		heartObjectCanvas.gameObject.SetActive (true);
		scoreObjectCanvas.gameObject.SetActive (true);
		theDeathScreen.gameObject.SetActive (false);
		platformList = FindObjectsOfType <PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}

		platformGenerator.position = platformStartPoint;
		platformGeneratorSuasanaKota.position = platformStartPointSuasanaKota;
		thePlayer.transform.position = playerStartPoint;
		platformGeneratorAir.position = platformStartPointAir;
		platformGeneratorAwan.position = platformStartPointAwan;
		platformGeneratorBayanganAir.position = platformStartPointBayanganAir;
		platformGeneratorKota.position = platformStartPointKota;

		thePlayer.transform.position=playerStartPoint;
		thePlayer.health = 3;

		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncrease = true;
	}

	/*public IEnumerator RestartGameCo (){

		theScoreManager.scoreIncrease = false;
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		platformList = FindObjectsOfType <PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}

		platformGenerator.position = platformStartPoint;
		thePlayer.transform.position = playerStartPoint;
		platformGeneratorAir.position = platformStartPointAir;
		platformGeneratorAwan.position = platformStartPointAwan;
		platformGeneratorBayanganAir.position = platformStartPointBayanganAir;
		platformGeneratorKota.position = platformStartPointKota;

		thePlayer.transform.position=playerStartPoint;

		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncrease = true;

	}*/

}
