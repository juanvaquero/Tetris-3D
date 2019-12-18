using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorUI : MonoBehaviour {

    ControladorNivel c;

    public Text puntos;
    public Text mult;
    public Image borde1;

    private Animator borde;

    public void Start()
    {
        c = ControladorNivel.controlador;
        borde = borde1.GetComponent<Animator>();

        //Iniacializamos la UI.
        puntos.text = "0 pt";
        mult.text = "x1";
    }


    public void actualizarPuntuacion(int puntuacion)
    {
        puntos.text = puntuacion.ToString() + " pt";
    }

    public void actualizarMultiplicador(int multiplicador)
    {
        mult.text = "x" + multiplicador.ToString();

        //Ejecutar animacion
        borde.SetInteger("mult", multiplicador);
        borde.SetTrigger("activar");    

    }

}
