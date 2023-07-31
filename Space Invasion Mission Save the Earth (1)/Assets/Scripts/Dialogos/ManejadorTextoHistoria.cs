using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManejadorTextoHistoria : MonoBehaviour
{

    public Text historiaText;

    public Button continuarButton;

    public Sprite[] imagenesHistoria;

    public Image imagenActual;

    public GameObject historiaCaja;

    int contadorFrases;

    //public Animator animator;

    private Queue<string> frases;

    // Use this for initialization
    void Start()
    {
        frases = new Queue<string>();
        contadorFrases = 0;
        imagenActual.sprite = imagenesHistoria[0];
        FindObjectOfType<ControlHistoria>().IniciarConversacion();
    }

    void Update()
    {
        if (contadorFrases == 2)
        {
            imagenActual.sprite = imagenesHistoria[contadorFrases - 1]; 
        }
    }

    public void EmpezarConversacion(string[] frasesHistoria)
    {

        frases.Clear();
        historiaCaja.SetActive(true);

        foreach (string frase in frasesHistoria)
        {
            frases.Enqueue(frase);
        }

        MostrarSiguienteFrase();
    }

    public void MostrarSiguienteFrase()
    {
        if (frases.Count == 0)
        {
            FinalizarHistoria();
            SceneManager.LoadScene("EscenaInicial");
            return;
        }

        string frase = frases.Dequeue();
        contadorFrases++;
        StopAllCoroutines();
        StartCoroutine(EscribirFrase(frase));
    }

    IEnumerator EscribirFrase(string frase)
    {
        historiaText.text = "";
        foreach (char letra in frase.ToCharArray())
        {
            historiaText.text += letra;
            yield return null;
        }
    }

    void FinalizarHistoria()
    {
        historiaCaja.SetActive(false);
        continuarButton.gameObject.SetActive(false);
    }

}