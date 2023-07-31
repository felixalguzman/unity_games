﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GamePaused = false;
	public GameObject pauseMenuUI;
	
	private void Start() {
		Resume();
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GamePaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
		
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GamePaused = false;
	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GamePaused = true;
	}

	public void CargarMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
	}

	public void CerrarJuego()
	{
		Application.Quit();
	}

	
}
