using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDialogo : MonoBehaviour
{

    public Dialogo dialogo;

    void Start()
    {
        Invoke("IniciarConversacion",2f);
    }

    public void IniciarConversacion ()
    {
        FindObjectOfType<ManejadorDialogo>().EmpezarConversacion(dialogo);
    }

}