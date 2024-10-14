using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 5f;
    [SerializeField] AudioClip sonidoMoneda;
    [SerializeField] AudioManager manager;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movimiento = new Vector3(h, 0, v).normalized;

        // Apuntes: Normalizamos para evitar velocidad diagonal mayor
        transform.Translate(movimiento * velocidad * Time.deltaTime, Space.World);

        if (movimiento != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(movimiento);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, Time.deltaTime * 10f);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            manager.ReproducirSonido(sonidoMoneda);
            Destroy(other.gameObject);
        }
    }
    





}
