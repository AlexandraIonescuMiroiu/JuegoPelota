using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecionableManager : MonoBehaviour
{
    private int collecionableCounter = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            Destroy(other.gameObject);
            collecionableCounter++;
            Debug.Log(collecionableCounter);
        }
    }
}