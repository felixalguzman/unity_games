using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPausaMenu : MonoBehaviour {

    public static bool gameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject textos;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPause)
            {
                Pausar();
            }
            else
            {

                Continuar();
            }
        }
	}

    public void Pausar()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
        GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Pause();

        
    }

     public void Continuar()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
        GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play();

        if (pauseMenuUI.activeInHierarchy && !textos.GetComponent<AudioSource>().isPlaying)
            textos.GetComponent<AudioSource>().Play();
    }

    public void CargarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
