using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManejadorDialogo : MonoBehaviour
{

    public Text nombreText;
    public Text dialogoText;

    public Animator animator;

    

    //public Animator animator;

    private Queue<string> frases;

    // Use this for initialization
    void Start()
    {
        frases = new Queue<string>();
    }

    public void EmpezarConversacion(Dialogo dialogo)
    {
        animator.SetBool("estaAbierto", true);

        nombreText.text = dialogo.nombre;

        frases.Clear();

        foreach (string frase in dialogo.frases)
        {
            frases.Enqueue(frase);
        }

        MostrarSiguienteFrase();
    }

    public void MostrarSiguienteFrase()
    {
        if (frases.Count == 0)
        {
            FinalizarDialogo();
            return;
        }

        string frase = frases.Dequeue();
        StopAllCoroutines();
        StartCoroutine(EscribirFrase(frase));
    }

    IEnumerator EscribirFrase(string frase)
    {
        dialogoText.text = "";
        foreach (char letra in frase.ToCharArray())
        {
            dialogoText.text += letra;
            yield return null;
        }
    }

    void FinalizarDialogo()
    {
        animator.SetBool("estaAbierto", false);
    }

}