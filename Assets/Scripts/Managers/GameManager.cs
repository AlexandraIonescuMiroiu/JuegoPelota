//Hzme un singleton GameManager
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject winPanel;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WinWall"))
        {
            CheckWin();
        }
    }

    private void CheckWin()
    {
        if (CollecionableManager.Instance.GetActualCollectibles() >= CollecionableManager.Instance.GetCollectiblesToWin())
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            HealthManager.Instance.ShowGameOver();
        }
    }
}