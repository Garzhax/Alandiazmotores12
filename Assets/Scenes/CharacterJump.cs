using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento del jugador
    public float jumpForce = 10f; // Fuerza del salto
    public Transform groundCheck; // Referencia al objeto que se usa para comprobar si el jugador está en el suelo
    public LayerMask groundLayer; // Capa que representa el suelo

    private Rigidbody rb; // Variable para almacenar el componente Rigidbody
    private bool isGrounded; // Booleano para verificar si el jugador está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el componente Rigidbody del objeto al inicio

        // Verifica si el Rigidbody se ha obtenido correctamente
        if (rb == null)
        {
            Debug.LogError("Rigidbody no encontrado en el objeto.");
        }
    }

    void Update()
    {
        // Obtiene las entradas del teclado para el movimiento horizontal y vertical
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Crea un vector de movimiento a partir de las entradas del teclado
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        // Aplica una fuerza al Rigidbody para mover el personaje
        if (rb != null)
        {
            rb.AddForce(movement * moveSpeed);
        }

        // Comprueba si el jugador está en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        // Maneja el salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Aplica una fuerza hacia arriba para saltar
        }
    }
}
