using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using System.IO;

public class ControlOpciones : MonoBehaviour
{

    public AudioSource sonidoSobreMenu;
    public AudioMixer audioMixerMusica;
    public AudioMixer audioMixerEfectos;
    private float volumenMusica, volumenEfectos;

    private int seleccion = 0;
    public TextMeshProUGUI ruta;

    AlmacenamientoPersistente almacenamientoPersistente;

    void Start()
    {
        almacenamientoPersistente = GameObject.Find("Almacenamiento").GetComponent<AlmacenamientoPersistente>();
    }
    public void Jugar()
    {
        if (seleccion != 0)
        {
            switch (seleccion)
            {
                case 1:
                    almacenamientoPersistente.GuardarModoJuego("muyfacil");
                    break;

                case 2:
                    almacenamientoPersistente.GuardarModoJuego("facil");
                    break;

                case 3:
                    almacenamientoPersistente.GuardarModoJuego("normal");
                    break;

                case 4:
                    almacenamientoPersistente.GuardarModoJuego("dificil");
                    break;

            }

            if (almacenamientoPersistente.ObtenerHistoriaIniciada())
            {
                SceneManager.LoadScene("EscenaNivel1");
            }
            else
            {
                SceneManager.LoadScene("EscenaHistoria");
            }
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Application.Quit();
    }
    public void setVolumenMusica(float volume)
    {
        volumenMusica = volume;
        audioMixerMusica.SetFloat("musica", volume);
    }

    public void setVolumenEfectos(float volume)
    {
        volumenEfectos = volume;
        audioMixerEfectos.SetFloat("efectos", volume);
    }

    public void setCalidad(int calidadIndex)
    {
        QualitySettings.SetQualityLevel(calidadIndex);
    }

    public void SilenciarMusica(bool seleccion)
    {

        GameObject[] musica = GameObject.FindGameObjectsWithTag("Musica");

        foreach (var item in musica)
        {
            item.GetComponent<AudioSource>().mute = !seleccion;
        }

    }

    public void SilenciarEfectos(bool seleccion)
    {
        GameObject[] efectos = GameObject.FindGameObjectsWithTag("Efectos");

        foreach (var item in efectos)
        {
            item.GetComponent<AudioSource>().mute = !seleccion;
        }
    }

    public void SobreBoton()
    {
        sonidoSobreMenu.Play();
    }

    /// <summary>
    /// Funcion para guardar el juego
    /// </summary>
    public void GuardarJuego()
    {
        string path = Application.persistentDataPath;
        string archivo = "RUTA: " + path + "/temporal.xml";

        ruta.text = archivo;
        int dinero = almacenamientoPersistente.ObtenerDinero();
        int nivelItem1 = almacenamientoPersistente.ObtenerNivelItem1();
        int nivelItem2 = almacenamientoPersistente.ObtenerNivelItem2();
        int nivelItem3 = almacenamientoPersistente.ObtenerNivelItem3();
        int nivelItem4 = almacenamientoPersistente.ObtenerNivelItem4();
        int dineroItem1 = almacenamientoPersistente.ObtenerDineroItem1();
        int dineroItem2 = almacenamientoPersistente.ObtenerDineroItem2();
        int dineroItem3 = almacenamientoPersistente.ObtenerDineroItem3();
        int dineroItem4 = almacenamientoPersistente.ObtenerDineroItem4();
        int puntuacion = almacenamientoPersistente.ObtnerPuntuacion();
        int nivel = almacenamientoPersistente.ObtenerNivel();
        string modo = almacenamientoPersistente.ObtenerModoJuego();

        almacenamientoPersistente.GuardarEstadoJuego(dinero, nivelItem1, nivelItem2, nivelItem3, nivelItem4, dineroItem1, dineroItem2, dineroItem3, dineroItem4, puntuacion, nivel, modo);

        //GuardarPartida
    }

    /// <summary>
    /// Funcion para cargar el juego guardado
    /// </summary>
    public void CargarJuego()
    {

        //CargarPartida

    }

    public void ReiniciarJuego()
    {
        //ReiniciarJuego
        ruta.text = "REINICIADO!";
        almacenamientoPersistente.HistoriaIniciada(0);
        almacenamientoPersistente.GuardarEstadoJuego(0, 1, 1, 1, 1, 100, 200, 300, 400, 0, 1, "muyfacil");
    }

    public void ElegirModo(int modo)
    {
        seleccion = modo;


    }
}
