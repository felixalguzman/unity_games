using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.IO;

public class AlmacenamientoPersistente : MonoBehaviour {

	[DataContract]
	public class Sonido
	{
		[DataMember]
		public float Volumen;
	}

	public void GuardarVolumen(float volumen)
	{
		PlayerPrefs.SetFloat("VolumenActual",volumen);
	}

	public float ObtenerVolumen()
	{
		return PlayerPrefs.GetFloat("VolumenActual");
	}

	[DataContract]
	public class PuntuacionesJuego{
		[DataMember]
		public int puntuacion;
		[DataMember]
		public int nivel;
		[DataMember]
		public float tiempo;
		[DataMember]
		public	int enemigos;
		[DataMember]
		public int monedas;
		[DataMember]	
		public int powerUps;
	}

	public void GuardarEstadoJuego(int puntuacion, int nivel, float tiempo, int enemigos, int monedas, int powerUps)
	{
		PuntuacionesJuego nuevaPuntuacionesJuego = new PuntuacionesJuego();

		nuevaPuntuacionesJuego.puntuacion = puntuacion;
		nuevaPuntuacionesJuego.nivel = nivel;
		nuevaPuntuacionesJuego.tiempo = tiempo;
		nuevaPuntuacionesJuego.enemigos = enemigos;
		nuevaPuntuacionesJuego.monedas = monedas;
		nuevaPuntuacionesJuego.powerUps = powerUps;



		using (FileStream fileStream = new FileStream(Application.persistentDataPath + "/temporal.xml", FileMode.Create))
		{
			DataContractSerializer dataContract = new DataContractSerializer(typeof(PuntuacionesJuego));
			dataContract.WriteObject(fileStream, nuevaPuntuacionesJuego);
		}
	}

	public PuntuacionesJuego CargarPuntuacionJuego(int puntuacion, int nivel, float tiempo, int enemigos, int monedas, int powerUps)
	{
		PuntuacionesJuego nuevaPuntuacionesJuego ;


		using (FileStream fileStream = new FileStream(Application.persistentDataPath + "/temporal.xml", FileMode.Open))
		{
			DataContractSerializer dataContract = new DataContractSerializer(typeof(PuntuacionesJuego));
			nuevaPuntuacionesJuego = (PuntuacionesJuego)dataContract.ReadObject(fileStream);
			return nuevaPuntuacionesJuego;
		}
	}
}
