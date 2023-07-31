using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ControlMenu : MonoBehaviour, ISelectHandler
{

    public AudioSource sobreOpcionSonido;
    AudioSource sonidoPrincipal;
    public GameObject musicaMenu;

    public AudioMixer audioMixer;

    public Slider slider;
    public Button tirador;
    public Button caballero;
    public static int tiradorSeleccionado =0, caballeroSeleccionado =0;

    private AlmacenamientoPersistente almacenamientoPersistente;

    void Awake()
    {


        musicaMenu = GameObject.Find("MUSIC");
        almacenamientoPersistente = GetComponent<AlmacenamientoPersistente>();
        float volumenViejo = almacenamientoPersistente.ObtenerVolumen();

        if (musicaMenu == null)
        {
            sonidoPrincipal = GameObject.Find("MusicaPrincipal").GetComponent<AudioSource>();
            sonidoPrincipal.name = "MUSIC";
            sonidoPrincipal.Play();
            DontDestroyOnLoad(sonidoPrincipal);
            audioMixer.SetFloat("volumen", volumenViejo);
        }
        else
        {
            if (musicaMenu.name != "MUSIC")
            {
                Destroy(musicaMenu);
            }


            audioMixer.SetFloat("volumen", volumenViejo);
        }



    }

    public void OnSelect(BaseEventData eventData)
    {


        ColorBlock cb = caballero.colors;
        cb.normalColor = Color.gray;
        caballero.colors = cb;
        tiradorSeleccionado = 1;
        caballeroSeleccionado =0;
    }

    public void OnSelect2(BaseEventData eventData)
    {

        ColorBlock cb = tirador.colors;
        cb.normalColor = Color.gray;
        tirador.colors = cb;
        tiradorSeleccionado = 0;
        caballeroSeleccionado =1;
        
    }



    public void CargarCreditos()
    {
        float volumen;
        audioMixer.GetFloat("volumen", out volumen);
        almacenamientoPersistente.GuardarVolumen(volumen);
        SceneManager.LoadScene("EscenaCreditos");
    }

    public void CerrarJuego()
    {
        Application.Quit();
    }

    public void SonidoEntrando()
    {
        sobreOpcionSonido.Play();
    }

    public void ValorSlider()
    {
        float volumenViejo = almacenamientoPersistente.ObtenerVolumen();
        slider.value = volumenViejo;
    }



}
