using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float velocidad = 1f; // Velocidad a la que el enemigo se mueve hacia abajo

    void Update()
    {
        // Mueve al enemigo hacia abajo (dirección negativa del eje Y)
        transform.position += Vector3.down * velocidad * Time.deltaTime;
    }
}
