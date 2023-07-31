using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBala : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (gameObject.tag == "Escudo")
		{
			if (!gameObject.GetComponent<ControlEscudo>().Activo)
			{
				return;
			}
		}
	}
}
