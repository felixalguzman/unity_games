using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAlien : MonoBehaviour {
    int vidas;
    int puntos;
    public GameObject[] balasPrefab;
    GameObject balaActual;
    GameObject nuevaBala;
    Vector3 velocidadDisparo;
    float tiempoRetraso;
    float timer;
    float contadorRespawnEscudo;

    AlmacenamientoPersistente almacenamientoPersistente;
    string dificultad = "";
    int nivel;

    void Start ()
    {
        almacenamientoPersistente = GameObject.Find("Almacenamiento").GetComponent<AlmacenamientoPersistente>();
        dificultad = almacenamientoPersistente.ObtenerModoJuego();
        nivel = almacenamientoPersistente.ObtenerNivel();
        contadorRespawnEscudo = 0;
        InicializarAlieligenas();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= tiempoRetraso)
        {
            Disparar();
            timer = 0f;
        }
		
	}


    void InicializarAlieligenas()
    {
        if (almacenamientoPersistente.ObtenerModoJuego() == "muyfacil")
        {
            velocidadDisparo = new Vector3(Random.Range(3f, 15f) * -1, Random.Range(0.1f, 0.5f) * -1);
            switch (gameObject.tag)
            {
                case "Alien1":
                    vidas = Random.Range(1, 3);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(5, 20);
                    puntos = Random.Range(10, 20);
                    break;
                case "Alien2":
                    vidas = Random.Range(2, 4);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(5, 18);
                    puntos = Random.Range(10, 30);
                    break;
                case "Alien3":
                    vidas = Random.Range(1, 5);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(5, 16);
                    puntos = Random.Range(10, 20);
                    break;
                case "Alien4":
                    vidas = Random.Range(3, 4);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(5, 30);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien5":
                    vidas = Random.Range(4, 5);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(5, 40);
                    puntos = Random.Range(10, 25);
                    break;
                case "Alien6":
                    vidas = Random.Range(2, 5);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(5, 60);
                    puntos = Random.Range(15, 25);
                    break;
                case "Alien7":
                    vidas = Random.Range(1, 5);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(5, 80);
                    puntos = Random.Range(10, 15);
                    break;
                case "Alien8":
                    vidas = Random.Range(2, 5);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(5, 90);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien9":
                    vidas = Random.Range(2, 5);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(5, 100);
                    puntos = Random.Range(15, 25);
                    break;
            }
        }
        else if (almacenamientoPersistente.ObtenerModoJuego() == "facil")
        {
            velocidadDisparo = new Vector3(Random.Range(3f, 15f) * -1, Random.Range(0.1f, 0.5f) * -1);
            switch (gameObject.tag)
            {
                case "Alien1":
                    vidas = Random.Range(2, 3);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 20);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien2":
                    vidas = Random.Range(2, 6);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 18);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien3":
                    vidas = Random.Range(2, 6);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 17);
                    puntos = Random.Range(20, 20);
                    break;
                case "Alien4":
                    vidas = Random.Range(2, 4);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 16);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien5":
                    vidas = Random.Range(4, 6);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 17);
                    puntos = Random.Range(20, 25);
                    break;
                case "Alien6":
                    vidas = Random.Range(2, 6);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 19);
                    puntos = Random.Range(20, 25);
                    break;
                case "Alien7":
                    vidas = Random.Range(2, 5);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 18);
                    puntos = Random.Range(20, 15);
                    break;
                case "Alien8":
                    vidas = Random.Range(2, 6);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 19);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien9":
                    vidas = Random.Range(4, 6);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 26);
                    puntos = Random.Range(20, 25);
                    break;
            }



        }
        else if (almacenamientoPersistente.ObtenerModoJuego() == "normal")
        {
            velocidadDisparo = new Vector3(Random.Range(5f, 20f) * -1, Random.Range(0.1f, 0.7f) * -1);
            switch (gameObject.tag)
            {
                case "Alien1":
                    vidas = Random.Range(3, 5);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 10);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien2":
                    vidas = Random.Range(3, 7);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 9);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien3":
                    vidas = Random.Range(3, 8);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 7);
                    puntos = Random.Range(20, 20);
                    break;
                case "Alien4":
                    vidas = Random.Range(3, 4);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 10);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien5":
                    vidas = Random.Range(5, 8);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 7);
                    puntos = Random.Range(20, 25);
                    break;
                case "Alien6":
                    vidas = Random.Range(3, 6);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 9);
                    puntos = Random.Range(20, 25);
                    break;
                case "Alien7":
                    vidas = Random.Range(3, 8);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 8);
                    puntos = Random.Range(20, 15);
                    break;
                case "Alien8":
                    vidas = Random.Range(3, 6);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 9);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien9":
                    vidas = Random.Range(4, 8);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 10);
                    puntos = Random.Range(20, 25);
                    break;
            }
        }
        else if (almacenamientoPersistente.ObtenerModoJuego() == "dificil")
        {
            
            velocidadDisparo = new Vector3(Random.Range(10f, 20f) * -1, Random.Range(0.4f, 0.7f) * -1);
            switch (gameObject.tag)
            {
                case "Alien1":
                    vidas = Random.Range(5, 7);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(3, 5);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien2":
                    vidas = Random.Range(5, 10);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(3, 6);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien3":
                    vidas = Random.Range(5, 8);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(3, 6);
                    puntos = Random.Range(20, 20);
                    break;
                case "Alien4":
                    vidas = Random.Range(5, 7);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(3, 7);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien5":
                    vidas = Random.Range(5, 10);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(3, 7);
                    puntos = Random.Range(20, 25);
                    break;
                case "Alien6":
                    vidas = Random.Range(5, 9);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(3, 9);
                    puntos = Random.Range(20, 25);
                    break;
                case "Alien7":
                    vidas = Random.Range(5, 8);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(3, 8);
                    puntos = Random.Range(20, 15);
                    break;
                case "Alien8":
                    vidas = Random.Range(5, 10);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(3, 5);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien9":
                    vidas = Random.Range(5, 8);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(3, 10);
                    puntos = Random.Range(20, 25);
                    break;
            }
        }
        else
        {
            velocidadDisparo = new Vector3(Random.Range(5f, 20f) * -1, Random.Range(0.1f, 0.7f) * -1);
            switch (gameObject.tag)
            {
                case "Alien1":
                    vidas = Random.Range(3, 5);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 7);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien2":
                    vidas = Random.Range(3, 7);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 8);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien3":
                    vidas = Random.Range(3, 8);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 6);
                    puntos = Random.Range(20, 20);
                    break;
                case "Alien4":
                    vidas = Random.Range(3, 4);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 10);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien5":
                    vidas = Random.Range(5, 8);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 7);
                    puntos = Random.Range(20, 25);
                    break;
                case "Alien6":
                    vidas = Random.Range(3, 6);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 9);
                    puntos = Random.Range(20, 25);
                    break;
                case "Alien7":
                    vidas = Random.Range(3, 8);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 8);
                    puntos = Random.Range(20, 15);
                    break;
                case "Alien8":
                    vidas = Random.Range(3, 6);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 9);
                    puntos = Random.Range(20, 30);
                    break;
                case "Alien9":
                    vidas = Random.Range(4, 8);
                    balaActual = balasPrefab[Random.Range(0, 2)];
                    tiempoRetraso = Random.Range(4, 10);
                    puntos = Random.Range(20, 25);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bala")
        {
            if (vidas > 0)
                vidas--;

            else
            {
                ControlJuego.cantidadAliens--;
                contadorRespawnEscudo++;
                ArrojarEscudo();
                FindObjectOfType<ControlJuego>().AumentarPuntuacion(puntos);
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }


    void Disparar()
    {
        nuevaBala = Instantiate(balaActual, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1), Quaternion.identity);
        nuevaBala.GetComponent<MRUV>().Disparar(velocidadDisparo.x, velocidadDisparo.y);

    }

    void ArrojarEscudo()
    {   //en vez de 2, 40
        if (contadorRespawnEscudo >= Mathf.RoundToInt(2/(almacenamientoPersistente.ObtenerNivelItem3() + 1)))
        {
            GameObject.FindObjectOfType<ControlJuego>().GenerarPowerUp(gameObject.transform.position);
        }
        contadorRespawnEscudo = 0;
    }

}
