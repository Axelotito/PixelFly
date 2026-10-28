using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    [Header("UI")]
    [SerializeField] private GameObject panelGameOver;

    [Header("Audio")]
    public AudioSource musicaFondo; // Solo controlamos la música aquí
    
    private void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1f; 
        
        if (panelGameOver != null)
            panelGameOver.SetActive(false);
    }

    public void ActivarGameOver()
    {
        if (panelGameOver != null)
            panelGameOver.SetActive(true);

        // Apaga la música general. El script del jugador reproducirá su sonido.
        if (musicaFondo != null) 
            musicaFondo.Stop();
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}