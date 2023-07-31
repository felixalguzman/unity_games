using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJuego : MonoBehaviour
{
    public GameObject EscudoPrefab;
    private GameObject objetoNuevo;
    public TextMesh puntuacionText;
    int puntuacionNivel;
    bool entro;
    public static int cantidadAliens = 0;
    AlmacenamientoPersistente almacenamientoPersistente;
    // Use this for initialization
    void Start()
    {

        almacenamientoPersistente = GameObject.Find("Almacenamiento").GetComponent<AlmacenamientoPersistente>();
        puntuacionNivel = 0;

        puntuacionText.text = "Puntuacion: " + puntuacionNivel;
        cantidadAliens += GameObject.FindGameObjectsWithTag("Alien1").Length;
        cantidadAliens += GameObject.FindGameObjectsWithTag("Alien2").Length;
        cantidadAliens += GameObject.FindGameObjectsWithTag("Alien3").Length;
        cantidadAliens += GameObject.FindGameObjectsWithTag("Alien4").Length;
        cantidadAliens += GameObject.FindGameObjectsWithTag("Alien5").Length;
        cantidadAliens += GameObject.FindGameObjectsWithTag("Alien6").Length;
        cantidadAliens += GameObject.FindGameObjectsWithTag("Alien7").Length;
        cantidadAliens += GameObject.FindGameObjectsWithTag("Alien8").Length;
        cantidadAliens += GameObject.FindGameObjectsWithTag("Alien9").Length;


    }

void Update()
{
    if (cantidadAliens == 0)
    {
        Guardar();
    }
}
    public void Guardar()
    {
        
            switch (almacenamientoPersistente.ObtenerNivel())
            {
                case 1:
                    almacenamientoPersistente.RegistrarNivel(2);
                    SceneManager.LoadScene("EscenaMedia");
                    break;

                case 2:
                    almacenamientoPersistente.RegistrarNivel(3);
                    break;

                case 3:
                    almacenamientoPersistente.RegistrarNivel(4);
                    break;

                case 4:
                    almacenamientoPersistente.RegistrarNivel(4);
                    break;
            }


         SceneManager.LoadScene("Tienda");
    }



    public void GenerarPowerUp(Vector3 posicion)
    {
        objetoNuevo = Instantiate(EscudoPrefab, new Vector3(posicion.x, posicion.y), Quaternion.identity);
        objetoNuevo.GetComponent<PowerUp>().InicializarPowerUp(TipoPowerUp.Escudo, GameObject.FindGameObjectWithTag("Player"));
    }


    public void AumentarPuntuacion(int puntuacion)
    {
        puntuacionNivel += puntuacion;
        puntuacionText.text = "Puntuacion " + puntuacionNivel;
    }

    public int ObtenerPuntuacion()
    {
        return puntuacionNivel;
    }
}
