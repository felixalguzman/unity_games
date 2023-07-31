using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoRectilineoUniformementeVariado : MonoBehaviour {

    
    float _velocidadInicial = 0, _aceleracion = 0;
    Vector3 direccion;
	// Use this for initialization
	void Start ()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<ControlJugador>().arriba)
        {
            direccion = new Vector3(0, _velocidadInicial * Time.deltaTime + _aceleracion * Mathf.Pow(Time.deltaTime, 2) / 2);

        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<ControlJugador>().diagonalDerecha)
        {
            direccion = new Vector3(_velocidadInicial * Time.deltaTime + _aceleracion * Mathf.Pow(Time.deltaTime, 2) / 2, _velocidadInicial * Time.deltaTime + _aceleracion * Mathf.Pow(Time.deltaTime, 2) / 2);
        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<ControlJugador>().diagonalIzquierda)
        {
            direccion = new Vector3((_velocidadInicial * Time.deltaTime + _aceleracion * Mathf.Pow(Time.deltaTime, 2) / 2) * -1, _velocidadInicial * Time.deltaTime + _aceleracion * Mathf.Pow(Time.deltaTime, 2) / 2);
        }
        else
        {
            direccion = new Vector3((_velocidadInicial * Time.deltaTime + _aceleracion * Mathf.Pow(Time.deltaTime, 2) / 2), 0);
        }

    }

    // Update is called once per frame
    void Update ()
    {
        gameObject.transform.Translate(direccion);
        _velocidadInicial += _aceleracion * Time.deltaTime;
    }

    public void Shoot(float velocidadInicialY,float aceleracionY)
    {
        _velocidadInicial = velocidadInicialY;
        _aceleracion = aceleracionY;
    }
}
