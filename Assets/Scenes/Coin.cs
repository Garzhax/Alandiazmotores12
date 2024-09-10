using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points = 1; // Puntos que otorga el ítem

    // Este método se llama cuando otro collider entra en el trigger
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            // Envía la cantidad de puntos al script del jugador
            other.GetComponent<PlayerController>().AddPoints(points);

            // Destruye el objeto ítem
            Destroy(gameObject);
        }
    }
}
