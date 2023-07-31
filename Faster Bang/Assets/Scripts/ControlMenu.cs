using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour {

    public AudioSource sobreOpcionSonido;
    public AudioSource fueraOpcionSonido;
    AudioSource sonidoPrincipal;
    public GameObject sonido;
    


    void Awake()
    {
        sonido = GameObject.Find("MUSIC");

        if (sonido == null)
        {
            sonidoPrincipal = GameObject.Find("Rise of spirit").GetComponent<AudioSource>();
            sonidoPrincipal.name = "MUSIC";
            sonidoPrincipal.Play();
            DontDestroyOnLoad(sonidoPrincipal);
        }
        else
        {
            if (sonido.name != "MUSIC")
            {
                Destroy(sonido);
            }
        }
    }
    // Use this for initialization
    void Start () {
        //sonidoPrincipal = GameObject.Find("Audio Principal").GetComponent<AudioSource>();

        //audioSource.clip = sonidoPrincipal;
        //audioSource.volume = 0.3f;
        //audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseExit()
    {
        gameObject.transform.localScale /= 1.1f;
        fueraOpcionSonido.Play();
    }

    void OnMouseEnter()
    {
        gameObject.transform.localScale *= 1.1f;
        sobreOpcionSonido.Play();
    }

    void OnMouseUp()
    {
        switch (gameObject.name)
        {
            case "JugarText":
                SceneManager.LoadScene("EscenaJuego");
                break;
            case "CreditosText":
                //DontDestroyOnLoad(sonidoPrincipal);
                SceneManager.LoadScene("EscenaCreditos");
                break;
            case "SalirText":
                Application.Quit();
                break;
        }
    }

}
