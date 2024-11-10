using System.Collections.Generic;
using UnityEngine;

public class WallParent : MonoBehaviour, IResettable
{
    private List<Transform> fragments;
    private List<Vector3> initialPositions;
    private List<Quaternion> initialRotations;
    private List<Rigidbody> rigidbodies;

    private void Awake()
    {
        fragments = new List<Transform>();
        initialPositions = new List<Vector3>();
        initialRotations = new List<Quaternion>();
        rigidbodies = new List<Rigidbody>();

        // Comenzamos desde el segundo hijo para evitar el primero que no tiene Rigidbody
        for (int i = 1; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            fragments.Add(child);
            initialPositions.Add(child.localPosition);
            initialRotations.Add(child.localRotation);

            Rigidbody rb = child.GetComponent<Rigidbody>();
            rigidbodies.Add(rb);
        }
    }

    public void ResetPosition()
    {
        for (int i = 0; i < fragments.Count; i++)
        {
            fragments[i].localPosition = initialPositions[i];
            fragments[i].localRotation = initialRotations[i];
            fragments[i].gameObject.SetActive(true);

            Rigidbody rb = rigidbodies[i];
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
                rb.isKinematic = false;
            }
        }
    }
}
