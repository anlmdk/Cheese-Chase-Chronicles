using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText;

    public int score = 0;


    void Start()
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

    void Update()
    {
        
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
}
