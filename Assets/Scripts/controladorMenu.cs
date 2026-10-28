using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    // Arrastraremos el panel a esta variable desde el editor
    public GameObject panelOpciones; 

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
        Debug.Log("Saliendo del juego..."); 
        Application.Quit(); 
    }

    // --- FUNCIONES PARA LAS OPCIONES ---

    public void AbrirOpciones()
    {
        panelOpciones.SetActive(true);
    }

    public void CerrarOpciones()
    {
        panelOpciones.SetActive(false);
    }

    public void CambiarVolumen(float volumen)
    {
        AudioListener.volume = volumen; 
    }
}