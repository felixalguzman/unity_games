using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMoneda : MonoBehaviour {

    private AudioSource recogerSonido;
	// Use this for initialization
	void Start () {

        recogerSonido = GameObject.Find("RecojerMoneda").GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
            Destroy(gameObject);
            GameObject.Find("ControlJuego").GetComponent<ControlMensajes>().AumentarMonedas();
            recogerSonido.Play();
        }

        if (other.gameObject.tag == "Suelo")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
            gameObject.GetComponent<CaidaLibre>().velocidadInicialY = 0f;
            gameObject.GetComponent<CaidaLibre>().aceleracionY = 0f;

        }

    }
}
