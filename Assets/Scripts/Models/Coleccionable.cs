using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour, IResettable
{
    public float velocidadRotacionX = -40f;
    public float velocidadRotacionY = 30f;
    public float velocidadRotacionZ = 0f;

    public float velocidad = 5f;
    public float rangoMovimientoY = 1f;
    public float frecuencia = 1f;
    // Debemos empezar en 0 -> SIEMPRE
    private float tiempoPasado = 0f;
    private float posicionInicialY;
    private Vector3 initialPosition;
    private void Awake()
    {
        initialPosition = transform.localPosition;
    }

    void Start()
    {

        posicionInicialY = transform.position.y;
    }

    public void ResetPosition()
    {
        gameObject.SetActive(true);
        transform.localPosition = initialPosition;
    }

    void Update()
    {
        // NUNCA NORMALIZAR EL VECTOR ya que cada EJE tienen direcci�n y velocidad independientes.
        transform.Rotate(new Vector3(velocidadRotacionX, velocidadRotacionY, velocidadRotacionZ) * Time.deltaTime);

        tiempoPasado += Time.deltaTime;
        float nuevaPosY = Mathf.Sin(tiempoPasado * frecuencia) * rangoMovimientoY;
        transform.position = new Vector3(transform.position.x, posicionInicialY + nuevaPosY, transform.position.z);
    }
}