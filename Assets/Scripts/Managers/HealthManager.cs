using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }
    [SerializeField] private int maxLife;
    [SerializeField] private TMP_Text lifeTextCounter;
    [SerializeField] private GameObject gameOverPanel;

    private int life;

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
        life = maxLife;
        UpdateLifeText();
        gameOverPanel.SetActive(false);
    }

    public int GetLife()
    {
        return life;
    }

    public void SetLife(int life)
    {
        this.life = life;
    }

    public void ResetLife()
    {
        SetLife(maxLife);
        UpdateLifeText();
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
            SetLife(0);
            UpdateLifeText();
            GameManager.Instance.ShowGameOver();
        }
    }

    public void UpdateLifeText()
    {
        if (lifeTextCounter != null)
        {
            lifeTextCounter.text = life.ToString() + " / " + maxLife.ToString();
        }
    }
}
