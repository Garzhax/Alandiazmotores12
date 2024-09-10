using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; // Referencia al jugador que la c�mara seguir�
    public Vector3 offset;   // Offset para posicionar la c�mara detr�s del jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el seguimiento de la c�mara
    public float rotationSpeed = 100f; // Velocidad de rotaci�n de la c�mara al mover el rat�n

    void Start()
    {
        // Si no has asignado un offset manualmente, este se calcula en base a la posici�n inicial de la c�mara
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void FixedUpdate()
    {
        // Llamamos a la funci�n para seguir al jugador
        FollowPlayer();

        // Llamamos a la funci�n para rotar la c�mara con el movimiento del rat�n
        RotateCamera();
    }

    void FollowPlayer()
    {
        // Posici�n deseada para la c�mara, en base a la posici�n del jugador m�s el offset
        Vector3 desiredPosition = player.position + offset;

        // Suavizamos el movimiento para evitar cambios bruscos de posici�n
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizamos la posici�n de la c�mara
        transform.position = smoothedPosition;
    }

    void RotateCamera()
    {
        // Obtenemos los movimientos del rat�n en los ejes X e Y
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        // Rotamos al jugador en el eje Y con el movimiento horizontal del rat�n
        player.Rotate(0, horizontalInput, 0);

        // Recalculamos la posici�n de la c�mara para mantenerla detr�s del jugador
        Quaternion camTurnAngle = Quaternion.AngleAxis(horizontalInput, Vector3.up);
        offset = camTurnAngle * offset;

        // Mantiene la c�mara mirando hacia el jugador
        transform.LookAt(player);
    }
}

