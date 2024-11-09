using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CollecionableManager : MonoBehaviour
{
    public static CollecionableManager Instance { get; private set; }
    private int collecionableCounter = 0;
    [SerializeField] private TMP_Text collectibleTextCounter;

    [SerializeField] private TMP_Text CollecionableCounter;

    private AudioManager audioManager;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            audioManager.PlayCoindSound();
            Destroy(other.gameObject);
            collecionableCounter++;
            CollecionableCounter.text = collecionableCounter.ToString();
            Debug.Log(collecionableCounter);
        }
    }
    public void ResetCollectibles()
    {
        collecionableCounter = 0;

    }
    public void UpdateCollectibleText()
    {
        if (collectibleTextCounter != null)
        {
            collectibleTextCounter.text = collecionableCounter.ToString();
        }
    }
}