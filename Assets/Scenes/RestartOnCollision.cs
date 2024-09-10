using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas

public class RestartOnCollision : MonoBehaviour
{
    // Esta funci�n se llama cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Reinicia el nivel si el jugador colisiona con cualquier objeto
        RestartLevel();
    }

    // Si el objeto es un Trigger (colisionador marcado como Trigger), usamos esta funci�n
    private void OnTriggerEnter(Collider other)
    {
        // Reinicia el nivel si el jugador entra en el Trigger de otro objeto
        RestartLevel();
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

