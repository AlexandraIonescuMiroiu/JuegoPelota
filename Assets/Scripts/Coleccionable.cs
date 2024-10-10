using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public float velocidadRotacionX = -40f;
    public float velocidadRotacionY = 30f;
    public float velocidadRotacionZ = 0f;

    public float velocidad = 5f;
    public float rangoMovimientoY = 1f;
    public float frecuencia = 1f;
    private float tiempoPasado = 0f;

    void Update()
    {
        // Apuntes: NUNCA NORMALIZAR EL VECTOR ya que cada EJE tienen dirección y velocidad independientes.
        transform.Rotate(new Vector3(velocidadRotacionX, velocidadRotacionY, velocidadRotacionZ) * Time.deltaTime);

        tiempoPasado += Time.deltaTime;
        float nuevaPosY = Mathf.Sin(tiempoPasado * frecuencia) * rangoMovimientoY;
        transform.position = new Vector3(transform.position.x, nuevaPosY, transform.position.z);
    }
}

