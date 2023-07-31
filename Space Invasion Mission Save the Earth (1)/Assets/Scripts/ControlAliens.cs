using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlAliens : MonoBehaviour
{
    const float LIMN = 1.74f, LIMS = 0.34f, LIME = 4.8f, LIMO = -8.7f;
    Direccion direccion;
    float velocidadMovimiento;
    float TIEMPOMOVIMENTO = 0.5f;
    Vector3 desplazamiento;
    float timer = 0.0f;
    bool subiendo;
    public enum Direccion
    {
        ESTE = 0,
        OESTE,
        NORTE,
        SUR

    }
    // Use this for initialization
    void Start()
    {
        direccion = Direccion.ESTE;
        timer = 0.0f;
        velocidadMovimiento = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= TIEMPOMOVIMENTO)
        {
            MovimientoEnemigo();
            timer = 0f;
        }

    }
    void MovimientoEnemigo()
    {
        Transform posicionActual = gameObject.transform;
        float valorMovimientoY = -5f;

        if (direccion == Direccion.ESTE && !subiendo)
        {
            desplazamiento.x = 5f;
            desplazamiento.y = 0f;
            if (posicionActual.position.x >= LIME && direccion != Direccion.OESTE)
            {
                desplazamiento.y = valorMovimientoY;
                desplazamiento.x = 0f;
                direccion = Direccion.OESTE;
            }

        }
        else if (direccion == Direccion.OESTE && !subiendo)
        {
            desplazamiento.x = -5f;
            desplazamiento.y = 0f;
            if (posicionActual.position.x <= LIMO && direccion != Direccion.ESTE)
            {
                desplazamiento.y = valorMovimientoY;
                desplazamiento.x = 0f;
                direccion = Direccion.ESTE;
            }
        }

        if (posicionActual.position.y <= LIMS)
        {
            desplazamiento.y = 5f;
            subiendo = true;
        }

        if (subiendo)
        {
            desplazamiento.y = 5f;
            if (posicionActual.position.y >= LIMN)
            {
                desplazamiento.y = -5f;
                subiendo = false;
            }
        }

        gameObject.transform.Translate(desplazamiento * Time.deltaTime * velocidadMovimiento);

    }
}

