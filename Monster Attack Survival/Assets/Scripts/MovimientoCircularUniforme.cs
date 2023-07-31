using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCircularUniforme : MonoBehaviour
{
    public bool Activo;
    private Transform centro;
    private float radio;
    private float tiempoInicio;
    private Vector3 aceleracionFinal;
    private Vector3 velocidadFinal;
    private Vector3 velocidadInicial;
    private Vector3 anguloFinal;

    public GameObject escudo;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (!Activo)
        {
            return;
        }
        velocidadFinal = velocidadInicial + aceleracionFinal * (Time.time - tiempoInicio);

        anguloFinal = velocidadFinal * (Time.time - tiempoInicio) / radio;

        Debug.Log(gameObject.name);

       
        gameObject.transform.position = new Vector3(centro.position.x + radio * Mathf.Cos(anguloFinal.x), centro.position.y + radio * Mathf.Sin(anguloFinal.y));

        
    }

    public void ActivarMovimientoCircular(Transform centro, Vector3 aceleracion, Vector3 velocidadInicial, float radio = 1f)
    {
        if (Activo)
        {
            return;
        }
        Activo = true;
        this.centro = centro;
        this.radio = radio;
        tiempoInicio = Time.time;
        aceleracionFinal = aceleracion;
        this.velocidadInicial = velocidadInicial;
    }
}
