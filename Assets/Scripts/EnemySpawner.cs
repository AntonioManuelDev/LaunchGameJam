using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;           // Prefab del enemigo a instanciar
    public float intervaloDeGrupos = 5f;     // Tiempo entre la aparici�n de grupos en segundos
    public int maximoEnemigosPorGrupo = 3;   // N�mero m�ximo de enemigos por grupo
    public float intervaloEntreEnemigos = 1f; // Tiempo entre cada enemigo en un grupo en segundos

    private float rangoXMin = -8f;           // L�mite izquierdo de aparici�n en X
    private float rangoXMax = 8f;            // L�mite derecho de aparici�n en X
    private float posicionY = 6f;            // Posici�n Y de aparici�n

    void Start()
    {
        // Inicia la generaci�n de grupos de enemigos
        StartCoroutine(GenerarGruposDeEnemigos());
    }

    IEnumerator GenerarGruposDeEnemigos()
    {
        while (true)
        {
            // Genera un grupo de enemigos en una posici�n aleatoria en X
            float posicionX = Random.Range(rangoXMin, rangoXMax);
            int numeroAleatorioDeEnemigos = Random.Range(1, maximoEnemigosPorGrupo+1);
            Vector3 posicionDeAparicion = new Vector3(posicionX, posicionY, 0);

            // Genera enemigos en la misma posici�n, separados en el tiempo
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