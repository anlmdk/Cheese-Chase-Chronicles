using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    public float totalTime = 300.0f; // Toplam zaman (saniye cinsinden)
    private float passingTime = 0.0f; // Geçen zaman (saniye cinsinden)

    public TextMeshProUGUI timeText; // TextMeshPro nesnesi

    private bool isTimerRunning = true; // Zamanýn çalýþýp çalýþmadýðýný kontrol etmek için bir bool

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
        // Baþlangýçta zamaný ekranda gösterin
        UpdateTimerText();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            // Zamaný güncelleyin
            passingTime += Time.deltaTime;

            // Zamaný ekranda gösterin
            UpdateTimerText();

            // Süre dolduðunda istediðiniz iþlemleri yapabilirsiniz
            if (passingTime >= totalTime)
            {
                // Örneðin, bir þeyleri etkisiz hale getirebilir veya baþka bir iþlem yapabilirsiniz
                if (GameManager.instance.score > 75)
                {
                    GameManager.instance.LevelCompleted();
                }
                else
                {
                    GameManager.instance.GameOver();
                }

                // Zamaný durdurun
                isTimerRunning = false;
            }
        }
    }

    void UpdateTimerText()
    {
        // Kalan zamaný hesaplayýn
        float reaminingTime = Mathf.Max(totalTime - passingTime, 0.0f);

        // Dakika ve saniye cinsinden ayrý ayrý hesaplayýn
        int minute = Mathf.FloorToInt(reaminingTime / 60);
        int second = Mathf.FloorToInt(reaminingTime % 60);

        // TextMeshPro nesnesine zamaný güncelleyin
        timeText.text = string.Format("Time:" + " " + "{0:00}:{1:00}", minute, second);
    }
    // Karakter öldüðünde bu iþlevi çaðýrabilirsiniz
    public void StopTimer()
    {
        isTimerRunning = false;
    }
}
