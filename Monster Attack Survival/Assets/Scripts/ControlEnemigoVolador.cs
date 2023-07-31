using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigoVolador : MonoBehaviour
{

    Direccion direccionActual;
    private float HorizontalSpeed = 0.03f;
    private float VerticalSpeed = 0.5f;
    private float Amplitude = 1f;
    private float Vidas = 1;
    private int cantidadMonedas;
    public GameObject monedaPrefab;
    private Vector3 posicionActual;
    private float LIMI = -11.48f, LIMD = 11.39f;
    private bool tipoVuelo = false;

    void Awake()
    {
        direccionActual = Direccion.ESTE;
        switch (gameObject.tag)
        {

            case "Murcielago":
                Vidas = Random.Range(1, 3);
                cantidadMonedas = Random.Range(1, 3);
                tipoVuelo = true;
                Amplitude = 3f;
            break;

            case "Murcielago Demoniaco":
                Vidas = Random.Range(1, 7);
                cantidadMonedas = Random.Range(1, 5);
                tipoVuelo = false;
                Amplitude = 3f;
                break;

            case "Ojo":
                Vidas = Random.Range(10,30);
                cantidadMonedas = Random.Range(10, 20);
                tipoVuelo = false;
                //Random.Range(0,2) == 0 ? true : false;
                Amplitude = 3f;
                break;

            case "Fantasma":
                Vidas = Random.Range(1, 5);
                cantidadMonedas = Random.Range(1, 5);
                tipoVuelo = false;
                Amplitude = 3f;
                break;
        }

    }

    // Use this for initialization
    void Start()
    {
        posicionActual = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (posicionActual.x > LIMD)
        {
            direccionActual = Direccion.OESTE;
        }

        if (posicionActual.x < LIMI)
        {
            direccionActual = Direccion.ESTE;
        }
    }
    void FixedUpdate()
    {
        
        if (!tipoVuelo)
        {
            if (direccionActual == Direccion.ESTE)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;

                posicionActual.x += HorizontalSpeed;
                posicionActual.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude;
                transform.position = posicionActual;

            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;

                posicionActual.x -= HorizontalSpeed;
                posicionActual.y = Mathf.Tan(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude;
                transform.position = posicionActual;
            }

        }
        else
        {
            if (direccionActual == Direccion.ESTE)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;

                posicionActual.x += HorizontalSpeed;
                posicionActual.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude;
                transform.position = posicionActual;

            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;

                posicionActual.x -= HorizontalSpeed;
                posicionActual.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude;
                transform.position = posicionActual;
            }
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Bala")
        {
            Destroy(other.gameObject);
            Vidas--;
            if (Vidas <= 0)
            {
                Destroy(gameObject);
                InstanciarMonedas();
                GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().AumentarPuntos();
                GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().ActualizarSiguienteNivel();
                GameObject.Find("ControlJuego").GetComponent<ControlJuego>().ActualizarCantidadEnemigos();
            }
         
        }
        if (other.gameObject.tag == "Espada")
        {
            Vidas--;
            if (Vidas <= 0)
            {
                Destroy(gameObject);
                InstanciarMonedas();
                GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().AumentarPuntos();
                GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().ActualizarSiguienteNivel();
                GameObject.Find("ControlJuego").GetComponent<ControlJuego>().ActualizarCantidadEnemigos();
            }

        }

        if (other.gameObject.tag == "EscudoPowerUp")
        {
            Vidas--;
            if (Vidas <= 0)
            {
                Destroy(gameObject);
                InstanciarMonedas();
                GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().AumentarPuntos();
                GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().ActualizarSiguienteNivel();
                GameObject.Find("ControlJuego").GetComponent<ControlJuego>().ActualizarCantidadEnemigos();
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