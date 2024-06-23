using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float initialTime = 60f; // ��������� ����� �������
    public Text timerText; // ��������� UI �������

    private float timeRemaining;
    private GameOverManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameOverManager>();
        RestartTimer(); // ������������� �������
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
