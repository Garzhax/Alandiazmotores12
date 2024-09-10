using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas
using UnityEngine.UI; // Necesario para manejar elementos de UI

public class WinAndRestart : MonoBehaviour
{
    public Text winText; // Referencia al texto de "You Win"
    public Button playAgainButton; // Referencia al bot�n "Play Again"

    void Start()
    {
        // Asegurarnos de que el texto y el bot�n est�n desactivados al inicio
        winText.gameObject.SetActive(false);
        playAgainButton.gameObject.SetActive(false);

        // Configurar el bot�n para reiniciar el nivel al hacer clic
        playAgainButton.onClick.AddListener(RestartLevel);
    }

    // Esta funci�n se llama cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Mostrar el mensaje de victoria y el bot�n para reiniciar
        ShowWinUI();
    }

    // Si el objeto es un Trigger (colisionador marcado como Trigger), usamos esta funci�n
    private void OnTriggerEnter(Collider other)
    {
        // Mostrar el mensaje de victoria y el bot�n para reiniciar
        ShowWinUI();
    }

    // Funci�n que muestra el mensaje de victoria y el bot�n "Play Again"
    void ShowWinUI()
    {
        winText.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
    }

    // Funci�n que reinicia el nivel actual
    void RestartLevel()
    {
        // Obtener el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Cargar la escena actual de nuevo (reiniciar)
        SceneManager.LoadScene(currentSceneName);
    }
}
