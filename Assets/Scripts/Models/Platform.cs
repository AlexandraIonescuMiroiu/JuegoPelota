using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float timeToChangeStatus = 5f;

    [SerializeField]
    private PlatformType platformType = PlatformType.None;
    [SerializeField]
    private Vector3 movementDirection = Vector3.zero;

    [SerializeField]
    private Vector3 rotationAxis = Vector3.up;
    [SerializeField]
    private float rotationSpeed = 1f;

    private float timer = 0f;
    private bool movingForward = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        switch (platformType)
        {
            case PlatformType.Moving:
                break;

            case PlatformType.Rotating:
                RotatePlatform();
                break;

            case PlatformType.Damaging:
                RotatePlatform();
                break;
        }
    }

    void Update()
    {
        switch (platformType)
        {
            case PlatformType.Moving:
                MovePlatform();
                break;

            case PlatformType.Rotating:
                break;

            case PlatformType.Damaging:
                MovePlatform();
                break;
        }
    }

    void FixedUpdate()
    {
       
    }

    void MovePlatform()
    {
        Vector3 movement = movingForward ? movementDirection : -movementDirection;
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        timer += Time.deltaTime;

        if (timer >= timeToChangeStatus)
        {
            movingForward = !movingForward;
            timer = 0f;
        }
    }

    void RotatePlatform()
    {
        rb.AddTorque(rotationAxis * rotationSpeed, ForceMode.VelocityChange);
    }
}
