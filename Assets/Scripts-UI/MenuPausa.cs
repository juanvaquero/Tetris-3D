using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPausa : MonoBehaviour {

    public static bool juegoPausado = false;

    public GameObject menuDePausaUI;

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (juegoPausado)
            {
                reanudar();
            }
            else
            {
                pausar();
            }

        }

	}

    public void reanudar()
    {
        menuDePausaUI.SetActive(false);
        Time.timeScale = 1f; //El tiempo se ejecuta de manera normal de nuevo.
        juegoPausado = false;
    }

    private void pausar()
    {
        menuDePausaUI.SetActive(true);
        Time.timeScale = 0f; //Pausamos el tiempo del juego.
        juegoPausado = true;
    }

    public void cargarMenu()
    {
        // volvemos a poner el timepo normal antes de volver al menu
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Menu");

    }

    public void salirJuego()
    {
        Application.Quit();
    }

}

