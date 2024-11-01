using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int salud = 3; // Salud inicial del enemigo

    // M�todo que recibe el da�o
    public void RecibirDa�o(int cantidadDa�o)
    {
        salud -= cantidadDa�o;

        if (salud <= 0)
        {
            Destroy(gameObject); // Destruye al enemigo si su salud llega a 0
        }
    }
}
