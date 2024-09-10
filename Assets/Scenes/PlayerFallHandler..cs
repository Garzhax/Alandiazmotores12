using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas

public class PlayerFallHandler : MonoBehaviour
{
    public float fallThreshold = -10f; // Altura en la que el jugador ser� considerado ca�do

    void Update()
    {
        // Si la posici�n en Y del jugador est� por debajo del umbral de ca�da
        if (transform.position.y < fallThreshold)
        {
            // Llamar a la funci�n que reinicia el nivel
            RestartLevel();
        }
    }

    // Funci�n para reiniciar el nivel actual
    void RestartLevel()
    {
        // Obtener el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Cargar la escena actual de nuevo (reiniciar)
        SceneManager.LoadScene(currentSceneName);
    }
}
