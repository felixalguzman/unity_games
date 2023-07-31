using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPausaMenu : MonoBehaviour
{

    public static bool gameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject musica;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }

    }

    public void Pausar()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
        musica.GetComponent<AudioSource>().Pause();


    }

    public void Continuar()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
        musica.GetComponent<AudioSource>().Play();

        if (pauseMenuUI.activeInHierarchy && !musica.GetComponent<AudioSource>().isPlaying)
            musica.GetComponent<AudioSource>().Play();
    }

    public void CargarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void AbrirTienda()
    {
        Continuar();
        SceneManager.LoadScene("Tienda");
    }
}
