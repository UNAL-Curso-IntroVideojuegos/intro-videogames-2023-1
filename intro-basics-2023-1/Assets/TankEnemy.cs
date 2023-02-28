using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public Transform startPoint; // Variable para el objeto vacío de inicio
    public Transform endPoint; // Variable para el objeto vacío final
    public float speed = 1.0f; // Velocidad del movimiento del objeto móvil

    private Vector3 direction; // Vector de dirección entre los dos puntos

    void Start()
    {
        // Calcula el vector de dirección entre los dos puntos
        direction = (endPoint.position - startPoint.position).normalized;
    }

    void Update()
    {
        float step = speed * Time.deltaTime; // Calcula la distancia que se mueve el objeto en un frame
        transform.position += direction * step; // Mueve el objeto a lo largo del vector de dirección
        if (Vector3.Distance(transform.position, endPoint.position) <= 0.05f) // Si llega al objeto final, lo mueve hacia el objeto inicial
        {
            transform.position = startPoint.position;
        }
    }
}
