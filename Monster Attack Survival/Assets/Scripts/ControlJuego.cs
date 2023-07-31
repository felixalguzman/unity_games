using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJuego : MonoBehaviour
{

    public List<GameObject> EnemigosCorredoresPrefabs;
    private int CantidadMinimaEnemigos = 12, CantidadMaximaEnemigos = 20, CantidadEnemigosInstanciados = 0, CantidadEnemigosNuevos,
    enemigosEliminar = 0;
    private float TiempoInstanciarEnemigos = 0.99f, TiempoInstanciarPowerUps = 30f;
    public static float tiempoInicio = 0f;
    public static int cantidadVidasJugador = 10, CantidadEnemigos = 0, CantidadEnemigosMaxima = 0, cantidadPowerUpsRecogidos = 0;
    public bool jugadorGolpeado = false;
    public GameObject jugadorActivo;
    public GameObject[] powerUpPrefabs;
    public GameObject[] vidasJugador;
    private int CantidadTiempoPowerUp = 15;
    public GameObject[] tiempoPowerUp;
    public bool entro, Reiniciar = false;

    void Awake()
    {
        Destroy(GameObject.Find("MUSIC"));

        SeleccionarPersonaje();
        ReiniciarValores();
        ReiniciarTiempoPowerUp();
    }
    // Use this for initialization
    void Start()
    {




        NuevoNivel();
        // InvokeRepeating("InstanciarPowerUps",1f, Random.Range(10f,TiempoInstanciarPowerUps) );
        jugadorGolpeado = false;
        // Instantiate(escudoPrefab, new Vector3(-4.919099f, 9.87f), Quaternion.identity).GetComponent<PowerUp>().InicializarPowerUp(TipoPowerUp.Escudo,jugadorActivo);
        //Instantiate(vidaPowerUpPrefab, new Vector3(-4.919099f, 9.87f), Quaternion.identity).GetComponent<CaidaLibre>().RealizarCaidaLibre(0, -4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!entro)
        {
            if (GameObject.FindGameObjectWithTag("VelocidadPowerUp") != null && GameObject.FindGameObjectWithTag("VelocidadPowerUp").GetComponent<PowerUp>().poweruPActivo && GameObject.FindGameObjectWithTag("VelocidadPowerUp").GetComponent<PowerUp>().tipo == TipoPowerUp.VelocidadJugador)
            {
                InvokeRepeating("RestarTiempoPowerUp", 1f, 1f);
                entro = true;
            }

            // RestarTiempoPowerUp();
            // timestamp = Time.time + tiempoActivo;


            // Debug.Log(poweruPActivo);
        }



        if (jugadorGolpeado && cantidadVidasJugador != 0)
        {
            // Debug.Log("Vidas " + cantidadVidasJugador);
            DisminuirVida();
            jugadorGolpeado = false;
        }

        // if (CantidadEnemigosInstanciados == CantidadEnemigosNuevos)
        // {
        //     CancelInvoke("InstanciarEnemigosCorredores");
        // }

        if (CantidadEnemigosInstanciados == CantidadEnemigosNuevos)
        {
            CancelInvoke("InstanciarEnemigosCorredores");
            Debug.Log("terminar instanciar");
        }



        if (cantidadVidasJugador == 0)
        {
            if (jugadorActivo.tag == "Player")
            {
                SceneManager.LoadScene("EscenaFinalTirador");
                tiempoInicio = Time.time - tiempoInicio;
                SceneManager.LoadScene("Puntuacion");
                ReiniciarValores();

            }
            else if ((jugadorActivo.tag == "Player2"))
            {
                SceneManager.LoadScene("EscenaFinalCaballero");
                tiempoInicio = Time.time - tiempoInicio;
                SceneManager.LoadScene("Puntuacion");
                ReiniciarValores();
            }

        }

        if (CantidadTiempoPowerUp == 0)
        {
            CancelInvoke("RestarTiempoPowerUp");
            ReiniciarTiempoPowerUp();
            entro = false;
            // tiempoActivo = 0;

            if (jugadorActivo == GameObject.FindGameObjectWithTag("Player2"))
            {
                GameObject.Find("Caballero").GetComponent<ControlJugador>().RestaurarValoresMovimientos();
            }
            else
            {
                GameObject.Find("Tirador").GetComponent<ControlJugador>().RestaurarValoresMovimientos();
            }


        }

        if (cantidadVidasJugador > 0 && Random.Range(0, 101) < 0.01)
        {
            InstanciarPowerUps();
            //   InvokeRepeating("InstanciarPowerUps",3f,Random.Range(4f,10f));
        }


    }


    void InstanciarEnemigosCorredores()
    {
        Instantiate(EnemigosCorredoresPrefabs[Random.Range(0, 10)], new Vector3(Random.Range(0, 2) == 0 ? -12.2f : 12.8f, -1.58f), Quaternion.identity);
        CantidadEnemigosInstanciados++;

    }

    void InstanciarPowerUps()
    {
        Instantiate(powerUpPrefabs[Random.Range(0, 4)], new Vector3(Random.Range(-11.2f, 9.92f), 9.95f), Quaternion.identity).GetComponent<CaidaLibre>().RealizarCaidaLibre(0, -4f);
    }

    public void AumentarVida()
    {
        cantidadVidasJugador++;
        vidasJugador[cantidadVidasJugador - 1].SetActive(true);
    }

    public void DisminuirVida()
    {
        cantidadVidasJugador--;
        vidasJugador[cantidadVidasJugador].SetActive(false);
    }

    void SeleccionarPersonaje()
    {
        if (ControlMenu.caballeroSeleccionado == 0 && ControlMenu.tiradorSeleccionado == 0)
        {
            ControlMenu.caballeroSeleccionado = Random.Range(0, 2) == 0 ? 1 : 0;
        }

        if (ControlMenu.caballeroSeleccionado == 1)
        {
            jugadorActivo = GameObject.FindGameObjectWithTag("Player2");
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
        }
        else if (ControlMenu.tiradorSeleccionado == 1)
        {
            jugadorActivo = GameObject.FindGameObjectWithTag("Player");
            GameObject.FindGameObjectWithTag("Player2").SetActive(false);
        }

    }

    public void ReiniciarValores()
    {
        CantidadMinimaEnemigos = 12;
        CantidadMaximaEnemigos = 20;
        CantidadEnemigosInstanciados = 0;
        CantidadEnemigosNuevos = 0;
        CantidadEnemigos = 0;
        cantidadVidasJugador = 10;
        // CantidadEnemigosMaxima =0;
        cantidadPowerUpsRecogidos = 0;
        jugadorGolpeado = false;
        PauseMenu.GamePaused = false;
    }


    void NuevoNivel()
    {
        CantidadEnemigos = Random.Range(CantidadMinimaEnemigos, CantidadMaximaEnemigos);
        CantidadEnemigosNuevos = CantidadEnemigos;
        CantidadEnemigosInstanciados = 0;
        enemigosEliminar = 0;
        ControlMensajes.SiguienteNivel = CantidadEnemigos;
        GetComponent<ControlMensajes>().NuevoNivel(CantidadEnemigos);
        GetComponent<ControlMensajes>().AumentarNivel();
        Reiniciar = false;
        InvokeRepeating("InstanciarEnemigosCorredores", 4f, TiempoInstanciarEnemigos);
        Debug.Log("cantidad enemigos: " + CantidadEnemigos);
    }

    public void ActualizarCantidadEnemigos()
    {
        CantidadEnemigos--;
        // Debug.Log("Cantidad de enemigos eliminados: " + CantidadEnemigos);
        CantidadEnemigosMaxima++;
        enemigosEliminar++;
        if (CantidadEnemigos == 0)
        {
            if (CantidadEnemigos == 0)
            {
                // Debug.Log("Cant enemigos: " + CantidadEnemigos);
                CantidadEnemigos = Random.Range(CantidadMinimaEnemigos, CantidadMaximaEnemigos);



                // Debug.Log("Cant enemigos: " + CantidadEnemigos);
                Invoke("NuevoNivel", 3f);

            }
        }
    }

    void GuardarPuntuacion()
    {
        ControlMensajesPuntuacion.enemigosPuntuacion = CantidadEnemigosMaxima;
    }

    private void RestarTiempoPowerUp()
    {
        // Debug.Log("tiempo restante: " + CantidadTiempoPowerUp);
        CantidadTiempoPowerUp--;
        tiempoPowerUp[CantidadTiempoPowerUp].SetActive(false);
    }

    /// <summary>
    /// Reiniciar el tiempo del power up
    /// </summary>
    void ReiniciarTiempoPowerUp()
    {
        foreach (GameObject item in tiempoPowerUp)
        {
            item.SetActive(true);
        }
    }
}
