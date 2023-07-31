using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlFinJuego : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Invoke("ReiniciarMenu", 3f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReiniciarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
