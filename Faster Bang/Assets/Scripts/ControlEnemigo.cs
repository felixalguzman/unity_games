using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour {

    Vector3 nuevaPosicion;
    bool seguirCaminando = false, disparo = false, salio = false;
    Animator animator;
    public GameObject flechaEnemigo;
    float fuerzaFlecha = 900f;
    AudioSource audioFlecha;
    GameObject enemigo;
    public GameObject flecha;
    public AudioSource audioGrito;
    float tiempoDisparo;
    bool posicionFija = false;
 


    // Use this for initialization

    void Awake()
    {
        flecha = GameObject.Find("Flecha");
        enemigo = GameObject.FindGameObjectWithTag("Armas");
        flechaEnemigo = GameObject.Find("FlechaEnemigo");
        //flechaEnemigo = Instantiate(flecha, new Vector3(24f, 0.19f), Quaternion.identity);
        if (flechaEnemigo.activeInHierarchy)
        {
            flechaEnemigo.transform.parent = enemigo.transform;
            flechaEnemigo.SetActive(false);
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        audioFlecha = flechaEnemigo.GetComponent<AudioSource>();
        audioGrito = GameObject.Find("GritoEnemigo").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        nuevaPosicion = Vector3.zero;

        seguirCaminando = gameObject.transform.position.x <= 16.66 ? true : false;

        if (!seguirCaminando)
        {
            nuevaPosicion.x = -1;
            gameObject.transform.Translate(nuevaPosicion * Time.deltaTime);
        }

        if (seguirCaminando)
        {
            animator.SetBool("seguirCaminando", true);

        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ArqueroSangrientoMuriendo") && !posicionFija)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -0.03f);
            posicionFija = true;
        }

        if (ControlJuego.tiempoInicioJuego != 0 && !disparo)
        {
            tiempoDisparo = Random.Range(0.1f, 1f);
            //Debug.Log("Disparo flecha " + tiempoDisparo);
            Invoke("EnviarTiempoEnemigo", tiempoDisparo);

            disparo = true;
            //x = -0.651 y = 0.19
        }
    }

    void EnviarTiempoEnemigo()
    {
        ControlJuego.tiempoInicioEnemigo = tiempoDisparo;
    }

    void FixedUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ArqueroSangrientoCaminandoParado"))
        {
            animator.Play("ArqueroSangrientoCargando");

        }

        if (!salio &&  ControlJuego.acabo)
        {
            if (!ControlJuego.ganoPartida)
            {
                DispararFlecha(tiempoDisparo);
            }
            
            // x = 6.04 y = -0.02
            salio = true;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Flecha")
        {
            other.gameObject.SetActive(false);
            animator.Play("ArqueroSangrientoMuriendo");
            audioGrito.Play();
            //Destroy(other.gameObject);
        }
    }

    void DispararFlecha(float tiempo)
    {
        //yield return new WaitForSeconds(tiempo);
        flecha.SetActive(false);
        flechaEnemigo.SetActive(true);
        flechaEnemigo.GetComponent<Rigidbody>().AddForce(new Vector3(fuerzaFlecha * -1, 0) * Time.deltaTime, ForceMode.Impulse);
    }

    public void InicializarElementos()
    {
        tiempoDisparo = 0f;
        salio = false;
        disparo = false;
        animator.Play("ArqueroSangrientoCargando");
        //flecha.transform.position = new Vector3(16.02f, 0.19f);
        //flecha.SetActive(false);

    }



}
