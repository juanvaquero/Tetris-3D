using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorMultiplicador : MonoBehaviour {


    public Text mult;

    public void reiniciarMultiplicador()
    {
        transform.GetComponent<Animator>().SetInteger("mult", 1);
        mult.text = "x1";
        ControladorNivel.controlador.multiplicadorPuntuacion = 1;
    }
}
