using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    public void IniciarJuego()
    {
        SceneManager.LoadScene("Main"); 
    }

    public void IrACreditos()
    {
        SceneManager.LoadScene("Creditos"); 
    }

    public void SalirDelJuego()
    {
        // Mensaje de consola para comprobar que funciona la opción
        Debug.Log("Saliendo del juego...");
        Application.Quit(); 
    }
}