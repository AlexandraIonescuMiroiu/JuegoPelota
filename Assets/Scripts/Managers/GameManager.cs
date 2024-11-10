//Hzme un singleton GameManager
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private Transform player;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text textGameOver;
    [SerializeField] private GameObject winPanel;

    private List<IResettable> resettables;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            resettables = new List<IResettable>(FindObjectsOfType<MonoBehaviour>().OfType<IResettable>());
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
            ShowGameWin();
        }
        else
        {
            int remainingCollectibles = CollecionableManager.Instance.GetCollectiblesToWin() - CollecionableManager.Instance.GetActualCollectibles();
            string newMessage = "GameOver - Collectibles remaining: " + remainingCollectibles;
            ShowGameOver(newMessage);
        }
    }

    public void ShowGameWin()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowGameOver(string newMessage = null)
    {
        if (newMessage != null)
        {
            textGameOver.text = newMessage;
        }
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResetGame()
    {
        HealthManager.Instance.ResetLife();
        CollecionableManager.Instance.ResetCollectibles();
        CheckpointManager.Instance.TeleportToCheckpoint(player.transform);

        foreach (var resettable in resettables)
        {
            resettable.ResetPosition();
        }

        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        Time.timeScale = 1;
    }
}