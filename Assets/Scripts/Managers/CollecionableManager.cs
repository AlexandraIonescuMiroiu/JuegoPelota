using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CollecionableManager : MonoBehaviour
{
    public static CollecionableManager Instance { get; private set; }
    private int collecionableCounter = 0;
    [SerializeField] private int collectiblesToWin = 3;
    [SerializeField] private TMP_Text collectibleTextCounter;
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
        UpdateCollectibleText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            audioManager.PlayCoindSound();
            other.gameObject.SetActive(false); collecionableCounter++;
            collectibleTextCounter.text = collecionableCounter.ToString() + " / " + collectiblesToWin;
        }
    }

    public void ResetCollectibles()
    {
        collecionableCounter = 0;
        UpdateCollectibleText();
    }

    public void UpdateCollectibleText()
    {
        if (collectibleTextCounter != null)
        {
            collectibleTextCounter.text = collecionableCounter.ToString() + " / " + collectiblesToWin;
        }
    }

    public int GetCollectiblesToWin()
    {
        return collectiblesToWin;
    }

    public int GetActualCollectibles()
    {
        return collecionableCounter;
    }
}