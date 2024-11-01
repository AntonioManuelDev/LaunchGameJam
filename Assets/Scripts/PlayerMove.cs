using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movimiento del jugador")]
    public float velocidadMovimiento = 5f; // Velocidad de movimiento del jugador
    public float limiteIzquierdo = -8f;    // L�mite izquierdo del �rea de movimiento
    public float limiteDerecho = 8f;       // L�mite derecho del �rea de movimiento

    private float inputHorizontal;

    void Update()
    {
        // Obtiene la entrada horizontal (flechas o A/D)
        inputHorizontal = Input.GetAxis("Horizontal");

        // Calcula el nuevo movimiento
        Vector3 movimiento = new Vector3(inputHorizontal * velocidadMovimiento * Time.deltaTime, 0, 0);
        transform.position += movimiento;

        // Limita la posici�n del jugador
        float posicionLimitadaX = Mathf.Clamp(transform.position.x, limiteIzquierdo, limiteDerecho);
        transform.position = new Vector3(posicionLimitadaX, transform.position.y, transform.position.z);
    }
}
