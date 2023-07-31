using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTransicionEscena : MonoBehaviour
{

    public Texture2D texturaDeTransicion; // La textura que cubrira la escena
    public float velocidadTransicion = 0.08f;

    private int profundidadDibujo = -1000; //Orden de las texturas en la jerarquia, al ser negativo, se muestra sobre todo

    private float alpha = 1.0f;

    private int direccionTransicion = -1; //Dentro = -1 Out = 1

    private void OnGUI() //Utilizado para determinar la entrada y salida de la transicion
    {
        alpha += direccionTransicion * velocidadTransicion * Time.deltaTime; //Fuerza al numero alpha a estar entre 0 y 1
        alpha = Mathf.Clamp01(alpha);

        //Determinar el color de la transicion
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);    //Determinar el valor de alpha
        GUI.depth = profundidadDibujo;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texturaDeTransicion); //Dibuja la transicion para cubrir toda la pantalla

    }

    //Inicializar la direccion haciendo que la escena varie en -1 o 1 
    public float ComenzarTransicion(int direccion)
    {
        direccionTransicion = direccion;
        return velocidadTransicion; // Retorna la velocidad de transicion para medir el tiempo 
    }

    //Toma el indice de la escena a cargar como parametro
    void CargadoEnElNivel()
    {
        ComenzarTransicion(-1);
    }
}