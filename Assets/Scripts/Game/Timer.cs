using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float initialTime = 60f;
    public Text timerText;

    private float timeRemaining;
    private bool isRunning;

    private void Start()
    {
        RestartTimer();
    }

    private void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                timeRemaining = 0;
                isRunning = false;
                FindObjectOfType<GameOverManager>().Win();
            }
        }
    }

    public void RestartTimer()
    {
        timeRemaining = initialTime;
        isRunning = true;
        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
