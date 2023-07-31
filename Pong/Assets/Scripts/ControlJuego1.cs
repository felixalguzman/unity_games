using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego1 : MonoBehaviour {

    GameObject dialogoCambiarNomre;
    // Use this for initialization

    void Awake()
    {
        dialogoCambiarNomre = GameObject.Find("DialogoCambiarNombre");
    }
    void Start () {

        OcultarDialogoCambiarNombre();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void MostrarDialogoCambiarNombre()
    {
        dialogoCambiarNomre.SetActive(true);
    }

    void OcultarDialogoCambiarNombre()
    {
        dialogoCambiarNomre.SetActive(false);
    }
}
