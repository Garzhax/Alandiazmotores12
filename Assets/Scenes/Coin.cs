using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points = 1; // Puntos que otorga el �tem

    // Este m�todo se llama cuando otro collider entra en el trigger
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            // Env�a la cantidad de puntos al script del jugador
            other.GetComponent<PlayerController>().AddPoints(points);

            // Destruye el objeto �tem
            Destroy(gameObject);
        }
    }
}
