using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento del jugador
    public float jumpForce = 10f; // Fuerza del salto
    public Transform groundCheck; // Referencia al objeto que se usa para comprobar si el jugador está en el suelo
    public LayerMask groundLayer; // Capa que representa el suelo
    public Text scoreText; // Referencia al texto de la puntuación

    private Rigidbody rb; // Variable para almacenar el componente Rigidbody
    private bool isGrounded; // Booleano para verificar si el jugador está en el suelo
    private int score = 0; // Puntuación actual

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el componente Rigidbody del objeto al inicio

        // Verifica si el Rigidbody se ha obtenido correctamente
        if (rb == null)
        {
            Debug.LogError("Rigidbody no encontrado en el objeto.");
        }

        // Inicializa el texto de la puntuación
        UpdateScoreText();
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

    // Método para añadir puntos al jugador
    public void AddPoints(int points)
    {
        score += points; // Incrementa la puntuación
        UpdateScoreText(); // Actualiza el texto de la puntuación en la UI
    }

    // Método para actualizar el texto de la puntuación en la UI
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Muestra la puntuación en la UI
        }
    }
}

