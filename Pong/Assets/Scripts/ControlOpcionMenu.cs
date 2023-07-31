using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlOpcionMenu : MonoBehaviour {

    GameObject dialogoCambiarNomre;
    // Use this for initialization

    void Awake()
    {
        dialogoCambiarNomre = GameObject.Find("DialogoCambiarNombre");
        
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        gameObject.transform.localScale *= 1.2f; 
    }

    void OnMouseUp()
    {
        gameObject.transform.localScale /= 1.2f;

        if (!dialogoCambiarNomre.activeInHierarchy)
        {
            switch (gameObject.name)
            {
                case "Salir":
                    Application.Quit();
                    break;
                case "Jugar":
                    SceneManager.LoadScene("EscenaJuego");
                    break;
                case "CambiarNombre":
                    GameObject.Find("ScriptGlobalesMenu").SendMessage("MostrarDialogoCambiarNombre");
                    break;
            }
        }
        
    }

    public void AceptarCambiarNombre()
    {
        ControlJuego.NombreJugador =((GameObject.Find("NombreJugador").GetComponent<InputField>()).text);
        CancelarCambiarNombre();
    }

    public void CancelarCambiarNombre()
    {
        GameObject.Find("ScriptGlobalesMenu").SendMessage("OcultarDialogoCambiarNombre");

    }
}
