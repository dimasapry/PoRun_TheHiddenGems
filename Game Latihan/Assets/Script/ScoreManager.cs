using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public float scoreCount;
	public bool scoreIncrease;
	public float pointsPerSecond;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreIncrease) {
			scoreCount += pointsPerSecond * Time.deltaTime;
		}

		scoreText.text = "Score: " + Mathf.Round (scoreCount);
		
	}
}
