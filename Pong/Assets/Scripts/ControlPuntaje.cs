using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuntaje : MonoBehaviour {

    int puntuacionJugador1 = 0, puntuacionJugador2 = 0;
    public TextMesh Textopuntaje1;
    public TextMesh Textopuntaje2;
   
    // Use this for initialization
    void Start () {
        Textopuntaje1.text = "Puntos: " + puntuacionJugador1;
        Textopuntaje2.text = "Puntos: " + puntuacionJugador2;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pelota")
        {
            
            Destroy(other.gameObject);

            if (gameObject.name == "ZonaMuerta2")
            {
                //Aumentar score al jugador 1
                puntuacionJugador1++;
                Textopuntaje1.text = "Puntos: " + puntuacionJugador1;

            }
            else
            {
                //Aumentar score al jugador 2
                puntuacionJugador2++;
                Textopuntaje2.text = "Puntos: " + puntuacionJugador2;
            }

            
            
        }
    }

   
}
