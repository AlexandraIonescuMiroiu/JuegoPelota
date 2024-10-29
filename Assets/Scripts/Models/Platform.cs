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
    private Vector3 rotationAxis = Vector3.zero;
    [SerializeField]
    private float rotationSpeed = 100f;

    private float timer = 0f;
    private bool movingForward = true;

    void Update()
    {
        switch (platformType)
        {
            case PlatformType.Moving:
                MovePlatform();
                break;

            case PlatformType.Rotating:
                RotatePlatform();
                break;

            case PlatformType.Damaging:
                MovePlatform();
                RotatePlatform();
                break;
        }
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
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Implement damage logic here
            // Example: other.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    }
}
