using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance { get; private set; }
    private Vector3 currentCheckpoint;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

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
        if (other.CompareTag("Player"))
        {
            TeleportToCheckpoint(other.transform);
            HealthManager.Instance.PlayerHit();
        }
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
    }
}
