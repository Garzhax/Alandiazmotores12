using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; // Referencia al jugador que la cámara seguirá
    public Vector3 offset;   // Offset para posicionar la cámara detrás del jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el seguimiento de la cámara
    public float rotationSpeed = 100f; // Velocidad de rotación de la cámara al mover el ratón

    void Start()
    {
        // Si no has asignado un offset manualmente, este se calcula en base a la posición inicial de la cámara
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void FixedUpdate()
    {
        // Llamamos a la función para seguir al jugador
        FollowPlayer();

        // Llamamos a la función para rotar la cámara con el movimiento del ratón
        RotateCamera();
    }

    void FollowPlayer()
    {
        // Posición deseada para la cámara, en base a la posición del jugador más el offset
        Vector3 desiredPosition = player.position + offset;

        // Suavizamos el movimiento para evitar cambios bruscos de posición
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizamos la posición de la cámara
        transform.position = smoothedPosition;
    }

    void RotateCamera()
    {
        // Obtenemos los movimientos del ratón en los ejes X e Y
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        // Rotamos al jugador en el eje Y con el movimiento horizontal del ratón
        player.Rotate(0, horizontalInput, 0);

        // Recalculamos la posición de la cámara para mantenerla detrás del jugador
        Quaternion camTurnAngle = Quaternion.AngleAxis(horizontalInput, Vector3.up);
        offset = camTurnAngle * offset;

        // Mantiene la cámara mirando hacia el jugador
        transform.LookAt(player);
    }
}

