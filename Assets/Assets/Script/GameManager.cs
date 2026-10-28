using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    [UnitHeaderInspectable("Paneles de UI")]
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
        // Asegura que las físicas corran a velocidad normal nada más cargar la escena
        Time.timeScale = 1f; 

        if(panelGameOver != null){
            panelGameOver.SetActive(false);
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
        Time.timeScale = 1f; // reinicia el juego a velocidad normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}