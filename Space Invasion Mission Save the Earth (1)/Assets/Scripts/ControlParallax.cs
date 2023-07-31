using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlParallax : MonoBehaviour {

	MeshRenderer renderizador;

	private float _velocidadMaxima = 0.0002f, _distanciaMaxima = 20f, _velocidadActual;
	// Use this for initialization
	void Start () {
		
		renderizador = gameObject.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		_velocidadActual = 1 - (gameObject.transform.position.z / _distanciaMaxima) * _velocidadMaxima;
		renderizador.material.mainTextureOffset += new Vector2(_velocidadActual, 0);
		
	}
}
