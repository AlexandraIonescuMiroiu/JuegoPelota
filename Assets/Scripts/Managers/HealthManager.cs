using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }
    [SerializeField] private int life = 3;
    [SerializeField] private TMP_Text lifeTextCounter;
    [SerializeField] private Transform player;

    [SerializeField] private GameObject gameOverPanel;
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

    private void Start()
    {
        UpdateLifeText();
        gameOverPanel.SetActive(false);
    }

    public void PlayerHit()
    {
        if (life > 1)
        {
            life--;
            UpdateLifeText();
        }
        else
        {
            ShowGameOver();
        }
    }

    public void ShowGameOver()
    {
        life = 0;
        UpdateLifeText();
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reset()
    {
        life = 3;
        UpdateLifeText();
        CollecionableManager.Instance.ResetCollectibles();
        CollecionableManager.Instance.UpdateCollectibleText();
        CheckpointManager.Instance.TeleportToCheckpoint(player.transform);

        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void UpdateLifeText()
    {
        if (lifeTextCounter != null)
        {
            lifeTextCounter.text = life.ToString();
        }
    }
}
