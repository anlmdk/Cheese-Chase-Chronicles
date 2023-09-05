using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel, nextLevelPanel;

    public PlayerController player;

    public TextMeshProUGUI scoreText;

    public int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LevelCompleted()
    {
        if (score > 75)
        {
            nextLevelPanel.SetActive(true);
        }
    }
    public void Score()
    {
        score += 5;
        scoreText.text = "Puan: " + score;
    }
    public void HitEnemy()
    {
        score -= 5;
        scoreText.text = "Puan: " + score;
    }
    public void GameOver()
    {
        player.enabled = false;

        Timer.Instance.StopTimer();

        gameOverPanel.SetActive(true);

    }
}
