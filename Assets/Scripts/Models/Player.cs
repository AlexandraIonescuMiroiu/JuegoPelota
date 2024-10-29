using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private GroundStatus groundStatus = GroundStatus.NotGrounded;
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioManager manager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
        Movement();
        CheckGrounded();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundStatus == GroundStatus.Grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void CheckGrounded()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            groundStatus = GroundStatus.InAir;
            Debug.DrawRay(transform.position, Vector3.down, Color.red, 1.1f);
            return;
        }

        if (hit.collider.CompareTag("Ground"))
        {
            groundStatus = GroundStatus.Grounded;
            Debug.DrawRay(transform.position, Vector3.down, Color.green, 1.1f);
            return;
        }
        else
        {
            groundStatus = GroundStatus.NotGrounded;
        }
    }

    private void Movement()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }

        // APUNTES: Normalizamos para no tener una velocidad diagonal mayor
        if (direction != Vector3.zero)
        {
            direction.Normalize();
            rb.AddForce(direction * speed, ForceMode.Force);
        }
    }
}
