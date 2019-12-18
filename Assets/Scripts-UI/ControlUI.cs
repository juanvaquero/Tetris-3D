using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlUI : MonoBehaviour {

 // [SerializeField]
 //   GameObject ob;
    [SerializeField]
    int numEscena;

    public void salir() {Application.Quit();}
    public void mostrarControles() { SceneManager.LoadScene("Controles"); }
    public void jugar() { SceneManager.LoadScene(numEscena); }
 //   public void ayudaON() { ob.SetActive(true); }
 //   public void ayudaOFF() { ob.SetActive(false); }

}
