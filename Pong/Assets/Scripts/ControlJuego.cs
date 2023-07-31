using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJuego : MonoBehaviour
{
    public static string NombreJugador = "Jose Manuel";
    bool jugando = false;
    GameObject pelota;
    const float fuerzaInicial = 200f;
    // Use this for initialization
    void Start()
    {
        GameObject.Find("NombreJugadorText").GetComponent<TextMesh>().text = NombreJugador;
    }

    // Update is called once per frame
    void Update()
    {
        pelota = GameObject.FindGameObjectWithTag("Pelota");
        if (!jugando && Input.GetAxis("Jump") > 0)
        {
            jugando = true;
            // Aplicar fuerza a la pelota.
            pelota.GetComponent<Rigidbody>().AddForce(new Vector3((Random.Range(0, 2) == 0 ? 1 : -1) * fuerzaInicial, (Random.Range(0, 2) == 0 ? 1 : -1) * fuerzaInicial));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("EscenaMenu");
        }

    }
}
