using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento del jugador
    private Rigidbody rb; // Variable para almacenar el componente Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el componente Rigidbody del objeto al inicio
    }

    void FixedUpdate()
    {
        // Obtiene las entradas del teclado para el movimiento horizontal y vertical
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Crea un vector de movimiento a partir de las entradas del teclado
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        // Aplica una fuerza al Rigidbody para mover el personaje
        rb.AddForce(movement * moveSpeed);
    }
}
