using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogo
{

    public string nombre;

    [TextArea(3, 10)]
    public string[] frases;


    void CargarTexto(TextAsset texto)
    {
        if (texto != null)
        {
            frases = (texto.text.Split('\n'));
        }

    }

}