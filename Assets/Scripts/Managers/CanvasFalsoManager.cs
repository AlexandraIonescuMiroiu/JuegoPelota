using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasFalsoManager : MonoBehaviour
{
    public void EmpezarPartida()
    {
        //Cargar escena 1
        SceneManager.LoadScene(1);

    }
    public void TerminarJuego()
    {
        //Solo funciona en el ejecutable
        Application.Quit();
    }
}
