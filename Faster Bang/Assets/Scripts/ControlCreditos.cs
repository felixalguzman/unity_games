using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlCreditos : MonoBehaviour {

    
   
    void Awake()
    {
       
    }
    // Use this for initialization
    void Start () {
        
        Invoke("CambiarEscena", 22f);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {

            CambiarEscena();
        }
		
	}

    void CambiarEscena()
    {

        SceneManager.LoadScene("Menu");
    }

   
}
