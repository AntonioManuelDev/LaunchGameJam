using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int salud = 3; // Salud inicial del enemigo

    // Método que recibe el daño
    public void RecibirDaño(int cantidadDaño)
    {
        salud -= cantidadDaño;

        if (salud <= 0)
        {
            Destroy(gameObject); // Destruye al enemigo si su salud llega a 0
        }
    }
}
