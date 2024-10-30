using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollecionableManager : MonoBehaviour
{
    private int collecionableCounter = 0;
    [SerializeField] private TMP_Text CollecionableCounter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            Destroy(other.gameObject);
            collecionableCounter++;
            CollecionableCounter.text = collecionableCounter.ToString();
            Debug.Log(collecionableCounter);
        }
    }
}