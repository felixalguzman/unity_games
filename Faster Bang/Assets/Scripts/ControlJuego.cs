using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJuego : MonoBehaviour {

    public GameObject[] vidasPersonaje;
    public GameObject[] vidasEnemigo;
    int cantVidas = 5, cantVidasEnemigo = 5;

    GameObject flechaJugador;
    GameObject flechaEnemigo;
    public static float tiempoInicioJuego = 0f;
    public static float tiempoInicioJugador = 0f;
    public static float tiempoInicioEnemigo = 0f;
    float diferenciaTiempo = 0f;
    public static bool ganoPartida = false, acabo = false, finalizado = false,juegoGanado = false;
    public TextMesh tiempoJugador;
    public TextMesh tiempoEnemigo;

    private void Awake()
    {
        flechaJugador = GameObject.Find("Flecha");
        flechaEnemigo = GameObject.Find("FlechaEnemigo");
    }
    // Use this for initialization
    void Start() {

        tiempoJugador.text = "0";
        tiempoEnemigo.text = "0";
       
    }

    // Update is called once per frame
    void Update() {


        //if (!acabo && tiempoInicioEnemigo == 0 && tiempoInicioJugador > tiempoInicioJuego)
        //{
        //    flechaJugador.SetActive(false);
        //    vidasPersonaje[cantVidas - 1].SetActive(false);
        //    cantVidas--;
        //    acabo = true;
        //    ganoPartida = false;
        //    Debug.Log("1.Gano el enemigo" + " tiempo jugador " + diferenciaTiempo + " tiempo enemigo " + tiempoInicioEnemigo);
        //}
        //else 
        if (tiempoInicioJuego != 0 && tiempoInicioEnemigo != 0 && !acabo)
        {
            //ganoPartida = tiempoInicioJuego - tiempoInicioJugador  <= 0 ? true: false;
            //Debug.Log("Gano " + ganoPartida + " tiempo jugador: " + tiempoInicioJugador + " tiempo juego " + tiempoInicioJuego + "diferencia " + (tiempoInicioJuego - tiempoInicioJugador));
            acabo = true;
            diferenciaTiempo = 0f;
            Debug.Log("tiempoInicioJuego " + tiempoInicioJuego);
            Debug.Log("tiempoInicioJugador " + tiempoInicioJugador);
            Debug.Log("tiempoInicioEnemigo " + tiempoInicioEnemigo);
            Debug.Log("diferenciaTiempo " + diferenciaTiempo);

            if (tiempoInicioJugador == 0)
            {
                ganoPartida = false;
            }
            else
            {
                diferenciaTiempo = tiempoInicioJugador - tiempoInicioJuego;

                ganoPartida = diferenciaTiempo < tiempoInicioEnemigo ? true : false;
                //tiempoJugador.text = "puntos " + jug;
                

            }
            //Si es true gano el jugador
            //Debug.Log(ganoPartida);
            if (ganoPartida)
            {
                vidasEnemigo[cantVidasEnemigo - 1].SetActive(false);
                cantVidasEnemigo--;
                //flechaEnemigo.SetActive(false);
                Debug.Log("Gano el jugador" + " tiempo jugador " + diferenciaTiempo + " tiempo enemigo " + tiempoInicioEnemigo);
                finalizado = true;
                float fractionDiferencia = diferenciaTiempo - Mathf.Floor(diferenciaTiempo);
                float fractionEnemigo = tiempoInicioEnemigo - Mathf.Floor(tiempoInicioEnemigo);
                tiempoJugador.text = fractionDiferencia.ToString();
                tiempoEnemigo.text = fractionEnemigo.ToString();

            }
            else
            {

                //flechaJugador.SetActive(false);
                vidasPersonaje[cantVidas - 1].SetActive(false);
                cantVidas--;
                Debug.Log("2.Gano el enemigo" + " tiempo jugador " + diferenciaTiempo + " tiempo enemigo " + tiempoInicioEnemigo);
                finalizado = true;
                
                
                float fractionDiferencia = diferenciaTiempo - Mathf.Floor(diferenciaTiempo);
                float fractionEnemigo = tiempoInicioEnemigo - Mathf.Floor(tiempoInicioEnemigo);
                string fraction = fractionDiferencia.ToString();
                Debug.Log(fraction);
                tiempoJugador.text = fractionDiferencia.ToString();
                tiempoEnemigo.text = fractionEnemigo.ToString();
                //Debug.Log(fraction);
            }

        }

        if (cantVidas > 0 && cantVidasEnemigo > 0)
        {
            if (finalizado)
            {
                StartCoroutine(CambiarNivel());
                InicializarVariables();

            }

        }
        else
        {
            if (cantVidasEnemigo == 0)
            {
                juegoGanado = true;
                SceneManager.LoadScene("EscenaFinalGanar");
            }
            else
            {
                juegoGanado = false;
                SceneManager.LoadScene("EscenaFinal");
            }

        }
    }

    IEnumerator CambiarNivel()
    {
        //Debug.Log("Entro");
        acabo = false;
        yield return new WaitForSeconds(4f);
        float tiempoTransicion = GameObject.Find("ScriptsGlobales").GetComponent<ControlTransicionEscena>().ComenzarTransicion(1);
        yield return new WaitForSeconds(tiempoTransicion);
        yield return new WaitForSeconds(4f);
        tiempoTransicion = GameObject.Find("ScriptsGlobales").GetComponent<ControlTransicionEscena>().ComenzarTransicion(-1);
        yield return new WaitForSeconds(tiempoTransicion);
        
        RepetirJuego();
        //SceneManager.LoadScene("EscenaJuego");
    }

    void InicializarVariables()
    {
        tiempoInicioJuego = 0f;
        tiempoInicioJugador = 0f;
        tiempoInicioEnemigo = 0f;
        diferenciaTiempo = 0f;
        //ganoPartida = false;

        finalizado = false;
        
    }

    void RepetirJuego()
    {
        tiempoInicioJuego = 0f;
        GameObject.FindGameObjectWithTag("Arquero").GetComponent<ControlArquero>().InicializarElementos();
        GameObject.FindGameObjectWithTag("Enemigo").GetComponent<ControlEnemigo>().InicializarElementos();
        GameObject.Find("Textos").GetComponent<ControlMensajes>().InicializarElementos();
    }
}
