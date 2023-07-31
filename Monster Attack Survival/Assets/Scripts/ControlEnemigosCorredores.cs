using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direccion
{
    ESTE = 0,
    OESTE
}
public class ControlEnemigosCorredores : MonoBehaviour
{

    Direccion direccionActual;
    private float LIMI = -11.48f, LIMD = 11.3f;
    private float VelocidadDesplazamiento = 5f;
    private int cantidadMonedas;
    private bool haciaDerecha = true, haciaDerechaAnterior;
    private float Vidas = 1;
    public GameObject monedaPrefab;
    Vector3 desplazamiento;
    Transform posicionActual;
    void Awake()
    {
        switch (gameObject.tag)
        {
            case "Demonio":
                cantidadMonedas = Random.Range(1, 6);
                Vidas = Random.Range(1, 6);
                if (gameObject.transform.position.x < -12.46)
                {
                    VelocidadDesplazamiento = 4f;
                    direccionActual = Direccion.ESTE;
                    haciaDerecha = true;
                }
                else
                {
                    direccionActual = Direccion.OESTE;
                    haciaDerecha = false;
                    VelocidadDesplazamiento = 4f;

                }
                break;

            case "Rata":
                Vidas = 1;
                cantidadMonedas = 1;
                if (gameObject.transform.position.x < -12.4)
                {
                    VelocidadDesplazamiento = 11f;
                    direccionActual = Direccion.ESTE;
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;

                    haciaDerecha = true;
                }
                else
                {
                    VelocidadDesplazamiento = 11f;

                    haciaDerecha = false;
                    direccionActual = Direccion.OESTE;

                }
                break;


            case "Esqueleto":
                Vidas = Random.Range(1, 4);
                cantidadMonedas = Random.Range(1, 4);
                if (gameObject.transform.position.x < -10)
                {
                    VelocidadDesplazamiento = 3f;
                    direccionActual = Direccion.ESTE;


                    haciaDerecha = true;
                }
                else
                {

                    haciaDerecha = false;
                    VelocidadDesplazamiento = 3.1f;
                    direccionActual = Direccion.OESTE;

                }
                break;

            case "Slime Babosa":
                Vidas = Random.Range(1, 6);
                cantidadMonedas = Random.Range(1, 6);
                if (gameObject.transform.position.x < -10)
                {
                    VelocidadDesplazamiento = 2f;
                    direccionActual = Direccion.ESTE;


                    haciaDerecha = true;
                }
                else if(gameObject.transform.position.x > 12f)
                {

                    haciaDerecha = false;
                    direccionActual = Direccion.OESTE;

                }
                break;

            case "Slime":
                Vidas = Random.Range(1, 3);
                cantidadMonedas = 1;
                if (gameObject.transform.position.x < -10)
                {
                    VelocidadDesplazamiento = 0.8f;
                    direccionActual = Direccion.ESTE;


                    haciaDerecha = true;
                }
                else
                {

                    haciaDerecha = false;
                    direccionActual = Direccion.OESTE;

                }
                break;

            case "Poke Feo":
                if (gameObject.transform.position.x < -10)
                {
                    VelocidadDesplazamiento = 3f;
                    direccionActual = Direccion.ESTE;


                    haciaDerecha = true;
                }
                else
                {

                    haciaDerecha = false;
                    direccionActual = Direccion.OESTE;

                }
                break;

            case "Sapo":
                Vidas = Vidas = Random.Range(1, 4);
                cantidadMonedas = Random.Range(1, 4);
                VelocidadDesplazamiento = 1.5f;
                break;

            case "Rana":
                Vidas = 1;
                cantidadMonedas = 1;
                VelocidadDesplazamiento = 1.5f;
                direccionActual = Direccion.OESTE;
                haciaDerecha = false;
                VelocidadDesplazamiento = 1.2f;
                break;
        }
    }

    private float vida;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        desplazamiento = Vector3.zero;

        if (direccionActual == Direccion.OESTE)
        {
            desplazamiento.x = -1;
        }

        if (direccionActual == Direccion.ESTE)
        {
            desplazamiento.x = 1;
        }



        gameObject.transform.Translate(desplazamiento * Time.deltaTime * VelocidadDesplazamiento);

        DetectarColision();

        haciaDerecha = direccionActual == Direccion.ESTE ? true : false;

        if (haciaDerecha != haciaDerechaAnterior)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = !haciaDerecha;

            haciaDerechaAnterior = haciaDerecha;
        }

    }

    void DetectarColision()
    {

        posicionActual = gameObject.transform;

        if (posicionActual.position.x > LIMD)
        {
            direccionActual = Direccion.OESTE;
        }

        if (posicionActual.position.x < LIMI)
        {
            direccionActual = Direccion.ESTE;
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Bala")
        {
            Vidas--;
            Destroy(other.gameObject);

            if (Vidas <= 0)
            {
                Destroy(gameObject);
                GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().AumentarPuntos();
                GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().ActualizarSiguienteNivel();
                GameObject.Find("ControlJuego").GetComponent<ControlJuego>().ActualizarCantidadEnemigos();

                InstanciarMonedas();

            }
        }
        if (other.gameObject.tag == "Espada")
        {
            Vidas--;
            if (Vidas <= 0)
            {
                Destroy(gameObject);
                GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().AumentarPuntos();
                GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().ActualizarSiguienteNivel();
                GameObject.Find("ControlJuego").GetComponent<ControlJuego>().ActualizarCantidadEnemigos();

                InstanciarMonedas();
            }
        }

        if (other.gameObject.tag == "EscudoPowerUp" && other.gameObject.GetComponent<PowerUp>().poweruPActivo)
        {
            Vidas--;
            GameObject.FindGameObjectWithTag("EscudoPowerUp").GetComponent<PowerUp>().DisminuirVidaEscudo();
            if (Vidas <= 0)
            {
                Destroy(gameObject);
                GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().AumentarPuntos();
                GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().ActualizarSiguienteNivel();
                GameObject.Find("ControlJuego").GetComponent<ControlJuego>().ActualizarCantidadEnemigos();
                InstanciarMonedas();
            }
        }
    }


    void InstanciarMonedas()
    {
        for (int i = 0; i < cantidadMonedas; i++)
        {
            Instantiate(monedaPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f), Quaternion.identity);
        }
    }
}
