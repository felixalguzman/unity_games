using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugadores : MonoBehaviour {

    bool esJugador1;
    float velocidadDesplazamiento = 10f;
    Vector3 desplazamiento;
    const float LIMS = 2.6f, LIMI = -2.6f;
	// Use this for initialization
	void Start () {

        esJugador1 = gameObject.name == "Jugador1";
		
	}
	
	// Update is called once per frame
	void Update () {
        // Las entradas las manejaremos por ahora con el teclado.
        // Lo ideal es que sea con los touches.
        desplazamiento = new Vector3();
        if (esJugador1 && Input.GetKey(KeyCode.A))
        {
            desplazamiento.y += velocidadDesplazamiento * Time.deltaTime;
        }

        if (esJugador1 && Input.GetKey(KeyCode.Z))
        {
            desplazamiento.y += -velocidadDesplazamiento * Time.deltaTime;
        }

        if (!esJugador1 && Input.GetKey(KeyCode.UpArrow))
        {
            desplazamiento.y += velocidadDesplazamiento * Time.deltaTime;
        }

        if (!esJugador1 && Input.GetKey(KeyCode.DownArrow))
        {
            desplazamiento.y += -velocidadDesplazamiento * Time.deltaTime;
        }

        gameObject.transform.Translate(desplazamiento);

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.Clamp(gameObject.transform.position.y, LIMI, LIMS));
    }
}
