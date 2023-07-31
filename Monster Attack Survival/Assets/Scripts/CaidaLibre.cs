using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaLibre : MonoBehaviour {
    public float aceleracionY = -9.8f;
    public float velocidadInicialY = 0f;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(new Vector3(0, velocidadInicialY * Time.deltaTime + aceleracionY *Mathf.Pow(Time.deltaTime, 2) / 2));

        velocidadInicialY += aceleracionY * Time.deltaTime;
    }

    public void RealizarCaidaLibre(float velocidadInicialY, float aceleracionY)
    {
        this.velocidadInicialY = velocidadInicialY;
        this.aceleracionY = aceleracionY;
    }
}
