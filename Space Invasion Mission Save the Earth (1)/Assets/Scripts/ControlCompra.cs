using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class ControlCompra : MonoBehaviour
{


    public TextMeshProUGUI txtDinero;
    public TextMeshProUGUI[] precio;
    public TextMeshProUGUI[] txtNivelMejora;


    private int seleccion = 7, dinero;
    private int nivelItem1 = 1, nivelItem2 = 1, nivelItem3 = 1, nivelItem4 = 1;
    private int precioItem1, precioItem2, precioItem3, precioItem4;

	AlmacenamientoPersistente almacenamientoPersistente;

    // Use this for initialization
    void Start()
    {
        
		almacenamientoPersistente = GameObject.Find("Almacenamiento").GetComponent<AlmacenamientoPersistente>();
        ActualizarTextos();

    }

   

    public void BuscarPrecios()
    {
        precioItem1 = almacenamientoPersistente.ObtenerDineroItem1();
		precioItem2 = almacenamientoPersistente.ObtenerDineroItem2();
		precioItem3 = almacenamientoPersistente.ObtenerDineroItem3();
		precioItem4 = almacenamientoPersistente.ObtenerDineroItem4();

    }

	public void GuardarPrecios()
    {
		almacenamientoPersistente.RegistrarPrecios(precioItem1,precioItem2, precioItem3, precioItem4 );
    }

	public void GuardarNiveles()
	{
		almacenamientoPersistente.RegistrarNivelesItems(nivelItem1, nivelItem2, nivelItem3, nivelItem4);
	}

    public void BuscarNiveles()
    {
		nivelItem1 = almacenamientoPersistente.ObtenerNivelItem1();
		nivelItem2 = almacenamientoPersistente.ObtenerNivelItem2();
		nivelItem3 = almacenamientoPersistente.ObtenerNivelItem3();
		nivelItem4 = almacenamientoPersistente.ObtenerNivelItem4();
    }
    public void ActualizarTextos()
    {
		BuscarNiveles();
		BuscarPrecios();

        txtDinero.text = "Dinero: " + dinero + "$";
        txtNivelMejora[0].text = nivelItem1 + "/ 5";
        txtNivelMejora[1].text = nivelItem2 + "/ 5";
        txtNivelMejora[2].text = nivelItem3 + "/ 5";
        txtNivelMejora[3].text = nivelItem4 + "/ 5";

        precio[0].text = precioItem1 + " $";
        precio[1].text = precioItem2 + " $";
        precio[2].text = precioItem3 + " $";
        precio[3].text = precioItem4 + " $";

    }



    public void SeleccionarItem1()
    {
        seleccion = 0;
    }

    public void SeleccionarItem2()
    {
        seleccion = 1;
    }

    public void SeleccionarItem3()
    {
        seleccion = 2;
    }

    public void SeleccionarItem4()
    {
        seleccion = 3;
    }

    public void Comprar()
    {
        switch (seleccion)
        {
            case 0:

                if (nivelItem1 < 5 && dinero > precioItem1)
                {
                    precioItem1 += 100;
                    nivelItem1 += 1;

                }



                break;

            case 1:

                if (nivelItem2 < 5 && dinero > precioItem2)
                {
                    precioItem2 += 100;
                    nivelItem2 += 1;
                }

                break;

            case 2:

                if (nivelItem3 < 5 && dinero > precioItem3)
                {
                    precioItem3 += 100;
                    nivelItem3 += 1;
                }

                break;

            case 3:

                if (nivelItem4 < 5 && dinero > precioItem4)
                {
                    precioItem4 += 100;
                    nivelItem4 += 1;
                }

                break;

        }

		GuardarNiveles();
		GuardarPrecios();
        ActualizarTextos();
    }

    public void CambiarEscena()
    {
        SceneManager.LoadScene("Menu");
    }


}
