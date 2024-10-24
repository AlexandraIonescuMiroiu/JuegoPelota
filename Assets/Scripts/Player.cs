using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 5f;
    private Rigidbody rb;
    [SerializeField] AudioClip sonidoMoneda;
    [SerializeField] AudioManager manager;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        Saltar();
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

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
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
