using UnityEngine;
using System.Collections.Generic;

public class Spear : MonoBehaviour
{
    public float velocidad = 10f;           // Velocidad de la lanza
    public float tiempoDeVida = 5f;         // Tiempo de vida de la lanza antes de destruirse
    public int da�o = 1;                    // Da�o que causa la lanza

    private HashSet<GameObject> enemigosImpactados = new HashSet<GameObject>(); // Lista de enemigos impactados

    void Start()
    {
        // Destruye la lanza despu�s del tiempo de vida especificado
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        // Mueve la lanza hacia adelante en la direcci�n en la que est� apuntando
        transform.position += transform.right * velocidad * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto con el que colisiona es un enemigo y si no ha sido impactado anteriormente
        if (collision.CompareTag("Enemigo") && !enemigosImpactados.Contains(collision.gameObject))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.RecibirDa�o(da�o); // El enemigo recibe el da�o de la lanza
                enemigosImpactados.Add(collision.gameObject); // Agrega al enemigo a la lista de impactados
            }
        }
    }
}
