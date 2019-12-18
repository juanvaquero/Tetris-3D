using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour {

    public GameObject[] piezas;

	// Use this for initialization
	void Start ()
    {
        instanciar();
    }


    public void instanciar()
    {
        int aux = Random.Range(0, piezas.Length);
        Instantiate(piezas[aux], transform.position, Quaternion.identity);
    }
}
