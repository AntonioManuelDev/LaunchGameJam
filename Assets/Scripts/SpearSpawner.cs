using UnityEngine;
using UnityEngine.UI; // Necesario para manipular la UI

public class SpearSpawner : MonoBehaviour
{
    public GameObject spearPrefab;       // Prefab de la lanza
    public Transform player;             // Referencia a la posición del jugador
    public Image barraDeCarga;           // Referencia a la barra de carga en la UI
    public float distanciaDeSpawn = 1f;  // Distancia desde el jugador donde se genera la lanza
    public float tiempoRecarga = 1f;     // Tiempo de recarga entre lanzamientos en segundos

    private float tiempoDesdeUltimoLanzamiento = 0f; // Temporizador para el tiempo de recarga

    void Update()
    {
        // Actualiza el temporizador
        tiempoDesdeUltimoLanzamiento += Time.deltaTime;

        // Actualiza la barra de carga
        barraDeCarga.fillAmount = Mathf.Clamp01(tiempoDesdeUltimoLanzamiento / tiempoRecarga);

        // Mueve la barra de carga para que siga al jugador
        Vector3 posicionBarra = player.position;
        posicionBarra.y += 0.7f; // Ajusta la altura según sea necesario
        barraDeCarga.transform.position = Camera.main.WorldToScreenPoint(posicionBarra); // Convierte a coordenadas de pantalla

        // Detecta si el botón izquierdo del ratón es presionado y si ha pasado suficiente tiempo desde el último lanzamiento
        if (Input.GetMouseButtonDown(0) && tiempoDesdeUltimoLanzamiento >= tiempoRecarga)
        {
            InstanciarLanza();
            tiempoDesdeUltimoLanzamiento = 0f; // Reinicia el temporizador de recarga
        }
    }

    void InstanciarLanza()
    {
        // Obtiene la posición del ratón en el mundo
        Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posicionRaton.z = 0; // Asegura que esté en el mismo plano que el jugador

        // Calcula la dirección hacia el ratón
        Vector3 direccion = (posicionRaton - player.position).normalized;

        // Calcula la posición de spawn de la lanza
        Vector3 posicionDeSpawn = player.position + direccion * distanciaDeSpawn;

        // Instancia la lanza y la rota hacia la dirección del ratón
        GameObject lanza = Instantiate(spearPrefab, posicionDeSpawn, Quaternion.identity);
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        lanza.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo));
    }
}