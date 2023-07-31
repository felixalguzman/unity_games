using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

public GameObject loadingScreen;
public Slider slider;

public Text progreso;
	public void LoadLevel(string name)
	{
		
		StartCoroutine(CargarAsincrono(name));
	}

	IEnumerator CargarAsincrono(string name)
	{
		AsyncOperation operation =  SceneManager.LoadSceneAsync(name);

		loadingScreen.SetActive(true);

		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress)/0.9f;

			slider.value = progress;
			progreso.text = progress * 100f +"%";

			yield return null;
		}
		if (operation.isDone)
		{
			ControlJuego.tiempoInicio = Time.time;
		}
	}
	
}
