using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float initialTime = 60f; // Начальное время таймера
    public Text timerText; // Текстовый UI элемент

    private float timeRemaining;
    private GameOverManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameOverManager>();
        RestartTimer(); // Инициализация таймера
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                gameManager.Win();
            }
        }
    }

    public void RestartTimer()
    {
        timeRemaining = initialTime;
        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
