using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // El objetivo que la cámara seguirá (en este caso, el personaje)
    public Vector3 offset = new Vector3(0, 5, -10); // La distancia y el ángulo de la cámara respecto al jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para hacer la transición del movimiento más fluida
    public float rotationSpeed = 5f; // Velocidad a la que la cámara rota alrededor del personaje

    private void LateUpdate()
    {
        // Calcula la posición deseada de la cámara usando el offset
        Vector3 desiredPosition = target.position + offset;

        // Suaviza la transición entre la posición actual y la deseada para evitar movimientos bruscos
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Mantén la cámara mirando al jugador
        transform.LookAt(target);

        // Rotación de la cámara alrededor del jugador usando las entradas del ratón
        HandleCameraRotation();
    }

    private void HandleCameraRotation()
    {
        // Obtiene la entrada horizontal del ratón (eje X)
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;

        // Rota el objetivo alrededor del jugador en el eje Y para dar un efecto de seguimiento en tercera persona
        target.Rotate(0, horizontal, 0);

        // Recalcula la posición de la cámara con el nuevo ángulo del jugador
        Quaternion rotation = Quaternion.Euler(0, target.eulerAngles.y, 0);
        transform.position = target.position + rotation * offset;

        // Asegúrate de que la cámara siempre mire al objetivo
        transform.LookAt(target);
    }
}
