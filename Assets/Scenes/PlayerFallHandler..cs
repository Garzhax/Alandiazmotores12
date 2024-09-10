using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas

public class PlayerFallHandler : MonoBehaviour
{
    public float fallThreshold = -10f; // Altura en la que el jugador será considerado caído

    void Update()
    {
        // Si la posición en Y del jugador está por debajo del umbral de caída
        if (transform.position.y < fallThreshold)
        {
            // Llamar a la función que reinicia el nivel
            RestartLevel();
        }
    }

    // Función para reiniciar el nivel actual
    void RestartLevel()
    {
        // Obtener el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Cargar la escena actual de nuevo (reiniciar)
        SceneManager.LoadScene(currentSceneName);
    }
}
