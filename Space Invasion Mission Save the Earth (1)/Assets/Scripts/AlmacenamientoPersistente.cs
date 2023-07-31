using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.IO;

public class AlmacenamientoPersistente : MonoBehaviour
{

    [DataContract]
    public class Mejoras
    {

        [DataMember]
        public int dinero { get; set; }

        [DataMember]
        public int nivelItem1 { get; set; }

        [DataMember]
        public int nivelItem2 { get; set; }

        [DataMember]
        public int nivelItem3 { get; set; }

        [DataMember]
        public int nivelItem4 { get; set; }

        [DataMember]
        public int dineroItem1 { get; set; }

        [DataMember]
        public int dineroItem2 { get; set; }

        [DataMember]
        public int dineroItem3 { get; set; }

        [DataMember]
        public int dineroItem4 { get; set; }

    }

    [DataContract]
    public class Puntos
    {
        [DataMember]
        public int puntuacion { get; set; }

        [DataMember]
        public int nivel { get; set; }

    }

    [DataContract]
    public class EstadoJuego
    {
        [DataMember]
        public Mejoras mejoras;

        [DataMember]
        public Puntos puntos;

        [DataMember]
        public string modoJuego;
    }

    public void RegistrarNivel(int nivel)
    {
        PlayerPrefs.SetInt("nivel", nivel);
    }

    public void RegistrarDinero(int dinero)
    {
        PlayerPrefs.SetInt("dinero", dinero);
    }


    public void RegistrarPuntuacion(int puntos)
    {
        PlayerPrefs.SetInt("puntuacion", puntos);
    }

    public int ObtnerPuntuacion()
    {
        return PlayerPrefs.GetInt("puntuacion", 0);
    }

    public int ObtenerDinero()
    {
        return PlayerPrefs.GetInt("dinero", 0);
    }

    public void RegistrarPrecios(int dineroItem1, int dineroItem2, int dineroItem3, int dineroItem4)
    {
        PlayerPrefs.SetInt("dineroItem1", dineroItem1);
        PlayerPrefs.SetInt("dineroItem2", dineroItem2);
        PlayerPrefs.SetInt("dineroItem3", dineroItem3);
        PlayerPrefs.SetInt("dineroItem4", dineroItem4);
    }

    public int ObtenerDineroItem1()
    {
        return PlayerPrefs.GetInt("dineroItem1", 100);
    }

    public int ObtenerDineroItem2()
    {
        return PlayerPrefs.GetInt("dineroItem2", 200);
    }

    public int ObtenerDineroItem3()
    {
        return PlayerPrefs.GetInt("dineroItem1", 300);
    }

    public int ObtenerDineroItem4()
    {
        return PlayerPrefs.GetInt("dineroItem1", 400);
    }


    public void RegistrarNivelesItems(int nivelItem1, int nivelItem2, int nivelItem3, int nivelItem4)
    {
        PlayerPrefs.SetInt("nivelItem1", nivelItem1);
        PlayerPrefs.SetInt("nivelItem2", nivelItem2);
        PlayerPrefs.SetInt("nivelItem3", nivelItem3);
        PlayerPrefs.SetInt("nivelItem4", nivelItem4);
    }

    public int ObtenerNivelItem1()
    {
        return PlayerPrefs.GetInt("nivelItem1", 1);
    }

    public int ObtenerNivelItem2()
    {
        return PlayerPrefs.GetInt("nivelItem2", 1);
    }

    public int ObtenerNivelItem3()
    {
        return PlayerPrefs.GetInt("nivelItem3", 1);
    }

    public int ObtenerNivelItem4()
    {
        return PlayerPrefs.GetInt("nivelItem4", 1);
    }
    public void HistoriaIniciada(int iniciada)
    {
        PlayerPrefs.SetInt("historia", iniciada);
    }

    public bool ObtenerHistoriaIniciada()
    {
        return PlayerPrefs.GetInt("historia", 0) == 1 ? true : false;
    }

    public void GuardarModoJuego(string modo)
    {
        PlayerPrefs.SetString("modo", modo);
    }

    public string ObtenerModoJuego()
    {
        return PlayerPrefs.GetString("modo", "muyfacil");
    }

    public int ObtenerNivel()
    {
        return PlayerPrefs.GetInt("nivel", 0);
    }

    public void GuardarEstadoJuego(int dinero, int nivelItem1, int nivelItem2, int nivelItem3, int nivelItem4, int dineroItem1, int dineroItem2, int dineroItem3, int dineroItem4, int puntuacion, int nivel, string modoJuego)
    {

        // Paso 1: Instanciar EstadoJuego
        EstadoJuego nuevoEstado = new EstadoJuego();
        Mejoras mejoras = new Mejoras();
        Puntos puntos = new Puntos();

        mejoras.dinero = dinero;
        mejoras.dineroItem1 = dineroItem1;
        mejoras.dineroItem2 = dineroItem2;
        mejoras.dineroItem3 = dineroItem3;
        mejoras.dineroItem4 = dineroItem4;
        mejoras.nivelItem1 = nivelItem1;
        mejoras.nivelItem2 = nivelItem2;
        mejoras.nivelItem3 = nivelItem3;
        mejoras.nivelItem4 = nivelItem4;

        puntos.nivel = nivel;
        puntos.puntuacion = puntuacion;

        nuevoEstado.mejoras = mejoras;
        nuevoEstado.puntos = puntos;
        nuevoEstado.modoJuego = modoJuego;



        // Paso 2: Acceder al archivo
        using (FileStream fileStream = new FileStream(Application.persistentDataPath + "/temporal.xml", FileMode.Create))
        {
            // Paso 3: Serializar
            DataContractSerializer dataContract = new DataContractSerializer(typeof(EstadoJuego));
            dataContract.WriteObject(fileStream, nuevoEstado);
        }

    }

    public EstadoJuego CargarEstadoJuego()
    {
        // Paso 1: Instanciar EstadoJuego
        EstadoJuego nuevoEstado;
        // Paso 2: Acceder al archivo
        using (FileStream fileStream = new FileStream(Application.persistentDataPath + "/temporal.xml", FileMode.Open))
        {
            // Paso 3: Serializar
            DataContractSerializer dataContract = new DataContractSerializer(typeof(EstadoJuego));
            nuevoEstado = (EstadoJuego)dataContract.ReadObject(fileStream);
            return nuevoEstado;
        }

    }

}
