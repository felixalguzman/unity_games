using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlMensajes : MonoBehaviour
{

    public static int Puntos = 0, Nivel = 0, Monedas = 0;
    public static int SiguienteNivel = 0;
    public TextMesh NivelText, PuntuacionText, SiguienteNivelText,MonedasText;

    public AudioSource subirNivel;

    private void Awake()
    {
        Puntos = 0;
        Nivel = 0;
        Monedas = 0;
        SiguienteNivel = 0;
    }
    // Use this for initialization
    void Start()
    {
        PuntuacionText.text = "Puntos: " + Puntos.ToString();
        NivelText.text = "Nivel: " + Nivel.ToString();
        SiguienteNivelText.text = "Siguiente Nivel: "+ SiguienteNivel.ToString();
        MonedasText.text = "Monedas " + Monedas.ToString();
    }
 
    public void AumentarPuntos()
    {
        Puntos++;
        PuntuacionText.text = "Puntos: " + Puntos.ToString();

    }

    public void AumentarNivel()
    {
        Nivel++;
        NivelText.text = "Nivel: " + Nivel.ToString();
        subirNivel.Play();

    }

    public void NuevoNivel(int monstruosRestantes)
    {
        SiguienteNivel = monstruosRestantes;
    
        SiguienteNivelText.text = "Siguiente Nivel: "+ monstruosRestantes.ToString();
        
    }

    public void ActualizarSiguienteNivel()
    {
        
        if (SiguienteNivel > 0)
        {
            SiguienteNivel--;
            SiguienteNivelText.text = "Siguiente Nivel: "+ SiguienteNivel.ToString();
        }
        
    }

    public void AumentarMonedas()
    {
        Monedas++;
        MonedasText.text = "Monedas: " + Monedas.ToString();

    }


}


