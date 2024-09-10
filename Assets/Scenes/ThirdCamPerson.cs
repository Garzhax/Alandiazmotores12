using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // El objetivo que la c�mara seguir� (en este caso, el personaje)
    public Vector3 offset = new Vector3(0, 5, -10); // La distancia y el �ngulo de la c�mara respecto al jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para hacer la transici�n del movimiento m�s fluida
    public float rotationSpeed = 5f; // Velocidad a la que la c�mara rota alrededor del personaje

    private void LateUpdate()
    {
        // Calcula la posici�n deseada de la c�mara usando el offset
        Vector3 desiredPosition = target.position + offset;

        // Suaviza la transici�n entre la posici�n actual y la deseada para evitar movimientos bruscos
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Mant�n la c�mara mirando al jugador
        transform.LookAt(target);

        // Rotaci�n de la c�mara alrededor del jugador usando las entradas del rat�n
        HandleCameraRotation();
    }

    private void HandleCameraRotation()
    {
        // Obtiene la entrada horizontal del rat�n (eje X)
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;

        // Rota el objetivo alrededor del jugador en el eje Y para dar un efecto de seguimiento en tercera persona
        target.Rotate(0, horizontal, 0);

        // Recalcula la posici�n de la c�mara con el nuevo �ngulo del jugador
        Quaternion rotation = Quaternion.Euler(0, target.eulerAngles.y, 0);
        transform.position = target.position + rotation * offset;

        // Aseg�rate de que la c�mara siempre mire al objetivo
        transform.LookAt(target);
    }
}
