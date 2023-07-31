using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarPelota : MonoBehaviour {

    public GameObject nuevaPelota;
	// Use this for initialization
	void Start () {

        Instantiate(nuevaPelota, new Vector3(0, 0), Quaternion.identity);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Instanciar()
    {
        Instantiate(nuevaPelota, new Vector3(0, 0), Quaternion.identity);

    }
}
