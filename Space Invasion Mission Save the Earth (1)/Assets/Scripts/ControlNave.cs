using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ServiceModel;
using UnityEngine.SceneManagement;
public class ControlNave : MonoBehaviour
{

    public GameObject[] vidas;
    public AudioSource laser;
    int cantidadVidas = 3;
    public GameObject bala1;
    private GameObject _nuevoProyectil;
    Vector3 posicion;
    bool golpeado;
    float TIEMPORETRASO1 = 0.7f;
    private float _tiempoUltimoDisparoProyectil1 = 0, _tiempoUltimoDisparoProyectil2 = 0;
    float VelocidadTraslacion = 5f, LIMO = -7.36f, LIME = 7.39f, posicionY = -4f;
    AlmacenamientoPersistente almacenamientoPersistente;

    public static int puntos;
    public static int dinero;
    // Use this for initialization
    void Start()
    {
        almacenamientoPersistente = GameObject.Find("Almacenamiento").GetComponent<AlmacenamientoPersistente>();
        puntos = 0;
        dinero = 0;
        golpeado = false;
        switch (almacenamientoPersistente.ObtenerNivelItem1())
        {
            case 2:
                TIEMPORETRASO1 = 0.6f;
                break;

            case 3:
                TIEMPORETRASO1 = 0.5f;
                break;

            case 4:
                TIEMPORETRASO1 = 0.4f;
                break;

            case 5:
                TIEMPORETRASO1 = 0.3f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.acceleration != Vector3.zero)
        {
            gameObject.transform.Translate(new Vector3(VelocidadTraslacion * Input.acceleration.x, VelocidadTraslacion * Input.acceleration.y) * Time.deltaTime);

        }

        if (Input.GetAxis("Horizontal") != 0)
        {

            gameObject.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * VelocidadTraslacion);

        }

        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, LIMO, LIME), Mathf.Clamp(gameObject.transform.position.y, posicionY, posicionY));

        if (Time.time - _tiempoUltimoDisparoProyectil1 > TIEMPORETRASO1)
        {
            laser.Play();
            posicion = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1);
            _nuevoProyectil = Instantiate(bala1, posicion, Quaternion.identity);

            _nuevoProyectil.GetComponent<MRUV>().Disparar(10f, 0.5f);
            _tiempoUltimoDisparoProyectil1 = Time.time;
        }

        if (golpeado)
        {
            DisminuirVida();
            golpeado = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BalaEnemigo")
        {
            if (cantidadVidas > 0)
            {
                golpeado = true;
            }

        }

       
    }

    public void DisminuirVida()
    {
        cantidadVidas--;
        vidas[cantidadVidas].SetActive(false);

        if (cantidadVidas == 0)
        {
            GuardarWCF();
            FindObjectOfType<ControlJuego>().Guardar();
            Destroy(gameObject);
          

        }




    }

    public void GuardarWCF()
    {

        int puntos = FindObjectOfType<ControlJuego>().ObtenerPuntuacion();
        almacenamientoPersistente.RegistrarDinero(almacenamientoPersistente.ObtenerDinero() + puntos * 3);
        almacenamientoPersistente.RegistrarPuntuacion(almacenamientoPersistente.ObtnerPuntuacion() + puntos);

        try
        {
            ServicioSpaceClient servicioSpace = new ServicioSpaceClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:53098/ServicioSpace.svc?wsdl"));
            servicioSpace.RegistrarNuevoRecord(puntos * 3, puntos);
        }
        catch (System.Exception)
        {


        }
    }




}
