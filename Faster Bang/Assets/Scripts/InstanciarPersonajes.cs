using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarPersonajes : MonoBehaviour {

    public GameObject enemigo;
    public GameObject jugador;

    void Awake()
    {
        Destroy(GameObject.Find("MUSIC"));
    }
    // Use this for initialization
    void Start () {
        Instantiate(jugador, new Vector3(-1.15f, 0.36f), Quaternion.identity);
        Instantiate(enemigo, new Vector3(24.06f, 0.33f), Quaternion.identity);  


    }

    // Update is called once per frame
    void Update () {
		
	}
}
