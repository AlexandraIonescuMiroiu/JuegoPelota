using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 currentCheckpoint;

    void Start()
    {
        currentCheckpoint = new Vector3(0, 0, 0);
    }

    public void TeleportToCheckpoint(Transform player)
    {
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.velocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
        }

        player.position = currentCheckpoint;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TeleportToCheckpoint(other.transform);
        }
    }
}

