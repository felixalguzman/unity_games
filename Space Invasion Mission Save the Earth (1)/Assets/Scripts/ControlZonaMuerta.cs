using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlZonaMuerta : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Bala" || other.gameObject.tag == "BalaEnemigo")
		{
			Destroy(other.gameObject);
		}
	}
}
