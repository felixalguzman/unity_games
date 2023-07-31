using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRUV : MonoBehaviour {

	float _velocidadInicialY = 0, _aceleracionY = 0;
	bool _disparado = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		gameObject.transform.Translate(new Vector3(0, _velocidadInicialY*Time.deltaTime + _aceleracionY*Mathf.Pow(Time.deltaTime,2) / 2));
		_velocidadInicialY += _aceleracionY * Time.deltaTime;		


	}

	public void Disparar(float velocidadInicialY, float aceleracionY)
	{
		_aceleracionY = aceleracionY;
		_velocidadInicialY = velocidadInicialY;
		_disparado = true;
	}
}
