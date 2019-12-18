using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCreditos : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Ejecutar la animacion del fade para hacer una transicion suave.
            SceneManager.LoadScene("Menu");
        }

	}
}
