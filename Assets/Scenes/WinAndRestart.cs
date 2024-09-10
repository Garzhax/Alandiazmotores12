using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas
using UnityEngine.UI; // Necesario para manejar elementos de UI

public class WinAndRestart : MonoBehaviour
{
    public Text winText; // Referencia al texto de "You Win"
    public Button playAgainButton; // Referencia al botón "Play Again"

    void Start()
    {
        // Asegurarnos de que el texto y el botón están desactivados al inicio
        winText.gameObject.SetActive(false);
        playAgainButton.gameObject.SetActive(false);

        // Configurar el botón para reiniciar el nivel al hacer clic
        playAgainButton.onClick.AddListener(RestartLevel);
    }

    // Esta función se llama cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Mostrar el mensaje de victoria y el botón para reiniciar
        ShowWinUI();
    }

    // Si el objeto es un Trigger (colisionador marcado como Trigger), usamos esta función
    private void OnTriggerEnter(Collider other)
    {
        // Mostrar el mensaje de victoria y el botón para reiniciar
        ShowWinUI();
    }

    // Función que muestra el mensaje de victoria y el botón "Play Again"
    void ShowWinUI()
    {
        winText.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
    }

    // Función que reinicia el nivel actual
    void RestartLevel()
    {
        // Obtener el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Cargar la escena actual de nuevo (reiniciar)
        SceneManager.LoadScene(currentSceneName);
    }
}
