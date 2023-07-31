using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMensajes : MonoBehaviour {

    public TextMesh textoReady;
    public TextMesh textoSet;
    public TextMesh textoGo;
    AudioSource audioConteo;
    float tiempo = 1.0f, tiempoMensaje1 = 10f, tiempoMensaje2 = 1.0f;
    public static bool juegoListo = false, listo = false;

    // Use this for initialization

    void Awake()
    {
        
        
        audioConteo = GetComponent<AudioSource>();

    }
    void Start () {
        Inicio(tiempoMensaje1);
        
    }
	
	// Update is called once per frame
	void Update () {
   
        if (textoReady.gameObject.activeInHierarchy || textoSet.gameObject.activeInHierarchy || textoGo.gameObject.activeInHierarchy)
        {
            if (!audioConteo.isPlaying )
            {
                audioConteo.Play();
                               
            }
        }

        if (juegoListo && !listo)
        {
            listo = true;
        }
     
    }
    

 

    IEnumerator MostrarTexto(float tiempoEspera)
    {
        
        yield return new WaitForSeconds(tiempoEspera);
        textoReady.gameObject.SetActive(true);
        yield return new WaitForSeconds(tiempo);
        textoReady.gameObject.SetActive(false);

        yield return new WaitForSeconds(tiempoMensaje2);
        textoSet.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        textoSet.gameObject.SetActive(false);

        float _mensajeGo = Random.Range(0f, 3f);
        //Debug.Log(_mensajeGo);
        yield return new WaitForSeconds(_mensajeGo);
        textoGo.gameObject.SetActive(true);
        ControlJuego.tiempoInicioJuego = Time.time;
        juegoListo = true;
        yield return new WaitForSeconds(1f);
        textoGo.gameObject.SetActive(false);
       


    }
    public void Inicio(float tiempoInicio)
    {
        StartCoroutine(MostrarTexto(tiempoInicio));

    }

    public void InicializarElementos()
    {
        juegoListo = false;
        listo = false;
        Inicio(2.5f);

    }

}
