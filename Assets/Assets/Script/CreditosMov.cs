using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosDesplazamiento : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [SerializeField] private float velocidad = 100f; // Velocidad de subida
    [SerializeField] private float posicionFinalY = 1500f; // Altura donde terminan de subir

    [Header("Salida Explicita")]
    [SerializeField] private string nombreMenuPrincipal = "MenuPrincipal"; // Nombre de tu escena de menú

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // 1. Mover hacia arriba constantemente
        rectTransform.anchoredPosition += Vector2.up * velocidad * Time.deltaTime;

        // 2. Si llega a la altura final, regresar al menú
        if (rectTransform.anchoredPosition.y >= posicionFinalY)
        {
            RegresarAlMenu();
        }

        // 3. Permitir saltar los créditos al presionar espacio o escape
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            RegresarAlMenu();
        }
    }

    private void RegresarAlMenu()
    {
        SceneManager.LoadScene(nombreMenuPrincipal);
    }
}