using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float h = 0f;
    private float v = 0f;

    public float velocidad = 5f;
    public float fuerzaSalto = 5f;
    public Rigidbody rb;
    [SerializeField] AudioClip sonidoMoneda;
    [SerializeField] AudioManager manager;

    void Start()
    {

        //rb = GetComponent<Rigidbody>();
        

    }
    void Update()
    {
        
        Saltar();
        Movement();

    }
 

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }

    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
          rb.AddForce(Vector3.forward, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
          rb.AddForce(Vector3.left, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
          rb.AddForce(Vector3.right, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
          rb.AddForce(Vector3.back, ForceMode.Force);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coleccionable"))
        {
            manager.ReproducirSonido(sonidoMoneda);
            Destroy(collision.gameObject);
            Debug.Log("toquè");
        }


        /*public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Coleccionable"))
            {
                manager.ReproducirSonido(sonidoMoneda);
                Destroy(other.gameObject);
                Debug.Log("toquè");
            }
            else
            {
                Debug.Log("toqué otra cosa");

            }
        }
       */

    }
}
