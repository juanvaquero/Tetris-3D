using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//En caso de que halla piezas sin cubos, 
//esta clase sera la encargada de borrarlos.
public class RecolectorBasura : MonoBehaviour
{
    public float intervalo;
    float tiempo;

    void FixedUpdate()
    {
        tiempo += Time.fixedDeltaTime;
        if (tiempo > intervalo)
        {
            tiempo = 0;
            foreach (GameObject pieza in GameObject.FindGameObjectsWithTag("Pieza"))
            {
                if (pieza.transform.childCount == 0)
                {
                    Destroy(pieza);
                }
            }
        }
    }
}
