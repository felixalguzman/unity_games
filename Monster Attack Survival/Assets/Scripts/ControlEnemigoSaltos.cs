using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigoSaltos : MonoBehaviour
{

    private float LIMI = -11.48f, LIMD = 11.39f, LIMN = 3.42f, LIMS = -1.12f;
    private float velocidadSalto = 10f;
    private float Vidas = 1;
    private float  tiempo = 6f, tiempoRetraso = 4f;
    private int cantidadMonedas;
    private bool saltando = false;
    private Vector3 direccionMovimiento = Vector3.zero;
    CharacterController controller;

    Vector3 posicion;
    Animator animator;
    private float fuerzaSalto = 10.5f;
    void Awake()
    {
        switch (gameObject.tag)
        {

            case "Poke Feo":
                Vidas = 5;
                velocidadSalto = 10f;
                cantidadMonedas = 3;
            break;

            case "Sapo":
                Vidas = 2;
                fuerzaSalto =5f;
                tiempoRetraso = 2f;
                cantidadMonedas = 1;
                break;

             case "Rana":
                Vidas = 2;
               fuerzaSalto =2f;
                tiempoRetraso = 3f;
                cantidadMonedas = 3;
                break;
        }
    }
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        posicion = gameObject.transform.position;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= tiempo  && !saltando)
        {
            saltando = true;


            tiempo = Time.time + tiempoRetraso;
        }




        if (posicion.y >= -1.13 && posicion.y <= LIMS)
        {
            animator.Play("Idle");

        }
        else
        {
            animator.Play("Saltando");
        }
    }

    private void FixedUpdate()
    {
        if (saltando && gameObject.transform.position.y <= -0.86)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltando = false;
        }
    }




}
