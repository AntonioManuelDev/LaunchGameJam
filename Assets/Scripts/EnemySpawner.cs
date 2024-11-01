using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;           // Prefab del enemigo a instanciar
    public float intervaloDeGrupos = 5f;     // Tiempo entre la aparición de grupos en segundos
    public int maximoEnemigosPorGrupo = 3;   // Número máximo de enemigos por grupo
    public float intervaloEntreEnemigos = 1f; // Tiempo entre cada enemigo en un grupo en segundos

    private float rangoXMin = -8f;           // Límite izquierdo de aparición en X
    private float rangoXMax = 8f;            // Límite derecho de aparición en X
    private float posicionY = 6f;            // Posición Y de aparición

    void Start()
    {
        // Inicia la generación de grupos de enemigos
        StartCoroutine(GenerarGruposDeEnemigos());
    }

    IEnumerator GenerarGruposDeEnemigos()
    {
        while (true)
        {
            // Genera un grupo de enemigos en una posición aleatoria en X
            float posicionX = Random.Range(rangoXMin, rangoXMax);
            int numeroAleatorioDeEnemigos = Random.Range(1, maximoEnemigosPorGrupo+1);
            Vector3 posicionDeAparicion = new Vector3(posicionX, posicionY, 0);

            // Genera enemigos en la misma posición, separados en el tiempo
            for (int i = 0; i < numeroAleatorioDeEnemigos; i++)
            {
                Instantiate(enemyPrefab, posicionDeAparicion, Quaternion.identity);
                yield return new WaitForSeconds(intervaloEntreEnemigos); // Espera antes de generar el siguiente enemigo
            }

            // Espera el tiempo especificado antes de generar el siguiente grupo
            yield return new WaitForSeconds(intervaloDeGrupos);
        }
    }
}