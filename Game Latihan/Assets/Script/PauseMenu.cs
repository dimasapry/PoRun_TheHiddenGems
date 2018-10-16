using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public string mainMenu;

	public GameObject pauseMenu;

	public void PauseButton()
	{
		Time.timeScale = 0f;
		pauseMenu.gameObject.SetActive (true);
	}

	public void Resume()
	{
		pauseMenu.gameObject.SetActive (false);
		Time.timeScale = 1f;
		//yield return new WaitForSeconds (0.5f);

	}

	public void BackToMainMenu()
	{
		Time.timeScale = 1f;
		pauseMenu.gameObject.SetActive (false);
		Application.LoadLevel(mainMenu);
	
	}

	public void Restart()
	{
		pauseMenu.gameObject.SetActive (false);
		FindObjectOfType<GameManager>().Reset ();
		Time.timeScale = 1f;
		//yield return new WaitForSeconds (0.5f);
	}
}
