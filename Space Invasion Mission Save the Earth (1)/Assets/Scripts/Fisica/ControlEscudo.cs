using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEscudo : MonoBehaviour {

    private AudioSource sonido;
	public bool Activo;
    public Transform Centro;
    private float _radio;
    private float _tiempoInicio;
    private Vector3 _velocidadFinal;
    private Vector3 _aceleracion;
    private Vector3 _anguloFinal;
    private Vector3 _velocidadInicial;
    AlmacenamientoPersistente almacenamientoPersistente;

    float duracion = 5f;
	// Use this for initialization
	void Start () {
		
        almacenamientoPersistente = GameObject.Find("Almacenamiento").GetComponent<AlmacenamientoPersistente>();
        sonido = GameObject.Find("Escudo").GetComponent<AudioSource>();
        duracion += almacenamientoPersistente.ObtenerDineroItem3();
        Destroy(gameObject,duracion);
	}
	
	// Update is called once per frame
	void Update () {
        
		 if (!Activo)
        {
            return;
        }
        _velocidadFinal =  _velocidadInicial + _aceleracion * (Time.time - _tiempoInicio); // la velocidad inicial es cero (inicia detenido)

        _anguloFinal = _velocidadFinal * (Time.time - _tiempoInicio) / _radio;

        gameObject.transform.position = new Vector3(Centro.position.x + _radio * Mathf.Cos(_anguloFinal.x), Centro.position.y + _radio * Mathf.Sin(_anguloFinal.y));
  
	}

	public void ActivarEscudo(Transform centro, Vector3 aceleracion, Vector3 velocidadInicial , float radio = 2f)
    {
        if (Activo)
        {
            return;
        }
        sonido.Play();
        Activo = true;
        Centro = centro;
        _radio = radio;
        _tiempoInicio = Time.time;
        _aceleracion = aceleracion;
        _velocidadInicial = velocidadInicial;
    }
}
