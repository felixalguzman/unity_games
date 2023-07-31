using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMensajesPuntuacion : MonoBehaviour
{


    private TextMeshProUGUI puntuacionFinalText, nivelPuntuacionFinal, tiempoPuntuacionFinal, enemigosPuntuacionFinal, monedasPuntuacionFinal, powerUpsPuntuacionFinal;

    private AlmacenamientoPersistente almacenamientoPersistente;
    public static int puntuacionFinal = 0, nivelPuntuacion = 0, enemigosPuntuacion = 0, monedasPuntuacion = 0, powerUpsPuntuacion = 0;
    public static float tiempo = 0f;
    // Use this for initialization
    private void Awake()
    {
        GuardarValores();
    }
    void Start()
    {

        almacenamientoPersistente = GetComponent<AlmacenamientoPersistente>();

        puntuacionFinalText = GameObject.Find("PuntuacionValor").GetComponent<TextMeshProUGUI>();



        nivelPuntuacionFinal = GameObject.Find("Nivel").GetComponent<TextMeshProUGUI>();


        tiempoPuntuacionFinal = GameObject.Find("Tiempo").GetComponent<TextMeshProUGUI>();


        enemigosPuntuacionFinal = GameObject.Find("Enemigos").GetComponent<TextMeshProUGUI>();



        monedasPuntuacionFinal = GameObject.Find("Monedas").GetComponent<TextMeshProUGUI>();



        powerUpsPuntuacionFinal = GameObject.Find("PowerUps").GetComponent<TextMeshProUGUI>();



        MostrarPuntuacion();

    }


    public int CalcularPuntuacionFinal()
    {
        int puntuacionFinal = 1;
        //puntuacionFinal *= ControlMensajes.Nivel * ControlJuego.CantidadEnemigosMaxima * ControlMensajes.Monedas;
        puntuacionFinal = nivelPuntuacion * enemigosPuntuacion * monedasPuntuacion;
        return puntuacionFinal;
    }

    public void MostrarPuntuacion()
    {

        puntuacionFinalText.text = CalcularPuntuacionFinal().ToString();
        nivelPuntuacionFinal.text = "Nivel: " + nivelPuntuacion;
        tiempoPuntuacionFinal.text = "Tiempo: " + tiempo;
        enemigosPuntuacionFinal.text = "Enemigos: " + enemigosPuntuacion;
        monedasPuntuacionFinal.text = "Monedas: " + monedasPuntuacion;
        powerUpsPuntuacionFinal.text = "Power-ups: " + powerUpsPuntuacion;
        //puntuacionFinalText.text = CalcularPuntuacionFinal().ToString();
        //nivelPuntuacionFinal.text = "Nivel: " + ControlMensajes.Nivel;
        //tiempoPuntuacionFinal.text = "Tiempo: " + ControlJuego.tiempoInicio;
        //enemigosPuntuacionFinal.text = "Enemigos: " + ControlJuego.CantidadEnemigosMaxima;
        //monedasPuntuacionFinal.text = "Monedas: " + ControlMensajes.Monedas;
        //powerUpsPuntuacionFinal.text = "Power-ups: " + ControlJuego.cantidadPowerUpsRecogidos;

        try
        {
            almacenamientoPersistente.GuardarEstadoJuego(CalcularPuntuacionFinal(), nivelPuntuacion, tiempo, enemigosPuntuacion, monedasPuntuacion, powerUpsPuntuacion);

        }
        catch (System.Exception)
        {


        }
    }

    public void CargarMenu()
    {
        Time.timeScale = 1f;
        nivelPuntuacion = 0;
        ControlMensajes.Nivel = 0;
        tiempo = 0f;
        ControlJuego.tiempoInicio = 0;
        enemigosPuntuacion = 0;
        ControlJuego.CantidadEnemigosMaxima = 0;
        monedasPuntuacion = 0;
        ControlMensajes.Monedas = 0;
        powerUpsPuntuacion = 0;
        ControlJuego.cantidadPowerUpsRecogidos = 0;

        SceneManager.LoadScene("EscenaJuego");

    }

    public void CerrarJuego()
    {
        Application.Quit();
    }


    public void GuardarValores()
    {
        nivelPuntuacion = ControlMensajes.Nivel;
        tiempo = ControlJuego.tiempoInicio;
        enemigosPuntuacion = ControlJuego.CantidadEnemigosMaxima;
        monedasPuntuacion = ControlMensajes.Monedas;
        powerUpsPuntuacion = PowerUp.cantidadPowerups;

    }
}
