using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour {

AlmacenamientoPersistente almacenamientoPersistente;

void Start()
{
	almacenamientoPersistente = GameObject.Find("Almacenamiento").GetComponent<AlmacenamientoPersistente>();
}
	
	public void Jugar()
	{
		almacenamientoPersistente.HistoriaIniciada(1);
		SceneManager.LoadScene("EscenaNivel1");
	}

	public void Tienda()
	{
		SceneManager.LoadScene("Tienda");
	}
}
