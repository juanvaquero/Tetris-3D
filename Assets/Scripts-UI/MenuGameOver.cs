using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour {


	public void reiniciarJuego()
    {
        SceneManager.LoadScene("Principal");
    }

    public void volverMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
