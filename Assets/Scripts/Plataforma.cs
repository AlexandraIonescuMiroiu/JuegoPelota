using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float velocidad = 5f;
    public float tiempoInvertirDireccion = 5f;

    [SerializeField]
    private float direccion = 1f;

    private float timer = 0f;

    void Update()
    {
        Vector3 movimiento = new Vector3(direccion, 0, 0).normalized;
        transform.Translate(movimiento * velocidad * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= tiempoInvertirDireccion)
        {
            InvertirDireccion();
            timer = 0f;
        }
    }

    void InvertirDireccion()
    {
        direccion *= -1f;
    }
}
