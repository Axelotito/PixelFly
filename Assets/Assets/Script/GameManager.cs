using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    [UnitHeaderInspectable("Paneles de UI")]
    [SerializeField] private GameObject panelInicio;
    [SerializeField] private GameObject panelGameOver;
    
    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 0f; //estamos en pausa y en el menu
        if (panelInicio != null)
        {
            panelInicio.SetActive(true);
        }
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(false);
        }
    }

    public void IniciarJuego() {
        Time.timeScale = 1f; // se quita el pausa
        if (panelGameOver != null)
        {
            panelInicio.SetActive(false);
        }
    }

    public void ActivarGameOver()
    {
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f; // reinicia el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        
    }
}
