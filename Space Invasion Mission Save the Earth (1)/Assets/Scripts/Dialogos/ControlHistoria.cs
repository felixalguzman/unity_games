using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHistoria : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] frases;

    public void IniciarConversacion ()
    {
        FindObjectOfType<ManejadorTextoHistoria>().EmpezarConversacion(frases);
    }

}