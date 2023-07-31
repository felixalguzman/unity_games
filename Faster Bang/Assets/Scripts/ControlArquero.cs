using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArquero : MonoBehaviour {

    Vector3 nuevaPosicion;
    Transform posicionActual;
    bool seguirCaminando = false;
    Animator animator;
    float fuerzaFlecha = 900f;
    public GameObject flecha;
    AudioSource audioFlecha;
    GameObject flechaEnemigo;
  
    public AudioSource sonidoGrito;
    bool flechaLanzada = false;
    bool posicionFija = false;

    // Use this for initialization

    void Awake()
    {
        flechaEnemigo = GameObject.Find("FlechaEnemigo");
        flecha = GameObject.Find("Flecha");
        if (GameObject.FindGameObjectWithTag("Arquero").activeInHierarchy)
        {
            flecha.transform.parent = GameObject.FindGameObjectWithTag("Armas").transform;
            flecha.SetActive(false);
        }
    }
    void Start () {
        animator = GetComponent<Animator>();
        audioFlecha = flecha.GetComponent<AudioSource>();
        sonidoGrito = GameObject.Find("GritoArquero").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        
        nuevaPosicion = Vector3.zero;
        
        seguirCaminando = gameObject.transform.position.x >= 9.47 ? true : false;

        if (!seguirCaminando)
        {
            nuevaPosicion.x = 1;
            gameObject.transform.Translate(nuevaPosicion * Time.deltaTime);
        }

        if (seguirCaminando)
        {
            animator.SetBool("seguirCaminando", true);
            
        }


        if (Input.GetKey(KeyCode.Space) && !flecha.activeInHierarchy && ControlMensajes.juegoListo)
        {
            float tiempo = Time.time - ControlJuego.tiempoInicioJuego;
            //Debug.Log("Tiempo jugador" + tiempo);
            ControlJuego.tiempoInicioJugador = Time.time;
            
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ArqueroMuriendo") && !posicionFija)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,-0.08f);
            posicionFija = true;
        }
    }

    void FixedUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ArqueroParado"))
        {
            animator.Play("ArqueroDisparando");

        }

        if (!flechaLanzada && !flecha.activeInHierarchy)
        {
            
            if (ControlJuego.acabo)
            {
                if (ControlJuego.ganoPartida)
                {
                    flechaEnemigo.SetActive(false);
                    flecha.SetActive(true);
                    flecha.GetComponent<Rigidbody>().AddForce(new Vector3(fuerzaFlecha, 0) * Time.deltaTime, ForceMode.Impulse);
                    audioFlecha.Play();
                    flechaLanzada = true;
                }
            }
            
        }
    }

 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FlechaEnemigo")
        {
            other.gameObject.SetActive(false);
            animator.Play("ArqueroMuriendo");
            sonidoGrito.Play();
        } 
    }

    public void InicializarElementos()
    {
        flechaLanzada = false;
        posicionFija = false;
        animator.Play("ArqueroDisparando");
        //flecha.transform.position = new Vector3(10f, 0.527f, 0);
        //flecha.SetActive(false);

    }
}


