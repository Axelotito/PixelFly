using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorPausa : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject panelPausa;
    public GameObject panelOpciones;
    public GameObject botonPausaUI;

    private bool juegoPausado = false;

    void Update()
    {
        // Detecta la tecla Escape para pausar/reanudar
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado) Reanudar();
            else Pausar();
        }
    }

    public void Pausar()
    {
        panelPausa.SetActive(true);
        botonPausaUI.SetActive(false);
        Time.timeScale = 0f; // Congela el juego
        juegoPausado = true;
    }

    public void Reanudar()
    {
        panelPausa.SetActive(false);
        panelOpciones.SetActive(false);
        botonPausaUI.SetActive(true);
        Time.timeScale = 1f; // Reanuda el juego
        juegoPausado = false;
    }

    // --- FUNCIONES DE LOS BOTONES ---

    public void AbrirOpciones()
    {
        panelPausa.SetActive(false);
        panelOpciones.SetActive(true);
    }

    public void CerrarOpciones()
    {
        panelOpciones.SetActive(false);
        panelPausa.SetActive(true);
    }

    public void CambiarVolumen(float volumen)
    {
        AudioListener.volume = volumen;
    }

    public void SalirAlMenu()
    {
        Time.timeScale = 1f; // CRÍTICO: Descongelar el tiempo antes de cambiar de escena
        SceneManager.LoadScene("MenuPrincipal");
    }
}