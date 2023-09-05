using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    public float totalTime = 300.0f; // Toplam zaman (saniye cinsinden)
    private float passingTime = 0.0f; // Ge�en zaman (saniye cinsinden)

    public TextMeshProUGUI timeText; // TextMeshPro nesnesi

    private bool isTimerRunning = true; // Zaman�n �al���p �al��mad���n� kontrol etmek i�in bir bool

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Ba�lang��ta zaman� ekranda g�sterin
        UpdateTimerText();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            // Zaman� g�ncelleyin
            passingTime += Time.deltaTime;

            // Zaman� ekranda g�sterin
            UpdateTimerText();

            // S�re doldu�unda istedi�iniz i�lemleri yapabilirsiniz
            if (passingTime >= totalTime)
            {
                // �rne�in, bir �eyleri etkisiz hale getirebilir veya ba�ka bir i�lem yapabilirsiniz
                if (GameManager.instance.score > 75)
                {
                    GameManager.instance.LevelCompleted();
                }
                else
                {
                    GameManager.instance.GameOver();
                }

                // Zaman� durdurun
                isTimerRunning = false;
            }
        }
    }

    void UpdateTimerText()
    {
        // Kalan zaman� hesaplay�n
        float reaminingTime = Mathf.Max(totalTime - passingTime, 0.0f);

        // Dakika ve saniye cinsinden ayr� ayr� hesaplay�n
        int minute = Mathf.FloorToInt(reaminingTime / 60);
        int second = Mathf.FloorToInt(reaminingTime % 60);

        // TextMeshPro nesnesine zaman� g�ncelleyin
        timeText.text = string.Format("Time:" + " " + "{0:00}:{1:00}", minute, second);
    }
    // Karakter �ld���nde bu i�levi �a��rabilirsiniz
    public void StopTimer()
    {
        isTimerRunning = false;
    }
}
