using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigoVoladorJefe : MonoBehaviour {
    private float LIMNJefe = 0f, LIMSJefe = 0f, LIMEJefe = 0f, LIMOJefe = 0f;
    private bool tipoVuelo;
    Direccion direccionActual;
    public GameObject bolaFuego;
    private float Vidas = 1;
    private int cantidadMonedas;
    private float HorizontalSpeed = 0.03f;
    private float VerticalSpeed = 0.5f;


    private void Awake()
    {
        direccionActual = Direccion.ESTE;
        Vidas = Random.Range(10, 30);
        cantidadMonedas = Random.Range(10, 20);
        tipoVuelo = false;
        //Random.Range(0,2) == 0 ? true : false;
    }
    // Use this for initialization
    void Start () {
        tipoVuelo = false;
        LimitesJefe();
	}
	
	// Update is called once per frame
	void Update () {

            if (!tipoVuelo)
            {
                direccionActual = Direccion.ESTE;
                gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, gameObject.transform.position.x, LIMEJefe), Mathf.Clamp(gameObject.transform.position.y, LIMNJefe, LIMSJefe));
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                if (gameObject.transform.position.x < LIMEJefe)
                {
                    gameObject.transform.Translate(new Vector3((gameObject.transform.position.x + 1) * Time.time * HorizontalSpeed, gameObject.transform.position.y));
                }
                else
                {
                    if (gameObject.transform.position.y >= LIMNJefe)
                    {
                        gameObject.transform.Translate(new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y - 1) * Time.time * VerticalSpeed));
                    }
                    else if (gameObject.transform.position.y <= LIMSJefe)
                    {
                        gameObject.transform.Translate(new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y + 1) * Time.time * VerticalSpeed));
                    }
                }

            }
            else
            {
                direccionActual = Direccion.OESTE;
                gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, LIMOJefe, gameObject.transform.position.x), Mathf.Clamp(gameObject.transform.position.y, LIMNJefe, LIMSJefe));
                if (gameObject.transform.position.x > LIMEJefe)
                {
                    gameObject.transform.Translate(new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.x) * Time.time * HorizontalSpeed);
                }
                else
                {
                    if (gameObject.transform.position.y >= LIMNJefe)
                    {
                        gameObject.transform.Translate(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1) * Time.time * VerticalSpeed);
                    }
                    else if (gameObject.transform.position.y <= LIMSJefe)
                    {
                        gameObject.transform.Translate(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1) * Time.time * VerticalSpeed);
                    }
                }
            }
    }

    void LimitesJefe()
    {
        if (direccionActual == Direccion.ESTE)
        {
            LIMNJefe = 5.44f;
            LIMSJefe = -1.29f;
            LIMEJefe = -10.13f;


        }
        else if (direccionActual == Direccion.OESTE)
        {
            LIMNJefe = 4.46f;
            LIMSJefe = -1.33f;
            LIMOJefe = 9.93f;
        }
    }
}
