using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 6f;
    private Rigidbody rb;
    private GroundStatus groundStatus = GroundStatus.NotGrounded;


    private Transform cameraTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }
    void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        Jump();
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
            Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.red);
            return;
        }

        if (hit.collider.CompareTag("Ground"))
        {
            groundStatus = GroundStatus.Grounded;
            Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.green);
            return;
        }
        else
        {
            groundStatus = GroundStatus.NotGrounded;
            Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.red);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            HealthManager.Instance.PlayerHit();
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
            MovePlayer(direction);
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        Vector3 cameraForward = cameraTransform.TransformDirection(Vector3.forward);
        Vector3 cameraRight = cameraTransform.TransformDirection(Vector3.right);
        cameraForward.y = 0;
        cameraRight.y = 0;

        Vector3 finalDirection = (cameraForward.normalized * direction.z + cameraRight.normalized * direction.x).normalized;

        rb.AddForce(finalDirection * speed, ForceMode.Force);
    }
}