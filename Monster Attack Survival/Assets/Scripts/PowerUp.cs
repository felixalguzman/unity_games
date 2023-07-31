using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TipoPowerUp
{
    Escudo,
    Bomba,
    VelocidadJugador,
    Vida
}

public class PowerUp : MonoBehaviour
{
    public TipoPowerUp tipo;
    public GameObject personaje;

    private float tiempoActivo = 1f, timestamp;


    public bool poweruPActivo;
    public static int cantidadPowerups=0;
    private int vidaEscudo = 3;




    // Use this for initialization


    private void Awake()
    {
        personaje = GameObject.Find("ControlJuego").GetComponent<ControlJuego>().jugadorActivo;
    }
    void Start()
    {
        DesaparecerTrasTiempo();
    }

    public void InicializarPowerUp(TipoPowerUp tipo, GameObject personaje)
    {
        this.tipo = tipo;
        this.personaje = personaje;
    }
    private void ActivarPowerUp()
    {
        switch (tipo)
        {
            case TipoPowerUp.Escudo:
                gameObject.GetComponent<MovimientoCircularUniforme>().ActivarMovimientoCircular(personaje.transform, Vector3.zero, new Vector3(5, 5));
                break;
            case TipoPowerUp.Bomba:
                DestruirTodosLosEnemigos();
                Destroy(gameObject);
                break;
            case TipoPowerUp.VelocidadJugador:

                if (GameObject.Find("ControlJuego").GetComponent<ControlJuego>().jugadorActivo.tag == "Player")
                    personaje.GetComponent<ControlJugador>().velocidadMovimientoTirador += 3f;
                else
                {
                    personaje.GetComponent<ControlJugador>().velocidadMovimientoCaballero += 3f;
                    personaje.GetComponent<ControlJugador>().fuerzaSalto += 0.2f;
                }
                gameObject.transform.Translate(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 10f));

                // Destroy(gameObject);
                break;
            case TipoPowerUp.Vida:
                if (ControlJuego.cantidadVidasJugador < 10)
                    GameObject.Find("ControlJuego").GetComponent<ControlJuego>().AumentarVida();
                Destroy(gameObject);
                break;

        }
        // Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
            ActivarPowerUp();
            cantidadPowerups++;
            poweruPActivo = true;
        }

        if (other.gameObject.tag == "Suelo")
        {


            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
            gameObject.GetComponent<CaidaLibre>().velocidadInicialY = 0f;
            gameObject.GetComponent<CaidaLibre>().aceleracionY = 0f;

        }

    }


    void DestruirTodosLosEnemigos()
    {
        string[] nombresTags = "Demonio,Esqueleto,Fantasma,Murcielago Demoniaco,Poke Feo,Rata,Sapo,Slime,Slime Babosa,Bola".Split(',');
        List<string> listaTags = new List<string>(nombresTags.Length);
        listaTags.AddRange(nombresTags);
        listaTags.Reverse();
        // Debug.Log(listaTags);

        GameObject[] enemigosADestruir;
        foreach (string tag in listaTags)
        {
            enemigosADestruir = GameObject.FindGameObjectsWithTag(tag);
            if (enemigosADestruir.Length > 0)
            {
                foreach (GameObject enemigo in enemigosADestruir)
                {
                    GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().AumentarPuntos();
                    GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().ActualizarSiguienteNivel();
                    GameObject.Find("ControlJuego").GetComponent<ControlJuego>().ActualizarCantidadEnemigos();
                    enemigo.GetComponent<Animator>().Play("Explosion");
                    Destroy(enemigo, 1.2f);
                    //StartCoroutine(DestruirEnemigo(enemigo));

                }
            }

        }
    }

    void DesaparecerTrasTiempo()
    {
        if (!poweruPActivo)
        {
            if (gameObject.tag == "VelocidadPowerUp")
            {
                Destroy(gameObject, 7f);
            }
            else if (gameObject.tag == "BombaPowerUp")
            {
                Destroy(gameObject, 5f);
            }
            else if (gameObject.tag == "VidaPowerUp")
            {
                Destroy(gameObject, 8f);
            }
            else if (gameObject.tag == "EscudoPowerUp")
            {
                Destroy(gameObject, 8f);
            }

        }
    }


    public void DisminuirVidaEscudo()
    {
        vidaEscudo--;

        if (vidaEscudo <= 0)
        {
            Destroy(gameObject);
        }
    }



}